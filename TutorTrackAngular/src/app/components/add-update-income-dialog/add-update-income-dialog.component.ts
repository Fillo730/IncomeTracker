//Angular
import { Component, OnInit, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

//i18n
import { TranslatePipe } from '@ngx-translate/core';

//Models
import { IncomeEntry } from '../../models/IncomeEntry';
import { INCOME_ENTRY_TYPES } from '../../models/types/IncomeEntryType';

@Component({
  selector: 'add-income-dialog-component',
  standalone: true,
  imports: [
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    MatIconModule,
    MatDatepickerModule,
    MatNativeDateModule,
    FormsModule,
    MatButtonModule,
    TranslatePipe
  ],
  templateUrl: './add-update-income-dialog.component.html',
  styleUrl: './add-update-income-dialog.component.css',
})
export class AddUpdateIncomeDialogComponent implements OnInit {
  public incomeUpdate!: Partial<IncomeEntry>;
  
  constructor(
    public dialogRef: MatDialogRef<AddUpdateIncomeDialogComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: {
      income: IncomeEntry,
      categories: any[],
      title: string,
      text: string,
      cancelButtonLabel: string,
      successButtonLabel: string
    }
  ) {}

  ngOnInit() {
    this.incomeUpdate = this.data.income ? { ...this.data.income } : {
        amount: 0,
        hours: 0,
        date: new Date(),
        description: '',
        type: INCOME_ENTRY_TYPES.OTHER
    };
  }

  onNoClick() {
    this.dialogRef.close();
  }

  onSaveClick() {
    this.dialogRef.close(this.incomeUpdate);
  }
}