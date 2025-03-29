﻿namespace MMS.Erp.Infrastructure.Repositories;
using MMS.Erp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

public class UnitOfWork(ErpDbContext context) : IUnitOfWork
{
    private IInvoiceRepository? _invoiceRepository;
    private ICustomerRepository? _customerRepository;
    private IEmployeeRepository? _employeeRepository;

    public IInvoiceRepository Invoices => _invoiceRepository ??= new InvoiceRepository(context);

    public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(context);

    public IEmployeeRepository Employees => _employeeRepository ??= new EmployeeRepository(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await context.SaveChangesAsync(cancellationToken);

    public void Dispose() => context.Dispose();

}