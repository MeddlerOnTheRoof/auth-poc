import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { UserAccount } from './user-account';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map'

@Injectable()
export class UserAccountService {
    private url: string = 'http://localhost:3301/api/UserAccounts';

    constructor(private http: Http) { }

    private handleError(error: any): Promise<any> {
        debugger;
        console.error(error);
        return Promise.reject(error.message || error);
    }

    public getUserAccounts(): Observable<UserAccount[]> {
        return this.http.get(this.url)
            .map((response: Response) => <UserAccount[]>response.json())
            .catch(this.handleError)
    }

    public getUserAccount(userAccountId: number): Observable<UserAccount> {
        return this.http.get(this.url + userAccountId)
            .map((response: Response) => <UserAccount[]>response.json())
            .catch(this.handleError)
    }

    public createUserAccount(userAccount: UserAccount): Observable<number> {
        return this.http.post(this.url, userAccount)
            .map((response: Response) => {
                let uri = response.headers.get('location');

                let num = uri.replace(/^[\w\d:/?]+userAccountId=/g, "");

                return parseInt(num);
            })
            .catch(this.handleError);
    }

    public updateUserAccount(userAccount: UserAccount): Observable<any> {
        return this.http.put(this.url + userAccount.userAccountId, userAccount)
            .catch(this.handleError);
    }

    public deleteUserAccount(userAccountId: number): Observable<any> {
        return this.http.delete(this.url + userAccountId)
            .catch(this.handleError);
    }
}