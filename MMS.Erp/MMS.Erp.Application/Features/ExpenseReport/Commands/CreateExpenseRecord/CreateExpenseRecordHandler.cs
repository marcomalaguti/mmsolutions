namespace MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseRecord;

using Mapster;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Application.Services.ExpenseReport;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Entities;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class CreateExpenseRecordHandler(IEmployeeCommandsRepository employeeCommandsRepository,
                                          IExpenseReportService expenseReportService,
                                          IUnitOfWork unitOfWork)
    : ICommandHandler<CreateExpenseRecordCommand, ExpenseRecordDto?>
{
    public async Task<Result<ExpenseRecordDto?>> Handle(CreateExpenseRecordCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeCommandsRepository.GetByIdAsync(request.EmployeeId);

        if (employee is null)
            return Result<ExpenseRecordDto?>.Failure(ExpenseReportErrors.EmployeeNotFound);

        var expenseReport = employee.ExpenseReports.FirstOrDefault(x => x.Id == request.ExpenseReportId);

        if (expenseReport is null)
            return Result<ExpenseRecordDto?>.Failure(ExpenseReportErrors.NotFound);

        string? pathToAttachment = await expenseReportService
                                         .UploadExpenseRecordAttachmentOnBlob(request.Attachment?.OpenReadStream(),
                                                                              request.EmployeeId,
                                                                              request.ExpenseReportId,
                                                                              request.Attachment?.FileName);
       
        var expenseRecordResult = ExpenseRecord.Create(request.TypeId,
                                                       request.Description!,
                                                       request.TraveledKm,
                                                       request.KmReimbursement,
                                                       request.Tolls,
                                                       request.Meals,
                                                       request.Accommodation,
                                                       request.LumpSum,
                                                       pathToAttachment,
                                                       expenseReport.Id);

        if (expenseRecordResult.IsFailure)
            return Result<ExpenseRecordDto?>.Failure(expenseRecordResult.Error);

        var expenseRecord = expenseRecordResult.Value!;

        expenseReport.AddExpenseRecord(expenseRecord);

        employeeCommandsRepository.Update(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var ret = expenseRecord.Adapt<ExpenseRecordDto>();

        return Result<ExpenseRecordDto?>.Success(ret);
    }
}
