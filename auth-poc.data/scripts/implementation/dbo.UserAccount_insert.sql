/*
Description:	INSERT Table dbo.UserAccount
Author:			MeddlerOnTheRoof
Date:			May 23, 2017

Role Description
admin				:: can do everything all other users can and perform CRUD operations on users (also delete rights on others' records)
content_creator		:: fulls rights to records they've created and rights to edit records others have created
content_contributor	:: full rights to content they've created and rights to consume but not modify records others have created
content_consumer	:: rights to view all content but not create, update, or delete
*/

begin try
	use authpoc;

	if not exists(select 1 from dbo.UserAccount)
		begin
			declare @user char(8);
			declare @date datetime;

			set @user = 'system';
			set @date = getdate();

			set identity_insert dbo.UserAccount on;

			insert into dbo.UserAccount (UserAccountId, UserAccountName, UserAccountPassword, UserRoleId, CreatedByUser, CreatedByDate, ModifiedByUser, ModifiedByDate)
			values 
				(1, 'admin', 'password', 1, @user, @date, @user, @date),
				(2, 'content_creator_example', 'password', 2, @user, @date, @user, @date),
				(3, 'content_contributor_example', 'password', 3, @user, @date, @user, @date),
				(4, 'content_consumer_example', 'password', 4, @user, @date, @user, @date)

			set identity_insert dbo.UserAccount off;

			print 'dbo.UserAccount populdated';
		end;
	else
		print 'dbo.UserAccount was already populated';
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