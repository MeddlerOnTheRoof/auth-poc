import { BaseEntity } from '../../../shared/base-entity';

export class UserAccount extends BaseEntity {
    public userAccountId: number;
    public userAccountName: string;
    public userRoleId: number;
    public userRoleName: string;
    public userAccountPassword: string;
}