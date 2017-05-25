import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { UnitType } from '../models/lookup-models';
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

    public getUnitTypes(): Observable<UnitType[]> {
        return this.http.get(this.baseUrl + 'UnitTypes')
            .map((response: Response) => <UnitType[]>response.json())
            .catch(this.handleError)
    }
}