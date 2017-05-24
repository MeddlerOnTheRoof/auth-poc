/*
Description:		DROP Table dbo.Unit
Author:				MeddlerOnTheRoof
Date:				May 24, 2017
*/

begin try
	use authpoc;

	if exists (
		select * from information_schema.referential_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Unit_UnitType'
	)
		begin
			alter table dbo.Unit drop constraint fk_Unit_UnitType;

			print 'dbo.fk_Unit_UnitType constraint DROPPED';
		end
	else
		print 'dbo.fk_Unit_UnitType constraint was already DROPPED';

	if exists (
		select * from information_schema.referential_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Unit_AttackType'
	)
		begin
			alter table dbo.Unit drop constraint fk_Unit_AttackType;

			print 'dbo.fk_Unit_AttackType constraint DROPPED';
		end
	else
		print 'dbo.fk_Unit_AttackType constraint was already DROPPED';

	if exists (
		select * from information_schema.tables where
		table_schema = 'dbo' and table_name = 'Unit'
	)
		begin
			drop table dbo.Unit;

			print 'dbo.Unit DROPPED';
		end
	else
		print 'dbo.Unit was already DROPPED';
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