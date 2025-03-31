namespace MMS.Erp.Application.Features.PayCheck.Commands.CreatePayCheck;

using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Application.Services.PayCheck;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Entities;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class CreatePayCheckHandler(IEmployeeCommandsRepository employeeCommandsRepository,
                                     IPayCheckService payCheckService,
                                     IUnitOfWork unitOfWork)
    : ICommandHandler<CreatePayCheckCommand, int>
{
    public async Task<Result<int>> Handle(CreatePayCheckCommand request,
                                          CancellationToken cancellationToken)
    {
        var employee = await employeeCommandsRepository.GetByIdAsync(request.EmployeeId);

        if (employee is null)
            return Result<int>.Failure(ExpenseReportErrors.EmployeeNotFound);

        (string? paySlipPath, string? f24Path) = await payCheckService.UploadPaySlipPdfOnBlob(request.PaySlipPdf?.OpenReadStream(),
                                                                                              request.F24Pdf?.OpenReadStream(),
                                                                                              employee.FullName!);

        var paycheckResult = PayCheck.Create(request.EmployeeId,
                                             request.SalaryAmount,
                                             request.TaxAmount,
                                             request.Date,
                                             request.IsSettled,
                                             paySlipPath,
                                             f24Path);

        if (paycheckResult.IsFailure)
            return Result<int>.Failure(paycheckResult.Error);

        var payCheck = paycheckResult.Value!;

        employee.AddNewPayCheck(payCheck);

        employeeCommandsRepository.Update(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(payCheck.Id);
    }
}
