namespace MMS.Erp.Application.Services.ExpenseReport;

using MMS.Erp.Domain.QueryModels.Employee;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public interface IExpenseReportService
{
    Task<string?> UploadExpenseRecordAttachmentOnBlob(Stream? stream,
                                                      int employeeId,
                                                      int expenseReportId,
                                                      string? fileName);
    byte[] GenerateExpenseReportExcel(EmployeeModel employee,
                                      ExpenseReportModel report,
                                      IEnumerable<ExpenseRecordModel> travels,
                                      IEnumerable<ExpenseRecordModel> genericRefund);
    Task<string?> UploadExpenseReportOnBlob(byte[] file, string name, int month);
    Task DeleteExpenseRecordAttachmentFromBlob(string pathToAttachment);
}
