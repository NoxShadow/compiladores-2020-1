import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StatusBarComponent } from './status-bar/status-bar.component';
import { MessageAreaComponent } from './message-area/message-area.component';
import { MainEditComponent } from './main-edit/main-edit.component';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { ToolBarComponent } from './tool-bar/tool-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    StatusBarComponent,
    MessageAreaComponent,
    MainEditComponent,
    MainScreenComponent,
    ToolBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
