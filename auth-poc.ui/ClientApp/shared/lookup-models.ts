import { BaseEntity } from './base-entity';

export class ArmorType extends BaseEntity {
    public armorTypeId: number;
    public armorTypeName: string;
}

export class AttackType extends BaseEntity {
    public attackTypeId: number;
    public attackTypeName: string;
    public armorTypeId: number;
    public armorTypeName: string;
}

export class UnitType extends BaseEntity {
    public unitTypeId: number;
    public unitTypeName: string;
}

export class UserRole extends BaseEntity {
    public userRoleId: number;
    public userRoleName: string;
}