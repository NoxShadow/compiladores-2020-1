import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Event } from './Event';

@Component({
  selector: 'app-tool-bar',
  templateUrl: './tool-bar.component.html',
  styleUrls: ['./tool-bar.component.scss']
})
export class ToolBarComponent implements OnInit {

  events = Event;
  @Output() event = new EventEmitter<Event>();

  constructor() { }

  ngOnInit(): void {
  }

  handleClick(event: Event) {
    this.event.emit(event);
  }

}
