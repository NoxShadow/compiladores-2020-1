import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-message-area',
  templateUrl: './message-area.component.html',
  styleUrls: ['./message-area.component.scss']
})
export class MessageAreaComponent implements OnInit {

  mensagens: string[] = [];

  constructor() { }

  ngOnInit(): void {
  }

  get mensagensDisplay() {
    return this.mensagens.length > 0 ? this.mensagens : ['', '', ''];
  }

}
