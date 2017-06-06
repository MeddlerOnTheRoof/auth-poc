import { Component, OnInit, Injectable } from '@angular/core';
import { Unit } from './unit';
import { UnitService } from './unit.service';

@Component({
    selector: 'unit-list',
    template: require('./unit-list.component.html'),
    providers: [UnitService]
})

@Injectable()
export class UnitListComponent implements OnInit {
    private units: Unit[];

    constructor(private unitService: UnitService) { }

    public ngOnInit(): void {
        this.loadUnits();
    }

    private delete(unitId: number): void {
        this.unitService.deleteUnit(unitId)
            .subscribe(() => {
                this.loadUnits();
            });
    }

    private loadUnits(): void {
        this.unitService.getUnits()
            .subscribe((units: Unit[]) => {
                this.units = units;
            });
    }
}