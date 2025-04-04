import { useEffect, useState } from "react";
import { ExpenseReportDto } from "@/dtos/ExpenseReportDto";
import { getExpenseReports } from "@/services/expenseReportService";

export function useExpenseReports() {
    const [expenseReports, setExpenseReports] = useState<ExpenseReportDto[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getExpenseReports().then((data) => {
            setExpenseReports(data ?? []);
        })
            .finally(() => setLoading(false));
    }, []);

    return { expenseReports, loading };
}
