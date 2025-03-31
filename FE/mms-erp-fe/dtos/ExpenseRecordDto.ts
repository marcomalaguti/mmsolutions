

export interface ExpenseRecordDto {
  id: number;
  typeId: number;
  description: string;
  traveledKm?: number | null;
  kmReimbursement?: number | null;
  tolls?: number | null;
  meals?: number | null;
  accommodation?: number | null;
  lumpSum?: number | null;
  pathToAttachment?: string | null;
  date: string;
  total?: number | null;
  file?: File | null;
}
