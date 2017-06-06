import { AppComponent } from '../app/app.component';
import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from '../../../shared/token.service';

//import { NavMenuComponent } from '../navmenu/navmenu.component';

@Component({
    selector: 'login',
    template: require('./login.component.html')
})

export class LoginComponent implements OnInit {
    private username: string;
    private password: string;
    private redirectUrl: string;

    constructor(private router: Router, private tokenService: TokenService) { }

    public ngOnInit(): void {

    }

    private submit(): void {
        this.tokenService.login(this.username, this.password)
            .subscribe(() => {
                let redirect = this.redirectUrl ? this.redirectUrl : '/home';

                // change to go to the creation page
                this.router.navigate([redirect]);
            })
    }
}