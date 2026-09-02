//Angular
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgClass } from '@angular/common';

//Angular Material
import { MatIcon } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'; 

//i18n
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'state-handler-component',
  standalone: true,
  imports: [TranslatePipe, NgClass, MatIcon, MatProgressSpinnerModule],
  templateUrl: './state-handler.component.html',
  styleUrl: './state-handler.component.css'
})
export class StateHandlerComponent {
  @Input() type: 'loading' | 'error' | 'empty' = 'loading';

  @Input() title: string = '';
  @Input() message: string = '';
  
  @Input() showButton: boolean = true;
  @Input() buttonLabel!: string; 
  @Input() buttonIcon: string = 'pi pi-refresh';
  @Input() buttonSeverity: any = 'primary';

  @Input() smallSection: boolean = false;
  
  @Output() action = new EventEmitter<void>();

  handleAction() {
    this.action.emit();
  }
}