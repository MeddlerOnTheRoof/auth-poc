/*
Description:	CREATE Table dbo.UserAccount
Author:			MeddlerOnTheRoof
Date:			May 25, 2017
*/

begin try
	use authpoc;

	if not exists(
		select 1 from information_schema.tables where 
		table_schema = 'dbo' and table_name = 'UserAccount'
	)
		begin
			create table dbo.UserAccount(
				UserAccountId int identity(1,1) not null,
				UserAccountName varchar(25) not null,
				UserAccountPassword varchar(16) not null,
				UserRoleId int not null,
				CreatedByUserAccount varchar(20) not null,
				CreatedByDate datetime not null,
				ModifiedByUserAccount varchar(20) not null,
				ModifiedByDate datetime not null,
				constraint pk_UserAccount primary key (
					UserAccountId asc
				),
				constraint uq_UserAccount_UserAccountName unique (
					UserAccountName
				)
			)
			print 'dbo.UserAccount CREATED';
		end;
	else
		print 'dbo.UserAccount was already CREATED';

	if not exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_UserAccount_UserRole'
	)
		begin
			alter table dbo.UserAccount with check add constraint fk_UserAccount_UserRole 
			foreign key(UserRoleId) references dbo.UserRole (UserRoleId)

			print 'dbo.fk_UserAccount_UserRole constraint CREATED';
		end;
	else
		print 'dbo.fk_UserAccount_UserRole constraint NOT CREATED';

	if exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_UserAccount_UserRole'
	)
		begin
			alter table dbo.UserAccount check constraint fk_UserAccount_UserRole;

			print 'dbo.fk_UserAccount_UserRole check constraint altered';
		end;
	else
		print 'dbo.fk_UserAccount_UserRole check constraint NOT altered';
end try

begin catch
	declare @errmsg nvarchar(2048);
	declare @errsev int;
	declare @errstate int;

	set @errmsg = 'Error: ' + error_message();
	set @errsev = error_severity();
	set @errstate = error_state();

	raiserror(@errmsg, @errsev, @errstate);
end catch

go