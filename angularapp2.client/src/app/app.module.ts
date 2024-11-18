import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';  // NgModel használatához
import { HttpClientModule } from '@angular/common/http';  // Importáld a HttpClientModule-ot

import { AppComponent } from './app.component';
import { TerritoryListComponent } from './territory-list/territory-list.component';

@NgModule({
  declarations: [
    AppComponent,
    TerritoryListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,  // Ne felejtsd el hozzáadni
    HttpClientModule  // Az HttpClientModule hozzáadása
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
