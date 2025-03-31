namespace MMS.Erp.Api.Mappings;

using Mapster;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.PayCheck.Commands.CreatePayCheck;

public static partial class PaycheckMapper
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<CreatePayCheckRequest, CreatePayCheckCommand>
            .NewConfig()
            .Ignore(d => d.PaySlipPdf)
            .Ignore(d => d.F24Pdf)
            .Map(d => d.EmployeeId, src => MapContext.Current!.Parameters["EmployeeId"]);
    }
}