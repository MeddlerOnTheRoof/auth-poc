import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AdminComponent } from './components/admin/admin.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { UserAccountDetailComponent } from './components/user-account/user-account-detail.component';
import { UserAccountListComponent } from './components/user-account/user-account-list.component';

import { AdminAuthGuard } from '../shared/admin-auth-guard';

const adminRoutes: Routes = [
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AdminAuthGuard],
        children: [
            {
                path: '',
                children: [
                    { path: 'user-account-detail', component: UserAccountDetailComponent },
                    { path: 'user-account-list', component: UserAccountListComponent },
                    { path: '', component: AdminDashboardComponent }
                ]
            }
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(adminRoutes)
    ],
    exports: [
        RouterModule
    ]
})

export class AdminRoutingModule { }