import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared.module';
import { DocumentsRoutingModule } from './documents-routing.module';
import { UploadDocumentComponent } from './components/upload-document/upload-document.component';

@NgModule({
  declarations: [UploadDocumentComponent],
  imports: [
    ReactiveFormsModule,
    SharedModule,
    DocumentsRoutingModule
  ]
})
export class DocumentsModule {}
