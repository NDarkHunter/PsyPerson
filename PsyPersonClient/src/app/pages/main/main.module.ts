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
    ],
  exports: [MainComponent]
})
export class MainModule { }