import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { XHRResponse, Account, Balance } from '../models/index';
import { XHRHelper } from '../helpers/index';
import { environment } from '../../environments/environment';

@Injectable()
export class AccountService {
    //#region Private Fields

    private baseUrl: string = environment.api.url + 'api/account/';

    //#endregion

    //#region Init

    constructor(private http: HttpClient) {

    }

    //#endregion

    //#region Public Methods

    public get(id: string, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.get<XHRResponse<Account>>(this.baseUrl + id)
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    public getBalance(year: number, month: number, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.get<XHRResponse<Balance>>(this.baseUrl + `balance/${year}/${month}`)
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    //#endregion
}