"use client"

import Layout from "@/components/layout";
import { Button } from "@/components/ui/button";
import { useExpenseReportDetails } from "@/hooks/useExpenseReports";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Input } from "@/components/ui/input";
import { IconBrandTelegram, IconFileTypeXls, IconTrash } from "@tabler/icons-react";

export default function Page() {
  const {
    expenseReport,
    reportLoading,
    expenseTypes,
    handleDelete,
    handleAddRecord,
    handleFileChange,
    newRecord,
    setNewRecord,
    downloadExcel
  } = useExpenseReportDetails();

  if (reportLoading) return <p>Loading...</p>;

  return (
    <Layout>
      <div className="p-6">
        <Card>
          <CardHeader className="flex items-center justify-between">
            <CardTitle>Expense Report #{expenseReport?.id}</CardTitle>
            <CardTitle>{expenseReport?.label}</CardTitle>
            <CardTitle>State: {expenseReport?.stateDescription}</CardTitle>
          </CardHeader>
          <CardContent className="space-y-4">
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead>Tipo</TableHead>
                  <TableHead>Descrizione</TableHead>
                  <TableHead>KM</TableHead>
                  <TableHead>Rimborso KM</TableHead>
                  <TableHead>Tot Rimborso KM</TableHead>
                  <TableHead>Pedaggi</TableHead>
                  <TableHead>Pasti</TableHead>
                  <TableHead>Alloggio</TableHead>
                  <TableHead>Forfettario</TableHead>
                  <TableHead>Totale</TableHead>
                  <TableHead>Azioni</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {expenseReport?.records.map((record) => (
                  <TableRow key={record.id}>
                    <TableCell>{expenseTypes[record.typeId]}</TableCell>
                    <TableCell>{record.description}</TableCell>
                    <TableCell>{record.traveledKm?.toFixed(2) || "-"}</TableCell>
                    <TableCell>€ {record.kmReimbursement?.toFixed(2) || "-"}</TableCell>
                    <TableCell>€ {((record.kmReimbursement ?? 0) * (record.traveledKm ?? 0)).toFixed(2) || "-"}</TableCell>
                    <TableCell>€ {record.tolls?.toFixed(2) || "-"}</TableCell>
                    <TableCell>€ {record.meals?.toFixed(2) || "-"}</TableCell>
                    <TableCell>€ {record.accommodation?.toFixed(2) || "-"}</TableCell>
                    <TableCell>€ {record.lumpSum?.toFixed(2) || "-"}</TableCell>
                    <TableCell>€ {record.total?.toFixed(2)}</TableCell>
                    <TableCell>
                      <Button variant="destructive" onClick={() => handleDelete(record.id)}>
                        <IconTrash className="h-4 w-4" />
                      </Button>
                    </TableCell>
                  </TableRow>
                ))}
                {/* Aggiunta nuovo record */}
                <TableRow><TableCell><span></span></TableCell></TableRow>
                <TableRow>
                  <TableHead>Tipo</TableHead>
                  <TableHead>Descrizione</TableHead>
                  <TableHead>KM</TableHead>
                  <TableHead>Rimborso KM</TableHead>
                  <TableHead></TableHead>
                  <TableHead>Pedaggi</TableHead>
                  <TableHead>Pasti</TableHead>
                  <TableHead>Alloggio</TableHead>
                  <TableHead>Forfettario</TableHead>
                  <TableHead>Totale</TableHead>
                  <TableHead>Azioni</TableHead>
                </TableRow>
                <TableRow>
                  <TableCell>
                    <Select
                      value={String(newRecord?.typeId ?? "1")}
                      onValueChange={(value) => setNewRecord({ ...newRecord, typeId: Number(value) })}
                    >
                      <SelectTrigger>
                        <SelectValue placeholder="Seleziona un tipo" />
                      </SelectTrigger>
                      <SelectContent>
                        {Object.entries(expenseTypes).map(([key, label]) => (
                          <SelectItem key={key} value={key}>{label}</SelectItem>
                        ))}
                      </SelectContent>
                    </Select>
                  </TableCell>
                  <TableCell>
                    <Input
                      value={newRecord?.description}
                      onChange={(e) => setNewRecord({ ...newRecord, description: e.target.value })}
                    />
                  </TableCell>
                  <TableCell>
                    <Input
                      type="number"
                      value={newRecord?.traveledKm || ""}
                      onChange={(e) => setNewRecord({ ...newRecord, traveledKm: Number(e.target.value) })}
                    />
                  </TableCell>
                  <TableCell>
                    <Input
                      type="number"
                      value={newRecord?.kmReimbursement || ""}
                      onChange={(e) => setNewRecord({ ...newRecord, kmReimbursement: Number(e.target.value) })}
                    />
                  </TableCell>
                  <TableCell></TableCell>
                  <TableCell>
                    <Input
                      type="number"
                      value={newRecord?.tolls || ""}
                      onChange={(e) => setNewRecord({ ...newRecord, tolls: Number(e.target.value) })}
                    />
                  </TableCell>
                  <TableCell>
                    <Input
                      type="number"
                      value={newRecord?.meals || ""}
                      onChange={(e) => setNewRecord({ ...newRecord, meals: Number(e.target.value) })}
                    />
                  </TableCell>
                  <TableCell>
                    <Input
                      type="number"
                      value={newRecord?.accommodation || ""}
                      onChange={(e) => setNewRecord({ ...newRecord, accommodation: Number(e.target.value) })}
                    />
                  </TableCell>
                  <TableCell>
                    <Input
                      type="number"
                      value={newRecord?.lumpSum || ""}
                      onChange={(e) => setNewRecord({ ...newRecord, lumpSum: Number(e.target.value) })}
                    />
                  </TableCell>
                  <TableCell>
                    <Input type="file" onChange={handleFileChange} />
                  </TableCell>
                  <TableCell>
                    <Button onClick={() => handleAddRecord()}>Salva</Button>
                  </TableCell>
                </TableRow>
                <TableRow>
                  <TableCell></TableCell>
                  <TableCell></TableCell>
                  <TableCell>{expenseReport?.records.reduce((sum, record) => sum + (record.traveledKm || 0), 0)}</TableCell>
                  <TableCell></TableCell>
                  <TableCell></TableCell>
                  <TableCell>€ {expenseReport?.records.reduce((sum, record) => sum + (record.tolls || 0), 0).toFixed(2)}</TableCell>
                  <TableCell>€ {expenseReport?.records.reduce((sum, record) => sum + (record.meals || 0), 0).toFixed(2)}</TableCell>
                  <TableCell>€ {expenseReport?.records.reduce((sum, record) => sum + (record.accommodation || 0), 0).toFixed(2)}</TableCell>
                  <TableCell>€ {expenseReport?.records.reduce((sum, record) => sum + (record.lumpSum || 0), 0).toFixed(2)}</TableCell>
                  <TableCell>€ {expenseReport?.records.reduce((sum, record) => sum + (record.total || 0), 0).toFixed(2)}</TableCell>
                  <TableCell></TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </CardContent>
          <CardFooter className="flex items-center justify-between gap-4">
            <Button variant="outline" size="sm" className="flex-1">
              <IconBrandTelegram />
              <span className="hidden lg:inline">Submit</span>
            </Button>
            <Button variant="outline" size="sm" className="flex-1" onClick={() => downloadExcel(expenseReport!.id)}>
              <IconFileTypeXls />
              <span className="hidden lg:inline">Download .xlsx</span>
            </Button>
          </CardFooter>
        </Card>
      </div>
    </Layout>
  );
}
