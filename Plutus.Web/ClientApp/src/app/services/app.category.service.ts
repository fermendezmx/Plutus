import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { XHRResponse, Category } from '../models/index';
import { XHRHelper } from '../helpers/index';
import { environment } from '../../environments/environment';

@Injectable()
export class CategoryService {
    //#region Private Fields

    private baseUrl: string = environment.api.url + 'api/category/';

    //#endregion

    //#region Init

    constructor(private http: HttpClient) {

    }

    //#endregion

    //#region Public Methods

    public getAll(typeId: string, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        this.http.get<XHRResponse<Category[]>>(this.baseUrl + typeId)
            .subscribe(result => {
                XHRHelper.response(result, onSuccess, onError);
            });
    }

    //#endregion
}