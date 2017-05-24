/*
Description:		DROP Table dbo.Build
Author:				MeddlerOnTheRoof
Date:				May 24, 2017
*/

begin try
	use authpoc;

	if exists (
		select * from information_schema.referential_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Build_Unit'
	)
		begin
			alter table dbo.Build drop constraint fk_Build_Unit;

			print 'dbo.fk_Build_Unit constraint DROPPED';
		end
	else
		print 'dbo.fk_Build_Unit constraint was already DROPPED';

	if exists (
		select * from information_schema.referential_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Build_Builder'
	)
		begin
			alter table dbo.Build drop constraint fk_Build_Builder;

			print 'dbo.fk_Build_Builder constraint DROPPED';
		end
	else
		print 'dbo.fk_Build_Builder constraint was already DROPPED';

	if exists (
		select * from information_schema.tables where
		table_schema = 'dbo' and table_name = 'Build'
	)
		begin
			drop table dbo.Build;

			print 'dbo.Build DROPPED';
		end
	else
		print 'dbo.Build was already DROPPED';
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