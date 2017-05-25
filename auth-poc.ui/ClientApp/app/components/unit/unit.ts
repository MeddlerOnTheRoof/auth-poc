import { BaseEntity } from '../../models/base-entity';

export class Unit extends BaseEntity {
    public unitId: number;
    public unitName: string;
    public unitTypeId: number;
    public unitTypeName: string;
    public food: number;
    public gold: number;
    public stone: number;
    public wood: number;
    public buildTime: string; // how to translate time into something easy to understand in ts
    public moveSpeed: number;
    public lineOfSight: number;
    public health: number;
    public attackRange: number;
    public attack: number;
    public attackTypeId: number;
    public attackTypeName: string;
    public attackSpeed: number;

}