//Angular
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

//Components
import { StudentCardComponent } from '../student-card/student-card.component';

//Models
import { Student } from '../../models/Student';

@Component({
  selector: 'app-student-card-list',
  standalone: true,
  imports: [CommonModule, StudentCardComponent],
  templateUrl: './student-card-list.component.html',
  styleUrl: './student-card-list.component.css'
})
export class StudentCardListComponent {
  @Input({ required: true }) students: Student[] = [];

  @Output() edit = new EventEmitter<Student>();
  @Output() delete = new EventEmitter<number>();
}
