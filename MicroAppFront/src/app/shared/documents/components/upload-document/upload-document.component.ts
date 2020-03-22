import { DocumentService } from '../../services/document.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-upload-document',
  templateUrl: './upload-document.component.html',
  styleUrls: ['./upload-document.component.scss']
})
export class UploadDocumentComponent implements OnInit {

  imageUrl = '/assets/img/default-image.png';
  fileToUpload: File = null;
  id: string;
  redirectTo: string;
  constructor(private documentService: DocumentService, private route: ActivatedRoute, private router: Router) { }

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
