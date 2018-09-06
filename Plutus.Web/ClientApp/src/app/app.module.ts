//#region Modules

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './modules/index';

//#endregion

//#region Components

import {
    AppComponent, NavMenuComponent, HomeComponent,
    CounterComponent, FetchDataComponent
} from './components/index';

//#endregion

//#region Services

import {
    AccountService, AuthenticationService, CategoryService,
    PaymentService, ReceiptService
} from './services/index';

//#endregion

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        AppRoutingModule
    ],
    providers: [
        AccountService,
        AuthenticationService,
        CategoryService,
        PaymentService,
        ReceiptService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
