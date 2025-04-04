import { useEffect, useState } from "react";
import { getEmployees } from "@/services/employeeService";
import { EmployeeDto } from "@/dtos/EmployeeDto";

export function useEmployees() {
    const [employees, setEmployees] = useState<EmployeeDto[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getEmployees().then((data) => {
            console.log("Fetched employees:", data); // Log the fetched data
            // Se data è undefined, imposta un array vuoto
            setEmployees(data ?? []);
        })
            .finally(() => setLoading(false));
    }, []);

    return { employees, loading };
}
