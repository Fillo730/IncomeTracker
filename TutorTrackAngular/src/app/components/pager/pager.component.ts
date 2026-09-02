import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'pager-component',
  standalone: true,
  imports: [CommonModule, MatPaginatorModule],
  templateUrl: './pager.component.html',
  styleUrl: './pager.component.css'
})
export class PagerComponent {
  @Input() totalItems = 0;
  @Input() pageSize = 10;
  @Input() pageIndex = 0;
  @Input() pageSizeOptions = [5, 10, 25, 50];

  @Output() pageChange = new EventEmitter<PageEvent>();

  handlePageEvent(event: PageEvent) {
    this.pageChange.emit(event);
  }
}