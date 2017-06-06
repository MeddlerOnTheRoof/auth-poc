import { ActivatedRoute, Params, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { UserAccount } from './user-account';
import { UserAccountService } from './user-account.service';
import { UserRole } from '../../../shared/lookup-models';
import { LookupService } from '../../../shared/lookup.service';

@Component({
    selector: 'user-account-detail',
    template: require('./user-account-detail.component.html'),
    providers: [LookupService, UserAccountService]
})

export class UserAccountDetailComponent implements OnInit {
    private userAccount: UserAccount;
    private userRoles: UserRole[];

    constructor(private activatedRoute: ActivatedRoute, private lookupService: LookupService, private router: Router, private userAccountService: UserAccountService) { }

    public ngOnInit(): void {
        this.userAccount = new UserAccount();

        this.activatedRoute.params.subscribe((params: Params) => {
            this.userAccount.userAccountId = params['userAccountId'];
        });

        if (this.userAccount.userAccountId > 0) {
            this.userAccountService.getUserAccount(this.userAccount.userAccountId)
                .subscribe((userAccount: UserAccount) => {
                    this.userAccount = userAccount;
                });
        }

        this.lookupService.getUserRoles()
            .subscribe((userRoles: UserRole[]) => {
                this.userRoles = userRoles;
            });
    }

    private submit(): void {
        let user = 'temp_user';

        this.userAccount.modifiedByDate = new Date();
        this.userAccount.modifiedByUser = user;

        if (this.userAccount.userAccountId > 0) {
            this.userAccountService.updateUserAccount(this.userAccount)
                .subscribe((result: any) => {
                    this.router.navigate(['user-account-list']);
                })
        } else {
            this.userAccount.createdByDate = new Date();
            this.userAccount.createdByUser = user;

            this.userAccountService.createUserAccount(this.userAccount)
                .subscribe((id: number) => {
                    this.router.navigate(['user-account-list']);
                })
        }
    }
}