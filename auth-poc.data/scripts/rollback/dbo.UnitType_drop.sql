﻿/*
Description:		DROP Table dbo.UnitType
Author:				MeddlerOnTheRoof
Date:				May 24, 2017
*/

begin try
	use authpoc;

	if exists (
		select * from information_schema.tables where
		table_schema = 'dbo' and table_name = 'UnitType'
	)
		begin
			drop table dbo.UnitType;

			print 'dbo.UnitType DROPPED';
		end
	else
		print 'dbo.UnitType was already DROPPED';
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