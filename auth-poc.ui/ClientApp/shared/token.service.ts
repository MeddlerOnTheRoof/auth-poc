import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/delay';
import 'rxjs/add/operator/do';

@Injectable()
export class TokenService {
    public token: string;
    public userRole: string;
    private exp: Date;
    private authenticated: boolean;

    constructor(private http: Http) { }

    public login(username: string, password: string): Observable<boolean> {
        let now = new Date();

        // num min from now to expire token
        let min = 30;

        this.exp = new Date(now.getTime() + min * 60000);

        this.userRole = username === "admin" ? "admin" : "editor";

        return Observable.of(true).delay(1000).do(val => this.authenticated = true);
    }

    public isExpired(): boolean {
        let now = new Date();

        return !this.authenticated || now > this.exp;
    }

    public logout(): void {
        this.authenticated = false;
    }
}