import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';

import { EditorRoutingModule } from './editor-routing.module';

import { EditorComponent } from './components/editor/editor.component';
import { EditorDashboardComponent } from './components/editor-dashboard/editor-dashboard.component';
import { UnitDetailComponent } from './components/unit/unit-detail.component';
import { UnitListComponent } from './components/unit/unit-list.component';

@NgModule({
    bootstrap: [EditorComponent],
    declarations: [
        EditorComponent,
        EditorDashboardComponent,
        UnitDetailComponent,
        UnitListComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        EditorRoutingModule
    ]
})

export class EditorModule { }
