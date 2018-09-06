export class StorageHelper {
    //#region Public Methods

    public static set(key: string, value: any): void {
        if (typeof (value) == 'object') {
            value = JSON.stringify(value);
        }

        localStorage.setItem(key, value);
    }

    public static get(key: string): any {
        let result = localStorage.getItem(key);

        try {
            result = JSON.parse(result || '');
        } catch (ex) {
            // NOP
        }

        return result;
    }

    //#endregion
}