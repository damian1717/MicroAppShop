import { UploadDocumentComponent } from './../../components/common/upload-document/upload-document.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from './../material/material.module';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JwtAngularModule } from '../jwt/jwt-angular.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from 'src/app/_guards/auth/auth.interceptor';
import { TranslateModule } from '../translate/translate.module';

@NgModule({
  declarations: [UploadDocumentComponent],
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    FlexLayoutModule,
    JwtAngularModule,
    TranslateModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    FlexLayoutModule,
    JwtAngularModule,
    TranslateModule,
    UploadDocumentComponent
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ]
})
export class SharedModule {}
