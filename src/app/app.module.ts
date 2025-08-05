import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CounterComponent } from './counter/counter.component';

@NgModule({
  // declarations: [AppComponent, CounterComponent], ❌ REMOVE THIS
  imports: [BrowserModule, AppComponent, CounterComponent], // ✅ USE IMPORTS INSTEAD
  bootstrap: [AppComponent]
})
export class AppModule {}
