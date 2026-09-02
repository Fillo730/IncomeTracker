//Angular
import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { NgClass } from '@angular/common';

//Pipes
import { DecimalPipe } from '@angular/common';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'stat-card-component',
  imports: [MatCardModule, MatIconModule, NgClass, CurrencyPipe,DecimalPipe],
  templateUrl: './stat-card.component.html',
  styleUrl: './stat-card.component.css',
})
export class StatCardComponent {
  @Input() value !: number;
  @Input() colorClass : 'blue' | 'orange' | 'green' | 'purple' = 'blue';
  @Input() icon !: string;
  @Input() label !: string;
  @Input() isLabelCurrency : boolean = false;
}