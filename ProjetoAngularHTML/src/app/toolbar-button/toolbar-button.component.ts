import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Event } from '../tool-bar/Event';

@Component({
  selector: 'app-toolbar-button',
  templateUrl: './toolbar-button.component.html',
  styleUrls: ['./toolbar-button.component.scss']
})
export class ToolbarButtonComponent implements OnInit {

  @Input() name = '';
  @Input() faIcon = '';
  @Input() event: Event;
  @Output() clicked = new EventEmitter<Event>();

  constructor() { }

  ngOnInit(): void {
  }

  emitEvent() {
    this.clicked.emit(this.event);
  }

}
