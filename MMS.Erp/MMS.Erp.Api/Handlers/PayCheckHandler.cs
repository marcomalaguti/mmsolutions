namespace MMS.Erp.Api.Handlers;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.PayCheck.Commands.CreatePayCheck;
using System;
using System.Threading.Tasks;

public static class PayCheckHandler
{
    public static string BaseUrl = "/pay-check";

    internal static async Task<IResult> CreatePayCheck([FromServices] ISender sender,
                                                       [FromServices] IMapper mapper,
                                                       [FromRoute] int employeeId,
                                                       [FromForm] CreatePayCheckRequest request,
                                                       CancellationToken cancellationToken)
    {
        try
        {
            var command = mapper
                .From(request)
                .AddParameters("EmployeeId", employeeId)
                .AdaptToType<CreatePayCheckCommand>();

            command.F24Pdf = request.F24Pdf;
            command.PaySlipPdf = request.PaySlipPdf;

            var result = await sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                var returnUrl = $"{EmployeeHandler.BaseUrl}/{employeeId}/{BaseUrl}/{result.Value}";
                return TypedResults.Created(returnUrl);
            }

            return TypedResults.BadRequest(result.Error);
        }
        catch (FluentValidation.ValidationException ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return TypedResults.UnprocessableEntity(ex.Message);
        }
    }
}
