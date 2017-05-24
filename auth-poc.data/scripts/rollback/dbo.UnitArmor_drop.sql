/*
Description:		DROP Table dbo.UnitArmor
Author:				MeddlerOnTheRoof
Date:				May 24, 2017
*/

begin try
	use authpoc;

	if exists (
		select * from information_schema.referential_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_UnitArmor_Unit'
	)
		begin
			alter table dbo.UnitArmor drop constraint fk_UnitArmor_Unit;

			print 'dbo.fk_UnitArmor_Unit constraint DROPPED';
		end
	else
		print 'dbo.fk_UnitArmor_Unit constraint was already DROPPED';

	if exists (
		select * from information_schema.referential_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_UnitArmor_ArmorType'
	)
		begin
			alter table dbo.UnitArmor drop constraint fk_UnitArmor_ArmorType;

			print 'dbo.fk_UnitArmor_ArmorType constraint DROPPED';
		end
	else
		print 'dbo.fk_UnitArmor_ArmorType constraint was already DROPPED';

	if exists (
		select * from information_schema.tables where
		table_schema = 'dbo' and table_name = 'UnitArmor'
	)
		begin
			drop table dbo.UnitArmor;

			print 'dbo.UnitArmor DROPPED';
		end
	else
		print 'dbo.UnitArmor was already DROPPED';
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