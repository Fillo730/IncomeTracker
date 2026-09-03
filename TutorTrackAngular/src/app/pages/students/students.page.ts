import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

// Components
import { StateHandlerComponent } from '../../components/state-handler/state-handler.component';
import { AddUpdateStudentDialogComponent } from '../../components/add-update-student-dialog/add-update-student-dialog.component';
import { StudentCardListComponent } from '../../components/student-card-list/student-card-list.component';

// Models
import { Student } from '../../models/Student';

// i18n
import { TranslateService, TranslatePipe } from '@ngx-translate/core';

// Services
import { StudentService } from '../../services/api/student.service';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'students-page',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    TranslatePipe,
    StateHandlerComponent,
    StudentCardListComponent
  ],
  templateUrl: './students.page.html',
  styleUrl: './students.page.css'
})
export class StudentsPage implements OnInit {
  private studentService = inject(StudentService);
  private toastService = inject(ToastService);
  private translate = inject(TranslateService);
  private dialog = inject(MatDialog);
  private router = inject(Router);

  public isLoading = signal<boolean>(false);
  public isError = signal<boolean>(false);
  public students = signal<Student[]>([]);

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.isLoading.set(true);
    this.isError.set(false);

    this.studentService.getStudents().subscribe({
      next: (res) => {
        if (res.success) {
          this.students.set(res.data);
        }
        this.isLoading.set(false);
      },
      error: () => {
        this.isError.set(true);
        this.isLoading.set(false);
      }
    });
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(AddUpdateStudentDialogComponent, {
      width: '400px',
      data: {
        title: 'Students.Dialog.TitleAdd',
        text: 'Students.Dialog.TextAdd'
      },
      panelClass: 'dialog-with-theme'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.studentService.createStudent(result).subscribe(res => {
          if (res.success) {
            this.loadData();
            this.toastService.success(this.translate.instant('Students.Messages.AddSuccess'));
          }
        });
      }
    });
  }

  onEditStudent(student: Student): void {
    const dialogRef = this.dialog.open(AddUpdateStudentDialogComponent, {
      width: '400px',
      data: {
        student: student,
        title: 'Students.Dialog.TitleUpdate',
        text: 'Students.Dialog.TextUpdate'
      },
      panelClass: 'dialog-with-theme'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.studentService.updateStudent(student.id, result).subscribe(res => {
          if (res.success) {
            this.loadData();
            this.toastService.success(this.translate.instant('Students.Messages.UpdateSuccess'));
          }
        });
      }
    });
  }

  onViewHistory(student: Student): void {
    this.router.navigate(['/add-entry'], { queryParams: { studentId: student.id } });
  }

  onDeleteStudent(id: number): void {
    this.studentService.deleteStudent(id).subscribe(res => {
      if (res.success) {
        this.loadData();
        this.toastService.success(this.translate.instant('Students.Messages.DeleteSuccess'));
      }
    });
  }
}
