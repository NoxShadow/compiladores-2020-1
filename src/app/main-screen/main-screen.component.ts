import { Component, OnInit, ViewChild } from '@angular/core';
import { Event } from '../tool-bar/Event';
import { MainEditComponent } from '../main-edit/main-edit.component';
import { MessageAreaComponent } from '../message-area/message-area.component';
import * as FileSaver from 'file-saver';

const fileInputId = 'openFileInput';

@Component({
  selector: 'app-main-screen',
  templateUrl: './main-screen.component.html',
  styleUrls: ['./main-screen.component.scss']
})
export class MainScreenComponent implements OnInit {

  @ViewChild(MainEditComponent)
  editComponent: MainEditComponent;
  @ViewChild(MessageAreaComponent)
  messageComponent: MessageAreaComponent;

  fileInput: any;

  filePath = '';

  constructor() { }

  ngOnInit(): void {
    this.fileInput = document.getElementById(fileInputId) as HTMLInputElement;
  }

  handleEventReceived(event: Event): void {
    event = + event;
    switch (event) {
      case Event.new:
        this.clearData();
        break;
      case Event.open:
        this.openFileInput();
        break;
      case Event.save:
        this.saveFileContent();
        break;
      case Event.copy:
      case Event.cut:
      case Event.paste:
        this.editComponent.handleTextEvent(event);
        break;
      case Event.compile:
        this.messageComponent.displayContent('Não implementado ainda');
        break;
      case Event.team:
        this.messageComponent.displayContent('Equipe: Debora Crisine Reinert, João Victor Braun Quintino, Nathan Reikdal Cervieri.');
        break;
    }
  }

  handleFileInput() {
    const files = this.fileInput.files;
    if (files && files[0] && files[0].type === 'text/plain') {
      const file = files[0];
      this.clearData();

      const reader = new FileReader();
      reader.readAsText(file, 'UTF-8');
      reader.onload = evt => {
        this.editComponent.code = evt.target.result.toString();
        debugger;
        this.filePath = file.webkitRelativePath;
      };
      reader.onerror = evt => {
        this.messageComponent.displayContent('Erro ao ler arquivo');
      };
    }
  }

  private openFileInput(): void {

    this.fileInput.click();
  }

  private saveFileContent(): void {
    var file = new File([this.editComponent.code], "linguagem.txt", {type: "text/plain;charset=utf-8"});
    FileSaver.saveAs(file);
  }

  private clearData(): void {
    this.filePath = '';

    this.editComponent.clearData();
    this.clearMessage();
  }

  private clearMessage(): void {
    this.messageComponent.clearData();
  }

}
