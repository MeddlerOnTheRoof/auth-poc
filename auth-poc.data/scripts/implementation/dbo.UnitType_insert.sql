/*
Description:	INSERT Table dbo.UnitType
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(select 1 from dbo.UnitType)
		begin
			declare @user char(8);
			declare @date datetime;

			set @user = 'system';
			set @date = getdate();

			set identity_insert dbo.UnitType on;

			insert into dbo.UnitType (UnitTypeId, UnitTypeName, CreatedByUser, CreatedByDate, ModifiedByUser, ModifiedByDate)
			values 
				(1, 'Building', @user, @date, @user, @date),
				(2, 'Infantry', @user, @date, @user, @date),
				(3, 'Archer', @user, @date, @user, @date),
				(4, 'Cavalry', @user, @date, @user, @date),
				(5, 'Siege', @user, @date, @user, @date)

			set identity_insert dbo.UnitType off;

			print 'dbo.UnitType populdated';
		end;
	else
		print 'dbo.UnitType was already populated';
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