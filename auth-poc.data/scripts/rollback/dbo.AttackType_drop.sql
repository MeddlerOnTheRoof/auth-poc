/*
Description:		DROP Table dbo.AttackType
Author:				MeddlerOnTheRoof
Date:				May 24, 2017
*/

begin try
	use authpoc;

	if exists (
		select * from information_schema.referential_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_AttackType_ArmorType'
	)
		begin
			alter table dbo.AttackType drop constraint fk_AttackType_ArmorType;

			print 'dbo.fk_AttackType_ArmorType constraint DROPPED';
		end
	else
		print 'dbo.fk_AttackType_ArmorType constraint was already DROPPED';

	if exists (
		select * from information_schema.tables where
		table_schema = 'dbo' and table_name = 'AttackType'
	)
		begin
			drop table dbo.AttackType;

			print 'dbo.AttackType DROPPED';
		end
	else
		print 'dbo.AttackType was already DROPPED';
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