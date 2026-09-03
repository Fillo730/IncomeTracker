//Angular
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';

//Models
import { Student } from '../../models/Student';

@Component({
  selector: 'app-student-card',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule
  ],
  templateUrl: './student-card.component.html',
  styleUrl: './student-card.component.css',
})
export class StudentCardComponent {
  @Input({ required: true }) student!: Student;

  @Output() edit = new EventEmitter<Student>();
  @Output() delete = new EventEmitter<number>();

  onEdit() {
    this.edit.emit(this.student);
  }

  onDelete() {
    this.delete.emit(this.student.id);
  }
}
