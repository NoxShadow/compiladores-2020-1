import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TelaPrincipalComponent } from './tela-principal/tela-principal.component';
import { BarraStatusComponent } from './barra-status/barra-status.component';
import { AreaMensagemComponent } from './area-mensagem/area-mensagem.component';
import { StatusBarComponent } from './status-bar/status-bar.component';
import { MessageAresComponent } from './message-ares/message-ares.component';
import { MessageAreaComponent } from './message-area/message-area.component';
import { MainEditComponent } from './main-edit/main-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    TelaPrincipalComponent,
    BarraStatusComponent,
    AreaMensagemComponent,
    StatusBarComponent,
    MessageAresComponent,
    MessageAreaComponent,
    MainEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
