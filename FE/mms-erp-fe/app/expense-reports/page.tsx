
"use client"

import Layout from "@/components/layout"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Button } from "@/components/ui/button";
import { IconEdit, IconPlus } from "@tabler/icons-react";
import { useExpenseReports } from "@/hooks/useExpenseReports";
import Link from "next/link";

export default function Page() {

  const { expenseReports, loading } = useExpenseReports();

  if (loading) return <p>Loading...</p>;

  return (
    <Layout>
      <div className="p-6">
        <h1 className="text-2xl font-bold mb-4">Expense Reports</h1>

        <Button variant="outline" size="sm">
          <IconPlus />
          <span className="hidden lg:inline">Add Expense Report</span>
        </Button>

        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Label</TableHead>
              <TableHead>Employee</TableHead>
              <TableHead>Amount</TableHead>
              <TableHead>State</TableHead>
              <TableHead>Details</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {expenseReports.map((expenseReport, index) => (
              <TableRow key={expenseReport.id || index}>
                <TableCell>{expenseReport.label}</TableCell>
                <TableCell>{expenseReport.employeeName}</TableCell>
                <TableCell>€ {expenseReport.total}</TableCell>
                <TableCell>{expenseReport.stateDescription}</TableCell>
                <TableCell>
                  <Link href={`/expense-reports/${expenseReport.id}`} passHref>
                    <Button variant="outline" size="sm">
                      <IconEdit />
                    </Button>
                  </Link>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    </ Layout>
  )
}
