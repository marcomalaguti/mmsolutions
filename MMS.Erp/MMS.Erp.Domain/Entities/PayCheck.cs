namespace MMS.Erp.Domain.Entities;

using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Primitives;

public class PayCheck : Entity
{
    public int EmployeeId { get; private set; }
    public decimal SalaryAmount { get; private set; }
    public decimal TaxAmount { get; private set; }
    public DateTime Date { get; private set; }
    public bool IsSettled { get; private set; }
    public string? PaySlipPath { get; private set; }
    public string? F24Path { get; private set; }

    private PayCheck()
    {

    }

    private PayCheck(int employeeId,
                    decimal salaryAmount,
                    decimal taxes,
                    DateTime? date,
                    bool? isSettled,
                    string? paySlipPath,
                    string? f24Path)
    {
        EmployeeId = employeeId;
        SalaryAmount = salaryAmount;
        TaxAmount = taxes;
        Date = date ?? DateTime.Now;
        IsSettled = isSettled ?? false;
        PaySlipPath = paySlipPath;
        F24Path = f24Path;
    }

    public static Result<PayCheck> Create(int employeeId,
                                          decimal salaryAmount,
                                          decimal taxAmount,
                                          DateTime? date,
                                          bool? isSettled,
                                          string? paySlipPath,
                                          string? f24Path)
    {
        if (employeeId == 0)
            Result<PayCheck>.Failure(PayCheckErrors.InvalidEmployeeId);

        if (salaryAmount <= 0)
            Result<PayCheck>.Failure(PayCheckErrors.InvalidSalary);

        if (taxAmount <= 0)
            Result<PayCheck>.Failure(PayCheckErrors.InvalidTax);

        PayCheck paycheck = new(employeeId,
                                salaryAmount,
                                taxAmount,
                                date,
                                isSettled,
                                paySlipPath,
                                f24Path);

        return Result<PayCheck>.Success(paycheck);
    }
}
