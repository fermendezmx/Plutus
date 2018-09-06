import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { XHRResponse, Receipt, ReceiptCreate, ReceiptUpdate } from '../models/index';
import { XHRHelper } from '../helpers/index';
import { environment } from '../../environments/environment';

@Injectable()
export class ReceiptService {
    //#region Private Fields

    private baseUrl: string = environment.api.url + 'api/receipt/';

    //#endregion

    //#region Init

    constructor(private http: HttpClient) {

    }

    //#endregion

    //#region Public Methods

    public post(receipt: ReceiptCreate, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.post<XHRResponse<Receipt>>(this.baseUrl, receipt)
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    public get(id: number, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.get<XHRResponse<Receipt>>(this.baseUrl + id)
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    public getAllByDate(date: Date, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.get<XHRResponse<Receipt[]>>(this.baseUrl + `detail/${date}`)
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    public getAllBySearch(title: string, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.get<XHRResponse<Receipt[]>>(this.baseUrl + `search/${title}`)
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    public put(receipt: ReceiptUpdate, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.put<XHRResponse<Receipt>>(this.baseUrl, receipt)
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    public delete(id: number, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.delete<XHRResponse<boolean>>(this.baseUrl + id)
            .subscribe(result => {
                XHRHelper.response<boolean>(result, onSuccess, onError);
            });
    }

    //#endregion
}