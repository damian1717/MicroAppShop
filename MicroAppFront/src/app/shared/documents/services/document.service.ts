import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Document } from '../models/document';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {
  private baseUrl = environment.apiUrl + 'documents';

  constructor(private http: HttpClient) { }

  uploadDocument(fileToUpload: File, id: string) {
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    formData.append('Guid', id);
    return this.http.post(this.baseUrl, formData);
  }

  getDocument(id: string) {
    return this.http.get<Document>(`${this.baseUrl}/${id}`);
  }
}
