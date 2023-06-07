import { Component, Input } from '@angular/core';
import { PreviewService } from 'src/app/services/preview.service';

@Component({
  selector: 'app-preview-document',
  templateUrl: './preview-document.component.html',
  styleUrls: ['./preview-document.component.css'],
 
})
export class PreviewDocumentComponent {
  htmlContent!: string;

  constructor(private previewService: PreviewService) { }

  ngOnInit() {
    this.htmlContent = this.previewService.getHtmlContent();
  }
}

