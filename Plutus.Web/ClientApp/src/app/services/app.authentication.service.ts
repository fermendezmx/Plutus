import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { XHRResponse, Credentials, Token } from '../models/index';
import { XHRHelper } from '../helpers/index';
import { environment } from '../../environments/environment';

@Injectable()
export class AuthenticationService {
    //#region Private Fields

    private baseUrl: string = environment.api.url + 'api/authentication/';

    //#endregion

    //#region Init

    constructor(private http: HttpClient) {

    }

    //#endregion

    //#region Public Methods

    public login(credentials: Credentials, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.post<XHRResponse<Token>>(this.baseUrl + 'login', credentials)
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    //#endregion
}