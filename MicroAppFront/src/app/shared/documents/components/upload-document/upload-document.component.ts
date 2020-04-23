import { TranslatePipe } from './../../../translate/translate.pipe';
import { BaseComponent } from './../../../../core/base-component/base-component';
import { DocumentService } from '../../services/document.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-upload-document',
  templateUrl: './upload-document.component.html',
  styleUrls: ['./upload-document.component.scss']
})
export class UploadDocumentComponent extends BaseComponent implements OnInit {

  imageUrl = '/assets/img/default-image.png';
  fileToUpload: File = null;
  id: string;
  redirectTo: string;
  constructor(private documentService: DocumentService,
              private route: ActivatedRoute,
              private router: Router,
              private translatePipe: TranslatePipe,
              public snackBar: MatSnackBar ) { super(snackBar); }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.redirectTo = this.route.snapshot.paramMap.get('redirectTo');
  }

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);
    const reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };
    reader.readAsDataURL(this.fileToUpload);
  }

  uploadFile() {
    this.documentService.uploadDocument(this.fileToUpload, this.id).subscribe(
      (success) => {
        this.openSnackBar(this.translatePipe.transform('ADDED_DOCUMENT'), this.COLOR_SNACKBAR_GREEN);
        this.redirectToPreviousPage();
      },
      (error) => {
        console.log(error);
      });
  }

  private redirectToPreviousPage() {
    this.router.navigateByUrl(this.redirectTo);
  }
}
