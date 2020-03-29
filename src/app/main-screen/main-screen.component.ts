import { Component, OnInit, ViewChild } from '@angular/core';
import { Event } from '../tool-bar/Event';
import { MainEditComponent } from '../main-edit/main-edit.component';
import { MessageAreaComponent } from '../message-area/message-area.component';

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

  filePath = '';

  constructor() { }

  ngOnInit(): void {
  }

  handleEventReceived(event: Event): void {
    event = + event;
    switch (event) {
      case Event.new:
        this.clearData();
        break;
      case Event.open:
        this.openFileInput(false);
        break;
      case Event.save:
        if (this.filePath !== '') {
          this.saveFileContent();
        } else {
          this.getFileDirectory();
        }
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

  private openFileInput(isDirectory: boolean): void {
    if (isDirectory) {
      this.getFileDirectory();
    }
  }

  private getFileDirectory(): void {

  }

  private saveFileContent(): void {

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
