import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-employee-card',
  templateUrl: './employee-card.component.html',
  styleUrl: './employee-card.component.scss'
})
export class EmployeeCardComponent {
  @Input() firstName!: string;
  @Input() lastName!: string;

  @Output() remove = new EventEmitter<void>()

  onRemove() {
    this.remove.emit();
  }
}
