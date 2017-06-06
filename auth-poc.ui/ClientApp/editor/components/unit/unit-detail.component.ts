import { ActivatedRoute, Params, Router } from '@angular/router';
import { Component, OnInit, Injectable } from '@angular/core';
import { Unit } from './unit';
import { UnitService } from './unit.service';
import { AttackType, UnitType } from '../../../shared/lookup-models';
import { LookupService } from '../../../shared/lookup.service';

@Component({
    selector: 'unit-detail',
    template: require('./unit-detail.component.html'),
    providers: [LookupService, UnitService]
})

@Injectable()
export class UnitDetailComponent implements OnInit {
    private attackTypes: AttackType[];
    private unit: Unit;
    private unitTypes: UnitType[];

    constructor(private activetedRoute: ActivatedRoute, private lookupService: LookupService, private unitService: UnitService, private router: Router) { }

    public ngOnInit(): void {
        this.unit = new Unit();

        this.activetedRoute.params.subscribe((params: Params) => {
            this.unit.unitId = params['unitId'];
        });

        if (this.unit.unitId > 0) {
            this.unitService.getUnit(this.unit.unitId)
                .subscribe((unit: Unit) => {
                    this.unit = unit;
                });
        } else {
            this.unit.food = 0;
            this.unit.wood = 0;
            this.unit.gold = 0;
            this.unit.stone = 0;
            this.unit.moveSpeed = 0;
            this.unit.lineOfSight = 0;
            this.unit.moveSpeed = 0;
            this.unit.health = 0;
        }

        this.lookupService.getUnitTypes()
            .subscribe((unitTypes: UnitType[]) => {
                this.unitTypes = unitTypes;
            });

        this.lookupService.getAttackTypes()
            .subscribe((attackTypes: AttackType[]) => {
                this.attackTypes = attackTypes;
            });
    }

    private submit(): void {
        let user = 'temp_user';

        this.unit.modifiedByUser = user;
        this.unit.modifiedByDate = new Date();

        if (this.unit.unitId > 0) {
            this.unitService.updateUnit(this.unit)
                .subscribe((id: number) => {
                    this.router.navigate(['', {}]);
                });
        } else {
            this.unit.createdByUser = user;
            this.unit.createdByDate = new Date();

            this.unitService.createUnit(this.unit)
                .subscribe((id: number) => {
                    this.router.navigate(['', {}]);
                });
        }
    }
}