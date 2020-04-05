import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-message-area',
  templateUrl: './message-area.component.html',
  styleUrls: ['./message-area.component.scss']
})
export class MessageAreaComponent implements OnInit {

  mensagem = '';

  constructor() { }

  ngOnInit(): void {
  }

  displayContent(content: string) {
    this.mensagem = content;
  }

  get mensagemDisplay() {
    return this.mensagem;
  }

  clearData() {
    this.mensagem = '';
  }

}
