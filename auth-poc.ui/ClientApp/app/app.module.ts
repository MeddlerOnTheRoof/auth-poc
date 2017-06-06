import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';

import { AdminModule } from '../admin/admin.module';
import { AdminRoutingModule } from '../admin/admin-routing.module';
import { AdminAuthGuard } from '../shared/admin-auth-guard';

import { EditorModule } from '../editor/editor.module';
import { EditorRoutingModule } from '../editor/editor-routing.module';
import { EditorAuthGuard } from '../shared/editor-auth-guard';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { UnuathorizedComponent } from './components/login/unauthorized.component';

import { LoginComponent } from './components/login/login.component';

import { TokenService } from '../shared/token.service';

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent,
        NavMenuComponent,
        UnuathorizedComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        AdminModule,
        AdminRoutingModule,
        EditorModule,
        EditorRoutingModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            { path: 'home', component: HomeComponent },
            { path: 'unauthorized', component: UnuathorizedComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        TokenService,
        AdminAuthGuard,
        EditorAuthGuard
    ]
})

export class AppModule { }
