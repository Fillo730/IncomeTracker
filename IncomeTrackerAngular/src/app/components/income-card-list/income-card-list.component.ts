//Angular
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

//Components
import { IncomeCardComponent } from '../income-card/income-card.component';

//Models
import { IncomeEntry } from '../../models/IncomeEntry';

@Component({
  selector: 'app-income-card-list',
  standalone: true,
  imports: [CommonModule, IncomeCardComponent],
  templateUrl: './income-card-list.component.html',
  styleUrl: './income-card-list.component.css'
})
export class IncomeCardListComponent {
  @Input({ required: true }) incomes: IncomeEntry[] = [];
  
  @Output() edit = new EventEmitter<IncomeEntry>();
  @Output() delete = new EventEmitter<number>();
}