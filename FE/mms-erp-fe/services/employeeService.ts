

import { EmployeeDto } from "@/dtos/EmployeeDto";
import { fetchData } from "@/lib/api";

export async function getEmployees() {
    try {
        const employees = await fetchData<EmployeeDto[]>("/employee");
        return employees;
    }
    catch (error) {
        console.log("Error fetching employees:", error);
    }
}
