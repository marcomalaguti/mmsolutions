namespace MMS.Erp.Api.Mappings;

using Mapster;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseRecord;
using MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;


public static partial class ExpenseReportMapper
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<CreateExpenseReportRequest, CreateExpenseReportCommand>
            .NewConfig()
            .Map(d => d.EmployeeId, src => MapContext.Current!.Parameters["EmployeeId"]);

        TypeAdapterConfig<CreateExpenseRecordRequest, CreateExpenseRecordCommand>
            .NewConfig()
            .Ignore(d => d.Attachment)
            .Map(d => d.EmployeeId, src => MapContext.Current!.Parameters["EmployeeId"])
            .Map(d => d.ExpenseReportId, src => MapContext.Current!.Parameters["ExpenseReportId"]);
    }
}