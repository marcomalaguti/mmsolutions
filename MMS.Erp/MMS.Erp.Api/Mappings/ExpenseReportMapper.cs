namespace MMS.Erp.Api.Mappings;

using Mapster;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;


public static partial class ExpenseReportMapper
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<CreateExpenseReportRequest, CreateExpenseReportCommand>
            .NewConfig()
            .Map(d => d.EmployeeId, src => MapContext.Current!.Parameters["EmployeeId"]);
    }
}