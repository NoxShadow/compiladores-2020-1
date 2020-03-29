import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Event } from '../tool-bar/Event';

declare var $: any;

@Component({
  selector: 'app-main-edit',
  templateUrl: './main-edit.component.html',
  styleUrls: ['./main-edit.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class MainEditComponent implements OnInit {

  code = '';

  constructor() { }

  ngOnInit(): void {
    $('.linedtextarea-a').linedtextarea({
      selectedLine: 10,
      selectedClass: 'lineselect'
    });
  }

  handleTextEvent(event: Event) {
    console.log('test event log: ' + event);
  }

  clearData() {
    this.code = '';
  }

  setCode(value: string){
    this.code = value; 
  }

}
