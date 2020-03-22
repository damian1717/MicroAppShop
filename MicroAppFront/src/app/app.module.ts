import { DocumentsModule } from './shared/documents/documents.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/nav/header/header.component';
import { SidenavListComponent } from './core/nav/sidenav-list/sidenav-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MainPageComponent } from './core/main-page/main-page.component';
import { SharedModule } from './shared/shared.module';
import { AuthModule } from './core/auth/auth.module';
import { ProductsModule } from './products/products.module';

@NgModule({
  declarations: [AppComponent, HeaderComponent, SidenavListComponent, MainPageComponent ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    SharedModule,
    AuthModule,
    ProductsModule,
    DocumentsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
