import { DocumentService } from '../../shared/documents/services/document.service';
import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  constructor(private documentService: DocumentService, private sanitizer: DomSanitizer) { }

  ngOnInit() {
  }
}
