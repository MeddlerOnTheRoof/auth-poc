import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EditorComponent } from './components/editor/editor.component';
import { EditorDashboardComponent } from './components/editor-dashboard/editor-dashboard.component';
import { UnitDetailComponent } from './components/unit/unit-detail.component';
import { UnitListComponent } from './components/unit/unit-list.component';

import { EditorAuthGuard } from '../shared/editor-auth-guard';

const editorRoutes: Routes = [
    {
        path: 'editor',
        component: EditorComponent,
        canActivate: [EditorAuthGuard],
        children: [
            {
                path: '',
                children: [
                    { path: 'unit-detail', component: UnitDetailComponent },
                    { path: 'unit-list', component: UnitListComponent },
                    { path: '', component: EditorDashboardComponent }
                ]
            }
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(editorRoutes)
    ],
    exports: [
        RouterModule
    ]
})

export class EditorRoutingModule { }