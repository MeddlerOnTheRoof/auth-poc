import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { UnitService } from './components/unit/unit.service';
import { UnitListComponent } from './components/unit/unit-list.component';
import { UnitDetailComponent } from './components/unit/unit-detail.component';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        UnitListComponent,
        UnitDetailComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'unit-list', component: UnitListComponent },
            { path: 'unit-detail', component: UnitDetailComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
