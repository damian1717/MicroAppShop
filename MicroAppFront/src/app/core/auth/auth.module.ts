import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { LoginComponent } from 'src/app/core/auth/components/login/login.component';
import { SignUpComponent } from 'src/app/core/auth/components/sign-up/sign-up.component';
import { AuthRoutingModule } from './auth-routing.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [LoginComponent, SignUpComponent ],
  imports: [
    ReactiveFormsModule,
    AuthRoutingModule,
    SharedModule
  ]
})
export class AuthModule {}
