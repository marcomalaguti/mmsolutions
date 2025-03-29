namespace MMS.Erp.Domain.Repositories;

using MMS.Erp.Domain.Repositories.Customer;
using MMS.Erp.Domain.Repositories.Employee;
using MMS.Erp.Domain.Repositories.Invoice;

public interface IUnitOfWork : IDisposable
{
    IInvoiceCommandsRepository Invoices { get; }
    ICustomerCommandsRepository Customers { get; }
    IEmployeeCommandsRepository Employees { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}