import { NgModule } from '@angular/core';
import { JwtModule } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  imports: [
    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: [environment.apiUrl],
        blacklistedRoutes: [environment.apiUrl + 'identity']
      }
    })
  ]
})
export class JwtAngularModule { }
