import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { ModalModule } from 'ngx-bootstrap/modal';

import { MainComponent } from './main.component';
import { MainRoutingModule } from './main-routing.module';
import { TestsComponent } from './tests/tests.component';
import { FileUploadComponent } from './common/file-upload/file-upload.component';
import { CreateOrEditTestModalComponent } from './tests/create-or-edit-test-modal/create-or-edit-test-modal.component';
import {FieldsetModule} from 'primeng/fieldset';
import { TestQuestionsComponent } from './tests/test-questions/test-questions.component';
import { CreateOrEditTestQuestionModalComponent } from './tests/test-questions/create-or-edit-test-question/create-or-edit-test-question.component';
import { CreateTestQuestionsFromFileModalComponent } from './tests/test-questions/create-test-questions-from-file/create-test-questions-from-file.component';
import { FileDownloadComponent } from './common/file-download/file-download.component';

@NgModule({
  imports: [
      MainRoutingModule, 
      SharedModule,
      CommonModule,
      FieldsetModule,
      ModalModule.forRoot(),
    ],
  declarations: [
      MainComponent,
      TestsComponent,
      CreateOrEditTestModalComponent,
      FileUploadComponent,
      TestQuestionsComponent,
      CreateOrEditTestQuestionModalComponent,
      CreateTestQuestionsFromFileModalComponent,
      FileDownloadComponent,
    ],
  exports: [MainComponent]
})
export class MainModule { }