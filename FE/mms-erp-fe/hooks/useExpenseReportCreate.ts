import { useEffect, useState } from "react";
import { EmployeeDto } from "@/dtos/EmployeeDto";
import { getEmployees } from "@/services/employeeService";
import { createExpenseReport } from "@/services/expenseReportService";
import { useRouter } from "next/navigation";

export function useExpenseReportCreate() {
    const [employeeId, setEmployeeId] = useState<number>(0);
    const [employees, setEmployees] = useState<EmployeeDto[]>([]);
    const [loading, setLoading] = useState(true);

    const router = useRouter();

    useEffect(() => {
        getEmployees().then((data) => {
            setEmployees(data ?? []);
        })
            .finally(() => setLoading(false));
    }, []);

    async function handleCreate() {

        console.log("Creating expense report for employee ID:", employeeId);
        const expReportId = await createExpenseReport(employeeId);

        console.log("Created expense report ID:", expReportId);

        if (expReportId) {
            router.push(`/expense-reports/${expReportId}`);
        }
    }

    return { employeeId, setEmployeeId, employees, setEmployees, loading, handleCreate };
}
