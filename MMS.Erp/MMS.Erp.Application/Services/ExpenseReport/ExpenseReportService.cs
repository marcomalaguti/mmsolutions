namespace MMS.Erp.Application.Services.ExpenseReport;

using ClosedXML.Excel;
using Microsoft.Extensions.Options;
using MMS.AzureBlobStorage.Services;
using MMS.Erp.Application.Configurations;
using MMS.Erp.Domain.QueryModels.Employee;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

internal class ExpenseReportService(IAzureBlobStorageService azureBlobStorageService,
                                    IOptions<ExpenseReportsConfig> config) : IExpenseReportService
{
    public async Task<string?> UploadExpenseRecordAttachmentOnBlob(Stream? attachment,
                                                                   int employeeId,
                                                                   int expenseReportId,
                                                                   string? fileName)
    {
        if (attachment is null)
            return null;

        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentException($"{nameof(fileName)}");

        var fileExtension = Path.GetExtension(fileName);

        var pathToAttachment = $"{config.Value.ExpenseRecordAttachmentsFolderName}/" +
            $"{employeeId}_{expenseReportId}_{Guid.NewGuid()}{fileExtension}";

        await azureBlobStorageService.UploadAsync(attachment,
                                                  pathToAttachment,
                                                  config.Value.ContainerName);

        return pathToAttachment;
    }

    public byte[] GenerateExpenseReportExcel(EmployeeModel employee,
                                             ExpenseReportModel report,
                                             IEnumerable<ExpenseRecordModel> travels,
                                             IEnumerable<ExpenseRecordModel> genericRefunds)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Report");

        int currentRow = 1;

        var titleCell = worksheet.Cell(currentRow, 1);
        titleCell.Value = "NOTA SPESE";
        titleCell.Style.Font.Bold = true;
        titleCell.Style.Font.FontSize = 18;
        worksheet.Range(currentRow, 1, currentRow, 5)
            .Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        currentRow += 2;

        worksheet.Cell(1, 6).Value = "MM Solutions SRL";
        worksheet.Cell(2, 6).Value = "Via delle Rose, 20/34";
        worksheet.Cell(3, 6).Value = "20025 Legnano (MI)";
        worksheet.Cell(4, 6).Value = "P.IVA: 13983840961";
        worksheet.Range(1, 6, 4, 8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Cell(currentRow, 1).Value = "Periodo:";
        worksheet.Cell(currentRow, 2).Value = report.Date
            .ToString("MMMM yyyy", new CultureInfo("it-IT"));
        worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
        currentRow += 2;

        worksheet.Cell(currentRow, 1).Value = "Nome:";
        worksheet.Cell(currentRow, 2).Value = employee.FirstName;
        worksheet.Cell(currentRow, 1).Style.Font.Bold = true;

        worksheet.Cell(currentRow, 3).Value = "Cognome:";
        worksheet.Cell(currentRow, 4).Value = employee.LastName;
        worksheet.Cell(currentRow, 3).Style.Font.Bold = true;

        currentRow += 2;

        if (travels.Any())
        {
            worksheet.Cell(currentRow, 3).Value = "TRASFERTE:";
            worksheet.Cell(currentRow, 3).Style.Font.Bold = true;

            var headers = new List<string>
            {
                "Data",
                "Descrizione",
                "KM Percorsi A/R",
                "Rimborso x KM (€)",
                "Pedaggi",
                "Spese Vitto",
                "Diaria Forfait",
                "Totale"
            };

            for (int i = 0; i < headers.Count; i++)
            {
                var headerCell = worksheet.Cell(currentRow, i + 1);
                headerCell.Value = headers[i];
                headerCell.Style.Font.Bold = true;
                headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }

            currentRow++;

            foreach (var travel in travels)
            {
                worksheet.Cell(currentRow, 1).Value = travel.Date?.ToString("dd/MM/yyyy");
                worksheet.Cell(currentRow, 2).Value = travel.Description;
                worksheet.Cell(currentRow, 3).Value = travel.TraveledKm;
                worksheet.Cell(currentRow, 3).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Cell(currentRow, 4).Value = travel.KmReimbursement;
                worksheet.Cell(currentRow, 4).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Cell(currentRow, 5).Value = travel.Tolls;
                worksheet.Cell(currentRow, 5).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Cell(currentRow, 6).Value = travel.Meals;
                worksheet.Cell(currentRow, 6).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Cell(currentRow, 7).Value = travel.LumpSum;
                worksheet.Cell(currentRow, 7).Style.NumberFormat.Format = "#,##0.00";
                worksheet.Cell(currentRow, 8).Value = travel.Total;
                worksheet.Cell(currentRow, 8).Style.NumberFormat.Format = "#,##0.00";

                for (int i = 0; i < headers.Count; i++)
                {
                    worksheet.Cell(currentRow, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                currentRow++;
            }
        }

        currentRow++;

        if (genericRefunds.Any())
        {
            worksheet.Cell(currentRow, 3).Value = "RIMBORSO PRANZI:";
            worksheet.Cell(currentRow, 3).Style.Font.Bold = true;

            var headers = new List<string>
            {
                "Data",
                "Descrizione",
                "Totale"
            };

            for (int i = 0; i < headers.Count; i++)
            {
                var headerCell = worksheet.Cell(currentRow, i + 1);
                headerCell.Value = headers[i];
                headerCell.Style.Font.Bold = true;
                headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }

            currentRow++;

            foreach (var genericRefund in genericRefunds)
            {
                worksheet.Cell(currentRow, 1).Value = genericRefund.Date?.ToString("dd/MM/yyyy");
                worksheet.Cell(currentRow, 2).Value = genericRefund.Description;
                worksheet.Cell(currentRow, 3).Value = genericRefund.Total;
                worksheet.Cell(currentRow, 3).Style.NumberFormat.Format = "#,##0.00";

                for (int i = 0; i < headers.Count; i++)
                {
                    worksheet.Cell(currentRow, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                currentRow++;
            }
        }

        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public async Task<string?> UploadExpenseReportOnBlob(byte[] file, string name, int month)
    {
        if (file is null)
            return null;

        if (string.IsNullOrEmpty(name))
            throw new ArgumentException($"{nameof(name)}");

        var pathToReport = $"{config.Value.ExpenseReportsFolderName}/{name}";

        var ret = await azureBlobStorageService.UploadAsync(file,
                                                            pathToReport,
                                                            config.Value.ContainerName);

        return ret;
    }

    public async Task DeleteExpenseRecordAttachmentFromBlob(string pathToAttachment)
    {
        if (string.IsNullOrWhiteSpace(pathToAttachment))
            return;

        await azureBlobStorageService.DeleteAsync(pathToAttachment,
                                                                    config.Value.ContainerName);
    }
}
