import { Component, OnInit } from '@angular/core';
import { UserAccount } from './user-account';
import { UserAccountService } from './user-account.service';

@Component({
    selector: 'user-account-list',
    template: require('./user-account-list.component.html'),
    providers: [UserAccountService]
})

export class UserAccountListComponent implements OnInit {
    private userAccounts: UserAccount[];

    constructor(private userAccountService: UserAccountService) { }

    public ngOnInit(): void {
        this.userAccountService.getUserAccounts()
            .subscribe((userAccounts: UserAccount[]) => {
                this.userAccounts = userAccounts;
            });
    }
}