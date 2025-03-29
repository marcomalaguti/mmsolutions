namespace MMS.Erp.Api.Mappings;

using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class ExpenseReportMapper
{
    public static partial CreateExpenseReportCommand MapToCreateExpenseReportCommand(CreateExpenseReportRequest invoice);
}