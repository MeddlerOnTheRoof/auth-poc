/*
Description:	CREATE Table dbo.UserRole
Author:			MeddlerOnTheRoof
Date:			May 25, 2017
*/

begin try
	use authpoc;

	if not exists(
		select 1 from information_schema.tables where 
		table_schema = 'dbo' and table_name = 'UserRole'
	)
		begin
			create table dbo.UserRole(
				UserRoleId int identity(1,1) not null,
				UserRoleName varchar(25) not null,
				CreatedByUser varchar(20) not null,
				CreatedByDate datetime not null,
				ModifiedByUser varchar(20) not null,
				ModifiedByDate datetime not null,
				constraint pk_UserRole primary key (
					UserRoleId asc
				),
				constraint uq_UserRole_UserRoleName unique (
					UserRoleName
				)
			)

			print 'dbo.UserRole CREATED';
		end;
	else
		print 'dbo.UserRole was already CREATED';
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