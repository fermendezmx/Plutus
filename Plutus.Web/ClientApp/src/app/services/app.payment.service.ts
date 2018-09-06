import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { XHRResponse, Payment } from '../models/index';
import { XHRHelper } from '../helpers/index';
import { environment } from '../../environments/environment';

@Injectable()
export class PaymentService {
    //#region Private Fields

    private baseUrl: string = environment.api.url + 'api/payment/';

    //#endregion

    //#region Init

    constructor(private http: HttpClient) {

    }

    //#endregion

    //#region Public Methods

    public getAll(onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.get<XHRResponse<Payment[]>>(this.baseUrl + 'all')
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    //#endregion
}