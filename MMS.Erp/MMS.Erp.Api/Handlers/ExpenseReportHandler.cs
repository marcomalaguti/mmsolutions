namespace MMS.Erp.Api.Handlers;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseRecord;
using MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;
using MMS.Erp.Application.Features.ExpenseReport.Commands.DeleteExpenseRecord;
using MMS.Erp.Application.Features.ExpenseReport.Commands.SetStateReport;
using MMS.Erp.Application.Features.ExpenseReport.Queries.DownloadExpenseReport;
using MMS.Erp.Application.Features.ExpenseReport.Queries.GetAll;
using MMS.Erp.Application.Features.ExpenseReport.Queries.GetByEmployeeId;
using MMS.Erp.Application.Features.ExpenseReport.Queries.GetById;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Entities;
using System.Threading;

public static class ExpenseReportHandler
{
    public static string BaseUrl = "/expense-report";

    internal static async Task<IResult> CreateExpenseRecord([FromServices] ISender sender,
                                                            [FromServices] IMapper mapper,
                                                            [FromRoute] int employeeId,
                                                            [FromRoute] int expenseReportId,
                                                            [FromForm] CreateExpenseRecordRequest request,
                                                            CancellationToken cancellationToken)
    {
        try
        {
            var command = mapper
                .From(request)
                .AddParameters("EmployeeId", employeeId)
                .AddParameters("ExpenseReportId", expenseReportId)
                .AdaptToType<CreateExpenseRecordCommand>();

            command.Attachment = request.Attachment;

            var result = await sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                var returnUrl = $"{EmployeeHandler.BaseUrl}/{employeeId}/{BaseUrl}/{expenseReportId}/expense-record/{result.Value!.Id}";
                return TypedResults.Created(returnUrl, result.Value);
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

    internal static async Task<IResult> CreateExpenseReport([FromServices] ISender sender,
                                                            [FromServices] IMapper mapper,
                                                            [FromRoute] int employeeId,
                                                            CreateExpenseReportRequest request,
                                                            CancellationToken cancellationToken)
    {
        try
        {
            var command = mapper
                .From(request)
                .AddParameters("EmployeeId", employeeId)
                .AdaptToType<CreateExpenseReportCommand>();

            var result = await sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                var returnUrl = $"{EmployeeHandler.BaseUrl}/{employeeId}/{BaseUrl}/{result.Value}";
                return TypedResults.Created(returnUrl, result.Value);
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

    internal static async Task<IResult> DeleteExpenseRecord([FromServices] ISender sender,
                                                        [FromRoute] int employeeId,
                                                        [FromRoute] int expenseReportId,
                                                        [FromRoute] int expenseRecordId,
                                                        CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(new DeleteExpenseRecordCommand(expenseReportId, employeeId, expenseRecordId), cancellationToken);

            var expenseReportFile = result.Value!;

            if (result.IsSuccess)
            {
                return TypedResults.NoContent();
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

    internal static async Task<IResult> DownloadExpenseReport([FromServices] ISender sender,
                                                        [FromRoute] int expenseReportId,
                                                        CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(new DownloadExpenseReportQuery(expenseReportId), cancellationToken);

            var expenseReportFile = result.Value!;

            if (result.IsSuccess)
            {
                return TypedResults.File(expenseReportFile.File!, expenseReportFile.ContentType, expenseReportFile.Name);
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

    internal static async Task<IResult> GetAll([FromServices] ISender sender,
                                      CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(new GetAllQuery(), cancellationToken);

            if (result.IsSuccess)
                return TypedResults.Ok(result.Value);

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

    internal static async Task<IResult> GetByEmployeeId([FromServices] ISender sender,
                                                        [FromRoute] int employeeId,
                                                        CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(new GetByEmployeeIdQuery(employeeId), cancellationToken);

            if (result.IsSuccess)
                return TypedResults.Ok(result.Value);

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

    internal static async Task<IResult> GetById([FromServices] ISender sender,
                                                [FromRoute] int expenseReportId,
                                                CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(new GetByIdQuery(expenseReportId), cancellationToken);

            if (result.IsSuccess)
                return TypedResults.Ok(result.Value);

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

    internal static async Task<IResult> SetStateExportReport([FromServices] ISender sender,
                                                [FromRoute] int expenseReportId,
                                                [FromRoute] int employeeId,
                                                SetStateExpenseReportRequest request,
                                                CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(new SetStateReportCommand(employeeId, expenseReportId, request.StateId), cancellationToken);

            if (result.IsSuccess)
                return TypedResults.Ok();

            return TypedResults.BadRequest();
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