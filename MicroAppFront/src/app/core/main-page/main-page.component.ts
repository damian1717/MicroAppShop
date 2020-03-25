import { DocumentService } from '../../shared/documents/services/document.service';
import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  image: any;
  constructor(private documentService: DocumentService, private sanitizer: DomSanitizer) { }

  ngOnInit() {
    /*
    this.documentService.getDocumentByExternalId('6983fcb0-0381-b889-cfce-46543a38daf8').subscribe(
      (data) => {
        console.log(data);
        const objectURL = 'data:image/png;base64,' + data.fileArray;
        this.image = this.sanitizer.bypassSecurityTrustUrl(objectURL);
      },
      (error) => {
        console.log(error);
      }
    )*/
  }

}
