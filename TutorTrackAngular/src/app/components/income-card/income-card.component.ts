//Angular
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule, CurrencyPipe, DatePipe } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';

//Models
import { IncomeEntry } from '../../models/IncomeEntry';

@Component({
  selector: 'app-income-card',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
    CurrencyPipe,
    DatePipe
  ],
  templateUrl: './income-card.component.html',
  styleUrl: './income-card.component.css',
})
export class IncomeCardComponent {
  @Input({ required: true }) income!: IncomeEntry;
  
  @Output() edit = new EventEmitter<IncomeEntry>();
  @Output() delete = new EventEmitter<number>();

  onEdit() {
    this.edit.emit(this.income);
  }

  onDelete() {
    this.delete.emit(this.income.id);
  }
}