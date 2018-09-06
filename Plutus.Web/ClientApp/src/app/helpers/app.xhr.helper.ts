import { XHRResponse } from "../models/index";

export class XHRHelper {
    //#region Public Methods

    public static response<T>(result: XHRResponse<T>, onSuccess: (data: any) => void, onError: (error: any) => void): void {
        if (result.Succeeded) {
            onSuccess(result.Data);
        } else {
            onError(result.Message);
        }
    }

    //#endregion
}