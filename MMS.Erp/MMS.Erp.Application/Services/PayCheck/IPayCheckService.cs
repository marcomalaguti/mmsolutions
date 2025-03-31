namespace MMS.Erp.Application.Services.PayCheck;
internal interface IPayCheckService
{
    Task<(string? paySlipUri, string? f24PdfUri)> UploadPaySlipPdfOnBlob(Stream? paySlip,
                                                                         Stream? f24Pdf,
                                                                         string employeeName);
}
