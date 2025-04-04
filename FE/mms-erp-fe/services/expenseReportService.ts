

import { ExpenseRecordDto } from "@/dtos/ExpenseRecordDto";
import { ExpenseReportDto } from "@/dtos/ExpenseReportDto";
import { deleteData, fetchData, postFormData, donwloadFile, postData } from "@/lib/api";
// import { useRouter } from "next/navigation";

export async function getExpenseReports() {
    try {
        const reports = await fetchData<ExpenseReportDto[]>("/expense-report");
        return reports;
    }
    catch (error) {
        console.log("Error fetching reports:", error);
    }
}

export async function getExpenseReport(expenseReportId: number) {
    try {
        const report = await fetchData<ExpenseReportDto>("/expense-report/" + expenseReportId);
        return report;
    }
    catch (error) {
        console.log("Error fetching reports:", error);
    }
}

export async function createExpenseReport(employeeId: number) {
    try {
        return await postData<number>("/employee/" + employeeId + "/expense-report", { method: "POST" });
    }
    catch (error) {
        console.log("Error fetching reports:", error);
    }
}

export async function downloadExpenseReportExcel(expenseReportId: number, fileName: string) {
    try {
        const report = await donwloadFile("/expense-report/" + expenseReportId + "/download", fileName);
        return report;
    }
    catch (error) {
        console.log("Error fetching reports:", error);
    }
}

export async function deleteExpenseRecord(recordId: number, reportId: number, employeeId: number) {
    try {
        await deleteData("/employee/" + employeeId + "/expense-report/" + reportId + "/expense-record/" + recordId);
    }
    catch (error) {
        console.log("Error fetching reports:", error);
    }
}


export async function setReportState(reportId: number, employeeId: number, stateId: number) {
    try {
        const report = await postData<ExpenseReportDto>("/employee/" + employeeId + "/expense-report/" + reportId + "/set-state", { stateId });
        return report;
    }
    catch (error) {
        console.log("Error fetching reports:", error);
    }
}

export async function createExpenseRecord(employeeId: number, expeseReportId: number, expenseRecord: ExpenseRecordDto) {
    try {

        console.log("Creating expense record:", expenseRecord);

        const formData = new FormData();
        // Append only the fields that have values
        if (expenseRecord.typeId) {
            formData.append("typeId", expenseRecord.typeId.toString());
        }

        if (expenseRecord.description) {
            formData.append("description", expenseRecord.description);
        }

        if (expenseRecord.traveledKm) {
            formData.append("traveledKm", expenseRecord.traveledKm.toString());
        }

        if (expenseRecord.kmReimbursement) {
            formData.append("kmReimbursement", expenseRecord.kmReimbursement.toString());
        }

        if (expenseRecord.tolls) {
            formData.append("tolls", expenseRecord.tolls.toString());
        }

        if (expenseRecord.meals) {
            formData.append("meals", expenseRecord.meals.toString());
        }

        if (expenseRecord.accommodation) {
            formData.append("accommodation", expenseRecord.accommodation.toString());
        }

        if (expenseRecord.lumpSum) {
            formData.append("lumpSum", expenseRecord.lumpSum.toString());
        }

        // Ensure file is appended correctly
        if (expenseRecord.file) {
            formData.append("Attachment", expenseRecord.file);
        }

        console.log("FormData:", formData);

        if (expenseRecord.file) {
            formData.append("Attachment", expenseRecord.file); // assuming the file field is named 'Attachment'
        }

        console.log("FormData:", formData);

        var report = await postFormData<ExpenseRecordDto>("/employee/" + employeeId + "/expense-report/" + expeseReportId, formData);

        return report as ExpenseRecordDto;
    }
    catch (error) {
        console.log("Error fetching reports:", error);
    }
}
