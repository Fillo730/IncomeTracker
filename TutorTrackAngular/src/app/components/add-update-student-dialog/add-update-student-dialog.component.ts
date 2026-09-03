//Angular
import { Component, OnInit, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';

//i18n
import { TranslatePipe } from '@ngx-translate/core';

//Models
import { Student } from '../../models/Student';

@Component({
  selector: 'add-update-student-dialog-component',
  standalone: true,
  imports: [
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatButtonModule,
    TranslatePipe
  ],
  templateUrl: './add-update-student-dialog.component.html',
  styleUrl: './add-update-student-dialog.component.css',
})
export class AddUpdateStudentDialogComponent implements OnInit {
  public studentUpdate!: Partial<Student>;

  constructor(
    public dialogRef: MatDialogRef<AddUpdateStudentDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      student: Student,
      title: string,
      text: string
    }
  ) {}

  ngOnInit() {
    this.studentUpdate = this.data.student ? { ...this.data.student } : {
      name: ''
    };
  }

  onNoClick() {
    this.dialogRef.close();
  }

  onSaveClick() {
    this.dialogRef.close(this.studentUpdate);
  }
}
