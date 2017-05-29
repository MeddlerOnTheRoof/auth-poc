/*
Description:	INSERT Table dbo.AttackType
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(select 1 from dbo.AttackType)
		begin
			declare @user char(8);
			declare @date datetime;

			set @user = 'system';
			set @date = getdate();

			set identity_insert dbo.AttackType on;

			insert into dbo.AttackType (AttackTypeId, AttackTypeName, ArmorTypeId, CreatedByUser, CreatedByDate, ModifiedByUser, ModifiedByDate)
			values 
				(1, 'Slash', 1, @user, @date, @user, @date),
				(2, 'Crush', 2, @user, @date, @user, @date),
				(3, 'Pierce', 3, @user, @date, @user, @date),
				(4, 'Burn', 4, @user, @date, @user, @date)

			set identity_insert dbo.AttackType off;

			print 'dbo.AttackType populdated';
		end;
	else
		print 'dbo.AttackType was already populated';
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