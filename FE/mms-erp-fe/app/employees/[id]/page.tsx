
"use client"

import Layout from "@/components/layout"
import { useEmployees } from "@/hooks/useEmployees";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Button } from "@/components/ui/button";
import { IconPlus } from "@tabler/icons-react";
import { useParams } from "next/navigation";

export default function Page() {

  const { employeeId } = useParams();


  return (
    <Layout>
      <div className="p-6">
        <h1 className="text-2xl font-bold mb-4">Employee aa {employeeId}</h1>

        
      </div>
    </ Layout>
  )
}
