import { useEffect, useState } from "react";
import { ExpenseReportDto } from "@/dtos/ExpenseReportDto";
import { createExpenseRecord,
     getExpenseReport,
      getExpenseReports,
       deleteExpenseRecord,
        downloadExpenseReportExcel ,
        setReportState} from "@/services/expenseReportService";
import { useParams } from "next/navigation";
import { ExpenseRecordDto } from "@/dtos/ExpenseRecordDto";

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


export function useExpenseReportDetails() {
    const { id } = useParams();
    const [expenseReport, setExpenseReport] = useState<ExpenseReportDto | null>(null);
    const [reportLoading, setLoading] = useState(true);

    const [newRecord, setNewRecord] = useState<ExpenseRecordDto>({
        id: 0, // Assicurati che sia sempre un numero
        typeId: 1,
        description: "",
        traveledKm: 0, // Usa un valore numerico predefinito invece di null
        kmReimbursement: 0,
        tolls: 0,
        meals: 0,
        accommodation: 0,
        lumpSum: 0,
        date: new Date().toISOString(),
        total: 0,
        file: null,
    });

    const expenseTypes: Record<number, string> = {
        1: "Trasferta",
        2: "Rimborso Generico"
    };

    const handleFileChange = (e: any) => {
        setNewRecord({ ...newRecord, file: e.target.files[0] });
    };

    async function handleDelete(recordId: number) {

        await deleteExpenseRecord(recordId, expenseReport!.id, expenseReport!.employeeId);

        setExpenseReport({
            ...expenseReport!,
            records: expenseReport!.records.filter(r => r.id !== recordId),
        });
    }

    async function downloadExcel(reportId: number, label: string, empployeeName: string) {
        const fileName = `ExpenseReport_${label}_${empployeeName}.xlsx`;
        await downloadExpenseReportExcel(reportId, fileName);
    }

    async function submitReport(reportId: number, employeeId: number) {  
        const submitStateId = 2;      
        await setReportState(reportId, employeeId, submitStateId);        
        setExpenseReport({
            ...expenseReport!,
            stateId: submitStateId
        });
    }

    async function handleAddRecord() {
        if (!newRecord) return;

        console.log("Adding new record:", newRecord);

        const response = await createExpenseRecord(expenseReport!.employeeId, expenseReport!.id, newRecord)

        if (response == null) return;

        setExpenseReport({
            ...expenseReport!,
            records: [...expenseReport!.records, response],
        });

        setNewRecord({
            id: 0,
            typeId: 1,
            description: "",
            traveledKm: null,
            kmReimbursement: null,
            tolls: null,
            meals: null,
            accommodation: null,
            lumpSum: null,
            date: new Date().toISOString(),
            total: 0,
            file: null,
        });
    }

    useEffect(() => {
        getExpenseReport(Number(id)).then((data) => {
            console.log("Fetched report:", data);
            setExpenseReport(data ?? null);
        })
            .finally(() => setLoading(false));
    }, []);

    return {
        expenseReport,
        expenseTypes,
        newRecord,
        reportLoading,
        setExpenseReport,
        setNewRecord,
        handleDelete,
        handleAddRecord,
        handleFileChange,
        downloadExcel,
        submitReport
    };
}