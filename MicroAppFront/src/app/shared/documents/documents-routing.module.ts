import { AuthGuard } from './../../core/auth/guards/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UploadDocumentComponent } from './components/upload-document/upload-document.component';

const routes: Routes = [
  { path: 'upload-documents', component: UploadDocumentComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class DocumentsRoutingModule {}
