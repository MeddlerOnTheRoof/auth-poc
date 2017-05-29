/*
Description:	INSERT Table dbo.ArmorType
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(select 1 from dbo.ArmorType)
		begin
			declare @user char(8);
			declare @date datetime;

			set @user = 'system';
			set @date = getdate();

			set identity_insert dbo.ArmorType on;

			insert into dbo.ArmorType (ArmorTypeId, ArmorTypeName, CreatedByUser, CreatedByDate, ModifiedByUser, ModifiedByDate)
			values 
				(1, 'Slash Armor', @user, @date, @user, @date),
				(2, 'Crush Armor', @user, @date, @user, @date),
				(3, 'Pierce Armor', @user, @date, @user, @date),
				(4, 'Burn Armor', @user, @date, @user, @date)

			set identity_insert dbo.ArmorType off;

			print 'dbo.ArmorType populdated';
		end;
	else
		print 'dbo.ArmorType was already populated';
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