/*
Description:	INSERT Table dbo.UserRole
Author:			MeddlerOnTheRoof
Date:			May 25, 2017

Role Description
admin				:: can do everything all other users can and perform CRUD operations on users (also delete rights on others' records)
content_creator		:: fulls rights to records they've created and rights to edit records others have created
content_contributor	:: full rights to content they've created and rights to consume but not modify records others have created
content_consumer	:: rights to view all content but not create, update, or delete
*/

begin try
	use authpoc;

	if not exists(select 1 from dbo.UserRole)
		begin
			declare @user char(8);
			declare @date datetime;

			set @user = 'system';
			set @date = getdate();

			set identity_insert dbo.UserRole on;

			insert into dbo.UserRole (UserRoleId, UserRoleName, CreatedByUser, CreatedByDate, ModifiedByUser, ModifiedByDate)
			values 
				(1, 'Admin', @user, @date, @user, @date),
				(2, 'Content Creator', @user, @date, @user, @date),
				(3, 'Content Contributor', @user, @date, @user, @date),
				(4, 'Content Consumer', @user, @date, @user, @date)

			set identity_insert dbo.UserRole off;

			print 'dbo.UserRole populdated';
		end;
	else
		print 'dbo.UserRole was already populated';
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