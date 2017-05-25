import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Unit } from './unit';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map'

@Injectable()
export class UnitService {
    private url: string = 'http://localhost:3301/api/Units/';

    constructor(private http: Http) { }

    private handleError(error: any): Promise<any> {
        debugger;
        console.error(error);
        return Promise.reject(error.message || error);
    }

    public getUnits(): Observable<Unit[]> {
        return this.http.get(this.url)
            .map((response: Response) => <Unit[]>response.json())
            .catch(this.handleError)
    }

    public getUnit(unitId: number): Observable<Unit> {
        return this.http.get(this.url + unitId)
            .map((response: Response) => <Unit>response.json())
            .catch(this.handleError);
    }

    public createUnit(unit: Unit): Observable<number> {
        return this.http.post(this.url, unit)
            .map((response: Response) => {
                let uri = response.headers.get('location');

                let num = uri.replace(/^[\w\d:/?]+unitId=/g, "");

                return parseInt(num);
            })
            .catch(this.handleError);
    }

    updateUnit(unit: Unit): Observable<any> {
        return this.http.put(this.url + unit.unitId, unit)
        .catch(this.handleError);
    }

    public deleteUnit(unitId: number): Observable<any> {
        return this.http.delete(this.url + unitId)
        .catch(this.handleError);
    }
}