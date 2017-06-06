import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { FormsModule } from '@angular/forms';

import { AdminRoutingModule } from './admin-routing.module';

import { AdminComponent } from './components/admin/admin.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { UserAccountDetailComponent } from './components/user-account/user-account-detail.component';
import { UserAccountListComponent } from './components/user-account/user-account-list.component';

@NgModule({
    bootstrap: [ AdminComponent ],
    declarations: [
        AdminComponent,
        AdminDashboardComponent,
        UserAccountDetailComponent,
        UserAccountListComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        AdminRoutingModule
    ]
})

export class AdminModule {

}
