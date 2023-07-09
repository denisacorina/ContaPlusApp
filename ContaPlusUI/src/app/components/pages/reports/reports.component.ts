import { Component, OnInit } from '@angular/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { MatTableDataSource } from '@angular/material/table';
import html2canvas from 'html2canvas';
import jspdf from 'jspdf';
import { FinancialReportService } from 'src/app/services/financialReport.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
startDate!: any;
endDate!: any;

trialBalanceData: any;
profitLossData: any;
journalEntryData: any;

showPickers!: boolean;
  isProfitLossClicked!: boolean;
  isJournalEntryClicked!: boolean;

  dataSource!: MatTableDataSource<any>;
  trialBalanceColumns: string[] = ['accountName',  'accountCode', 'accountDescription',  'currentBalance',  'accountType', 'lastUpdatedDate'];
  profitLossColumns: string[] = ['accountName',   'accountCode', 'accountDescription', 'amount', 'transactionDate'];
  journalEntryColumns: string[] = ['documentSeries', 'documentNumber',  'transactionAmount', 'paidAmount', 'description', 'debitAccountCode', 'creditAccountCode', 'transactionDate'];
  showTrialBalanceTable!: boolean;
  showProfitLossTable!: boolean;
  isClickedSend!: boolean;

constructor(private financialReportService: FinancialReportService) { }


  ngOnInit(): void {
   
  }


  getTrialBalance() {
    this.financialReportService.getTrialBalanceReport().subscribe((result) => {
      this.trialBalanceData = result;
      this.dataSource = new MatTableDataSource(this.trialBalanceData);
    });
  }

  getProfitLoss() {
    const startDateString = this.startDate.toISOString();
    const endDateString = this.endDate.toISOString();
    this.financialReportService.getProfitLossReport(startDateString, endDateString).subscribe((result) => {
      this.profitLossData = result;
      console.log(this.profitLossData)
    });
  }
  
  getJournalEntry() {
    const startDateString = this.startDate.toISOString();
    const endDateString = this.endDate.toISOString();
    this.financialReportService.getJournalEntryReport(startDateString, endDateString).subscribe((result) => {
      this.journalEntryData = result;
      console.log(this.journalEntryData)
    });
  }

  onClickTrialBalanceButton() {
      this.getTrialBalance();
      this.showPickers = false;
      this.showTrialBalanceTable = true;
      this.showProfitLossTable = false;
      this.isClickedSend = false;
  }

  onClickProfitLossButton() {
      this.showPickers = true;
      this.showProfitLossTable = true;
      this.isProfitLossClicked = true;
      this.isJournalEntryClicked = false;
      this.showTrialBalanceTable = false;
  }

  
  onClickJournalEntryButton() {
      this.showPickers = true;
      this.isJournalEntryClicked = true;
      this.isProfitLossClicked = false;
      this.showTrialBalanceTable = false;
      this.showProfitLossTable = false;
      this.isClickedSend = false;
  }

  onClickSend() {
    if (this.isProfitLossClicked)
      this.getProfitLoss();
    if (this.isJournalEntryClicked)
      this.getJournalEntry();

    this.isClickedSend = true;
  }

  onStartDateChange(event: MatDatepickerInputEvent<Date>) {
    this.startDate = event.value;
  }
  
  onEndDateChange(event: MatDatepickerInputEvent<Date>) {
    this.endDate = event.value;
  }

  formatDate(date: string): string {
    const formattedDate = new Date(date).toLocaleDateString();
    return formattedDate;
  }

  exportToExcelTrialBalance(): void {
    const workbook: XLSX.WorkBook = XLSX.utils.book_new();
    const worksheet: XLSX.WorkSheet = XLSX.utils.table_to_sheet(document.getElementById('table'));
  
    XLSX.utils.book_append_sheet(workbook, worksheet, 'TrialBalanceReport');

    const title = [['Trial Balance Report']];
    const currentDate = new Date().toLocaleDateString();
    const dateRow = [['Generated at '+ currentDate]];
  
    XLSX.utils.sheet_add_aoa(worksheet, title, { origin: 'H1' });
    XLSX.utils.sheet_add_aoa(worksheet, dateRow, { origin: 'H2' });

    XLSX.writeFile(workbook, 'TrialBalanceReport.xlsx');
  }

  exportToExcelProfit(): void {
    const workbook: XLSX.WorkBook = XLSX.utils.book_new();
    const worksheet: XLSX.WorkSheet = XLSX.utils.table_to_sheet(document.getElementById('profittable'));
  
    XLSX.utils.book_append_sheet(workbook, worksheet, 'TrialBalanceReport');

    const info = [['Profit Loss Report'], ['Start Date ' + this.startDate.toLocaleDateString()], ['End Date ' + this.endDate.toLocaleDateString()]];
    const incomeTotal = [['Income TOTAL: '+ this.profitLossData.incomeTotal]];
    const expenseTotal = [['Expense TOTAL: '+ this.profitLossData.expenseTotal]];
    const profitLoss = [['Profit Loss TOTAL: '+ this.profitLossData.profitLoss]];

    const currentDate = new Date().toLocaleDateString();
    const dateRow = [['Generated at '+ currentDate]];
  
    XLSX.utils.sheet_add_aoa(worksheet, info, { origin: 'H1' });
    XLSX.utils.sheet_add_aoa(worksheet, dateRow, { origin: 'K1' });

    XLSX.utils.sheet_add_aoa(worksheet, incomeTotal, { origin: 'H6' });
    XLSX.utils.sheet_add_aoa(worksheet, expenseTotal, { origin: 'H7' });
    XLSX.utils.sheet_add_aoa(worksheet, profitLoss, { origin: 'H8' });

    XLSX.writeFile(workbook, 'TrialBalanceReport.xlsx');
  }

  
  exportToExcelJournalEntry(): void {
    const workbook: XLSX.WorkBook = XLSX.utils.book_new();
    const worksheet: XLSX.WorkSheet = XLSX.utils.table_to_sheet(document.getElementById('journalEntryTable'));
  
    XLSX.utils.book_append_sheet(workbook, worksheet, 'JournalEntryReport');

    const info = [['Journal Entry Report'], ['Start Date ' + this.startDate.toLocaleDateString()], ['End Date ' + this.endDate.toLocaleDateString()]];
    const currentDate = new Date().toLocaleDateString();
    const dateRow = [['Generated at '+ currentDate]];
  
    XLSX.utils.sheet_add_aoa(worksheet, info, { origin: 'J1' });
   
    XLSX.utils.sheet_add_aoa(worksheet, dateRow, { origin: 'M1' });

    XLSX.writeFile(workbook, 'JournalEntryReport.xlsx');
  }

  exportProfitToPdf(): void {
    const currentDate = new Date().toLocaleDateString();
    const element = document.getElementById('profittable');
    const title = 'Profit Loss Report ' + ' ' + ' Start Date ' + this.startDate.toLocaleDateString()  + ' - ' + 'End Date ' + this.endDate.toLocaleDateString();
   
    const details = 'Generated at '+ currentDate;
  
    if(element)
    html2canvas(element).then((canvas) => {
      const imgData = canvas.toDataURL('image/png');
      const doc = new jspdf('l', 'mm', 'a4');
      const imgWidth = 200;
      const pageHeight = 297;
      const imgHeight = (canvas.height * imgWidth) / canvas.width;
      let heightLeft = imgHeight;
      let position = 0;
      doc.setFontSize(16);
      doc.text(title, 10, 10); 
      doc.setFontSize(12);
      doc.text(details, 10, 20); 
  
      doc.addImage(imgData, 'PNG', 35,  30, imgWidth, imgHeight); 
   

      heightLeft -= pageHeight;
  
      while (heightLeft >= 0) {
        position = heightLeft - imgHeight;
        doc.addPage();
        doc.addImage(imgData, 'PNG', 35, 30, imgWidth, imgHeight); 
        heightLeft -= pageHeight;
      }
  
      doc.save('data.pdf');
    });
  }

  exportJournalEntryToPdf(): void {
    const currentDate = new Date().toLocaleDateString();
    const element = document.getElementById('journalEntryTable');
    const title = 'Journal Entry Report ' + ' ' + ' Start Date ' + this.startDate.toLocaleDateString()  + ' - ' + 'End Date ' + this.endDate.toLocaleDateString();
   
    const details = 'Generated at '+ currentDate;
  
    if(element)
    html2canvas(element).then((canvas) => {
      const imgData = canvas.toDataURL('image/png');
      const doc = new jspdf('l', 'mm', 'a4');
      const imgWidth = 200;
      const pageHeight = 297;
      const imgHeight = (canvas.height * imgWidth) / canvas.width;
      let heightLeft = imgHeight;
      let position = 0;
      doc.setFontSize(16);
      doc.text(title, 10, 10); 
      doc.setFontSize(12);
      doc.text(details, 10, 20); 
  
      doc.addImage(imgData, 'PNG', 35,  30, imgWidth, imgHeight); 
   

      heightLeft -= pageHeight;
  
      while (heightLeft >= 0) {
        position = heightLeft - imgHeight;
        doc.addPage();
        doc.addImage(imgData, 'PNG', 35, 30, imgWidth, imgHeight); 
        heightLeft -= pageHeight;
      }
  
      doc.save('data.pdf');
    });
  }
  
  

  exportTrialBalanceToPdf(): void {
    const currentDate = new Date().toLocaleDateString();
    const element = document.getElementById('table');
    const title = 'Trial Balance Report';
    const details = 'Generated at '+ currentDate;
  
    if(element)
    html2canvas(element).then((canvas) => {
      const imgData = canvas.toDataURL('image/png');
      const doc = new jspdf('l', 'mm', 'a4');
      const imgWidth = 200;
      const pageHeight = 297;
      const imgHeight = (canvas.height * imgWidth) / canvas.width;
      let heightLeft = imgHeight;
      let position = 0;
      doc.setFontSize(16);
      doc.text(title, 10, 10); 
      doc.setFontSize(12);
      doc.text(details, 10, 20); 
  
      doc.addImage(imgData, 'PNG', 35,  30, imgWidth, imgHeight); 
   

      heightLeft -= pageHeight;
  
      while (heightLeft >= 0) {
        position = heightLeft - imgHeight;
        doc.addPage();
        doc.addImage(imgData, 'PNG', 35, 30, imgWidth, imgHeight); 
        heightLeft -= pageHeight;
      }
  
      doc.save('data.pdf');
    });
  }
}  
