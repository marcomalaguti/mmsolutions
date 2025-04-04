
"use client"

import Layout from "@/components/layout"
import { Button } from "@/components/ui/button";
import { IconPlus } from "@tabler/icons-react";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { useExpenseReportCreate } from "@/hooks/useExpenseReportCreate";

export default function Page() {

  const {
    loading,
    employeeId,
    setEmployeeId,
    employees,
    handleCreate
  } = useExpenseReportCreate();

  if (loading) return <p>Loading...</p>;

  return (
    <Layout>
    <div className="p-6 max-w-xl mx-auto space-y-6">
      <h1 className="text-2xl font-bold mb-4">Create Expense Reports</h1>
      
      <div className="space-y-2">
        <label className="font-bold">Employee</label>
        <Select
          value={String(employeeId)}
          onValueChange={(value) => setEmployeeId(Number(value))}
        >
          <SelectTrigger className="w-full">
            <SelectValue placeholder="Seleziona un dipendente" />
          </SelectTrigger>
          <SelectContent>
            {Object.entries(employees).map(([key, employee]) => (
              <SelectItem key={employee.id} value={employee.id.toString()}>{employee.fullName}</SelectItem>
            ))}
          </SelectContent>
        </Select>
      </div>

      <Button  variant="outline" size="sm" className="w-full" onClick={() => handleCreate()}>
        <IconPlus className="w-5 h-5" />
        <span>Add Expense Report</span>
      </Button>
    </div>
  </Layout>
  )
}
