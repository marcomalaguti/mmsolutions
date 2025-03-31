namespace MMS.Erp.Application.Services.PayCheck;

using Microsoft.Extensions.Options;
using MMS.AzureBlobStorage.Services;
using MMS.Erp.Application.Configurations;

internal class PayCheckService(IAzureBlobStorageService azureBlobStorageService,
                               IOptions<PayChecksConfig> config) : IPayCheckService
{
    public async Task<(string? paySlipUri, string? f24PdfUri)> UploadPaySlipPdfOnBlob(Stream? paySlip,
                                             Stream? f24Pdf,
                                             string employeeName)
    {
        var paySlipUri = await UploadPaycheckFilesOnBlob(paySlip, employeeName, "Cedolino");
        var f24PdfUri = await UploadPaycheckFilesOnBlob(f24Pdf, employeeName, "F24");

        return (paySlipUri, f24PdfUri);
    }

    private async Task<string?> UploadPaycheckFilesOnBlob(Stream? file,
                                                     string employeeName,
                                                     string type)
    {
        if (file is null)
            return null;

        if (string.IsNullOrEmpty(employeeName))
            throw new ArgumentException($"{nameof(employeeName)}");

        var pathToFile = $"{DateTime.Now.Year}/{DateTime.Now.ToString("yyyyMM")}_{employeeName}_{type}.pdf";

        var uri = await azureBlobStorageService.UploadAsync(file,
                                                  pathToFile,
                                                  config.Value.ContainerName);

        return uri;
    }
}
