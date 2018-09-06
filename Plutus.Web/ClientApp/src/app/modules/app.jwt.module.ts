import { NgModule } from '@angular/core';
import { StorageHelper } from '../helpers/index';
import { JwtModule, JwtModuleOptions } from '@auth0/angular-jwt';
import { environment } from '../../environments/environment';

const options: JwtModuleOptions = {
    config: {
        tokenGetter: () => {
            return StorageHelper.get('id_token');
        },
        whitelistedDomains: [
            environment.api.domain
        ]
    }
};

@NgModule({
    imports: [JwtModule.forRoot(options)],
    exports: [JwtModule]
})
export class AppJwtModule { }