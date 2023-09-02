import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuModule } from 'primeng/menu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MegaMenuModule } from 'primeng/megamenu';
import { MenubarModule } from 'primeng/menubar';
import { HeaderComponent } from './components/header/header/header.component';
import { ContactsListComponent } from './components/contacts-list/contacts-list/contacts-list.component';
import { StoreModule } from '@ngrx/store';
import { counterReducer } from './store/counter.reducer';
import { ContactsBookStore } from './store/reducer.interfaces';
import { EffectsModule } from '@ngrx/effects';
import { CounterEffects } from './store/effects/counter.effects';

@NgModule({
  declarations: [AppComponent, HeaderComponent, ContactsListComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MenuModule,
    MegaMenuModule,
    MenubarModule,
    StoreModule.forRoot<ContactsBookStore>({
      counter: counterReducer,
    }),
    EffectsModule.forRoot([CounterEffects]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
