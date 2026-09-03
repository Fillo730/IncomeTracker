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
import { TranslatePipe, TranslateService } from '@ngx-translate/core';

//Models
import { IncomeEntry } from '../../models/IncomeEntry';
import { Student } from '../../models/Student';

//Services
import { StudentService } from '../../services/api/student.service';
import { ToastService } from '../../services/toast.service';

const TUTORING_CATEGORY_KEY = 'TUTORING';

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
  public students: Student[] = [];
  public newStudentName = '';
  public isAddingStudent = false;

  constructor(
    public dialogRef: MatDialogRef<AddUpdateIncomeDialogComponent>,
    private studentService: StudentService,
    private toastService: ToastService,
    private translate: TranslateService,
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
        categoryKey: ''
    };

    this.loadStudents();
  }

  get isTutoringCategory(): boolean {
    return this.incomeUpdate.categoryKey === TUTORING_CATEGORY_KEY;
  }

  loadStudents(): void {
    this.studentService.getStudents().subscribe(res => {
      if (res.success) {
        this.students = res.data;
      }
    });
  }

  onCategoryChange(): void {
    if (!this.isTutoringCategory) {
      this.incomeUpdate.studentId = null;
      this.isAddingStudent = false;
    }
  }

  onAddStudentClick(): void {
    const name = this.newStudentName.trim();

    if (!name) {
      return;
    }

    this.studentService.createStudent({ name }).subscribe(res => {
      if (res.success) {
        this.loadStudents();
        this.incomeUpdate.studentId = res.data.id;
        this.newStudentName = '';
        this.isAddingStudent = false;
        this.toastService.success(this.translate.instant('Students.Messages.AddSuccess'));
      }
    });
  }

  onNoClick() {
    this.dialogRef.close();
  }

  onSaveClick() {
    this.dialogRef.close(this.incomeUpdate);
  }
}