//#region Modules

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//#endregion

//#region Components

import {
    HomeComponent, CounterComponent, FetchDataComponent
} from '../components/index';

//#endregion

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }