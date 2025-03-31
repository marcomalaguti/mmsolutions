
"use client"

import Layout from "@/components/layout"
import { useEmployees } from "@/hooks/useEmployees";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Button } from "@/components/ui/button";
import { IconPlus } from "@tabler/icons-react";

export default function Page() {

  const { employees, loading } = useEmployees();

  if (loading) return <p>Loading...</p>;

  return (
    <Layout>
      <div className="p-6">
        <h1 className="text-2xl font-bold mb-4">Employees</h1>

        <Button variant="outline" size="sm">
          <IconPlus />
          <span className="hidden lg:inline">Add Employee</span>
        </Button>

        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Id</TableHead>
              <TableHead>Name</TableHead>
              <TableHead>Email</TableHead>
              <TableHead>Fiscal Code</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {employees.map((employee, index) => (
              <TableRow key={employee.id || index}>
                <TableCell>{employee.id}</TableCell>
                <TableCell>{employee.firstName} {employee.lastName}</TableCell>
                <TableCell>{employee.email}</TableCell>
                <TableCell>{employee.fiscalCode}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    </ Layout>
  )
}
