
import { ExpenseRecordDto } from "./ExpenseRecordDto";

export interface ExpenseReportDto {
    id: number;
    label: string;
    total: number;
    stateId: number;
    stateDescription: string;
    employeeId: number;
    records: ExpenseRecordDto[]; 
}