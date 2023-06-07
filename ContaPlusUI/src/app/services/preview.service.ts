import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PreviewService {
  private htmlContent!: string;

  constructor() { }

  setHtmlContent(content: string) {
    this.htmlContent = content;
  }

  getHtmlContent() {
    return this.htmlContent;
  }
}