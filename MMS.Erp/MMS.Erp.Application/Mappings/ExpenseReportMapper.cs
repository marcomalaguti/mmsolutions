namespace MMS.Erp.Application.Mappings;

using Mapster;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Domain.Entities;
using MMS.Erp.Domain.QueryModels.Employee;

public static partial class ExpenseReportMapper
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<ExpenseReportModel, ExpenseReportDto>
        .NewConfig()
        .Map(d => d.Records, src => new List<ExpenseRecordDto>());

        TypeAdapterConfig<ExpenseRecordModel, ExpenseRecordDto>.NewConfig();

        TypeAdapterConfig<ExpenseRecord, ExpenseRecordDto>.NewConfig();
    }
}