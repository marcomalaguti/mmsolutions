namespace MMS.Erp.Infrastructure.Repositories;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Customer;
using MMS.Erp.Domain.Repositories.Employee;
using MMS.Erp.Domain.Repositories.Invoice;
using MMS.Erp.Infrastructure.Repositories.Customer;
using MMS.Erp.Infrastructure.Repositories.Employee;
using MMS.Erp.Infrastructure.Repositories.Invoice;
using System.Threading;
using System.Threading.Tasks;

public class UnitOfWork(ErpDbContext context) : IUnitOfWork
{
    private IInvoiceCommandsRepository? _invoiceRepository;
    private ICustomerCommandsRepository? _customerRepository;
    private IEmployeeCommandsRepository? _employeeRepository;

    public IInvoiceCommandsRepository Invoices => _invoiceRepository ??= new InvoiceCommandsRepository(context);

    public ICustomerCommandsRepository Customers => _customerRepository ??= new CustomerCommandsRepository(context);

    public IEmployeeCommandsRepository Employees => _employeeRepository ??= new EmployeeCommandsRepository(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await context.SaveChangesAsync(cancellationToken);

    public void Dispose() => context.Dispose();

}