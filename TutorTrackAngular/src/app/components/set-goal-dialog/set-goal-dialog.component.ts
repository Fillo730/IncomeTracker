//Angular
import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';

//i18n
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'set-goal-dialog-component',
  standalone: true,
  imports: [
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    FormsModule,
    MatButtonModule,
    TranslatePipe
  ],
  templateUrl: './set-goal-dialog.component.html',
  styleUrl: './set-goal-dialog.component.css',
})
export class SetGoalDialogComponent {
  public amount: number;

  constructor(
    public dialogRef: MatDialogRef<SetGoalDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { currentAmount: number }
  ) {
    this.amount = data.currentAmount ?? 0;
  }

  onNoClick() {
    this.dialogRef.close();
  }

  onSaveClick() {
    this.dialogRef.close(this.amount);
  }
}
