namespace MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;

using MediatR;
using MMS.Erp.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

internal class CreateExpenseReportHandler(IEmployeeRepository employeeRepository,
                                          IUnitOfWork unitOfWork) : IRequestHandler<CreateExpenseReportCommand, int>
{
    public async Task<int> Handle(CreateExpenseReportCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId)
            ?? throw new ArgumentNullException(nameof(Employee));

        employee.AddNewExpenseReport();

        employeeRepository.Update(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var expenseReportId = employee.ExpenseReports.Last().Id;
        return expenseReportId;
    }
}
