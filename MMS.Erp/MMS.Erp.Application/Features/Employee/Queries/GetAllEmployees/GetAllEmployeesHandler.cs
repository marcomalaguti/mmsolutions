namespace MMS.Erp.Application.Features.Employee.Queries.GetAllEmployees;

using MediatR;
using MMS.Erp.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

internal class GetAllEmployeesHandler() : IRequestHandler<GetAllEmployeesQuery, int>
{
    public Task<int> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
