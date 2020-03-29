import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-toolbar-button',
  templateUrl: './toolbar-button.component.html',
  styleUrls: ['./toolbar-button.component.scss']
})
export class ToolbarButtonComponent implements OnInit {

  
  @Input()
  name: String;

  constructor() { }


  ngOnInit(): void {
  }

}
