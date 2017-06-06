import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { TokenService } from './token.service';
//import { Observable } from 'rxjs/Observable';

@Injectable()
export class AdminAuthGuard implements CanActivate {
    constructor(private tokenService: TokenService, private router: Router) { }

    public canActivate(): boolean {
        let authorized = this.tokenService.userRole === "admin";
        let tokenExpired = this.tokenService.isExpired();

        if (tokenExpired) {
            this.router.navigate(['/login']);
            return false;
        }

        if (!authorized) {
            this.router.navigate(['/unauthorized']);
            return false;
        }

        return true;
    }
}