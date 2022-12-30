import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormCadastroComponent } from './components/form-cadastro/form-cadastro.component';
import { FormsModule } from '@angular/forms';
import { FormTelefoneComponent } from './components/form-telefone/form-telefone.component';


@NgModule({
  declarations: [
    AppComponent,
    FormCadastroComponent,
    FormTelefoneComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
