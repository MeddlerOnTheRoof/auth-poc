import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AttackType, UnitType, UserRole } from './lookup-models';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map'

@Injectable()
export class LookupService {
    private baseUrl: string = 'http://localhost:3301/api/Lookups/';

    constructor(private http: Http) { }

    private handleError(error: any): Promise<any> {
        debugger;
        console.error(error);
        return Promise.reject(error.message || error);
    }

    public getAttackTypes(): Observable<AttackType[]> {
        return this.http.get(this.baseUrl + 'AttackTypes')
            .map((response: Response) => <AttackType[]>response.json())
            .catch(this.handleError)
    }

    public getUnitTypes(): Observable<UnitType[]> {
        return this.http.get(this.baseUrl + 'UnitTypes')
            .map((response: Response) => <UnitType[]>response.json())
            .catch(this.handleError)
    }

    public getUserRoles(): Observable<UserRole[]> {
        return this.http.get(this.baseUrl + 'UserRoles')
            .map((response: Response) => <UserRole[]>response.json())
            .catch(this.handleError)
    }
}