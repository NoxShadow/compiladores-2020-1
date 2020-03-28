import { Component, OnInit, ViewEncapsulation } from '@angular/core';


declare var $: any;


@Component({
  selector: 'app-main-edit',
  templateUrl: './main-edit.component.html',
  styleUrls: ['./main-edit.component.scss', './scripts/jquery-linedtextarea.scss'],
  encapsulation: ViewEncapsulation.None
})
export class MainEditComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    $(".linedtextarea-a").linedtextarea({
      selectedLine: 10,
      selectedClass: 'lineselect'
  });
  }
  

}
