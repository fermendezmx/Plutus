import { Category, Payment } from "../index";

export class Receipt {
    public ReceiptId: number;
    public TransactionDate: Date;
    public Amount: number;
    public Title: string;
    public Description: string;
    public Category: Category;
    public Payment: Payment;
}