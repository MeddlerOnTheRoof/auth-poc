/*
Description:	CREATE Table dbo.Build
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(
		select 1 from information_schema.tables where 
		table_schema = 'dbo'  and table_name = 'Build'
	)
		begin
			create table dbo.Build(
				BuildId int identity(1,1) not null,
				BuilderId int not null,
				UnitId int not null,
				CreatedByUser varchar(20) not null,
				CreatedByDate datetime not null,
				ModifiedByUser varchar(20) not null,
				ModifiedByDate datetime not null,
				constraint pk_Build primary key (
					BuildId asc
				),
				constraint uq_Build_BuilderId_UnitId unique (
					BuilderId,
					UnitId
				)
			)

			print 'dbo.Build CREATED';
		end;
	else
		print 'dbo.Build was already CREATED';

	if not exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Build_Builder'
	)
		begin
			alter table dbo.Build with check add constraint fk_Build_Builder 
			foreign key(BuilderId) references dbo.Unit (UnitId)

			print 'dbo.fk_Build_Builder constraint CREATED';
		end;
	else
		print 'dbo.fk_Build_Builder constraint NOT CREATED';

	if exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Build_Builder'
	)
		begin
			alter table dbo.Build check constraint fk_Build_Builder;

			print 'dbo.fk_Build_Builder check constraint altered';
		end;
	else
		print 'dbo.fk_Build_Builder check constraint NOT altered';

	if not exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Build_Unit'
	)
		begin
			alter table dbo.Build with check add constraint fk_Build_Unit 
			foreign key(UnitId) references dbo.Unit (UnitId)

			print 'dbo.fk_Build_Unit constraint CREATED';
		end;
	else
		print 'dbo.fk_Build_Unit constraint NOT CREATED';

	if exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Build_Unit'
	)
		begin
			alter table dbo.Build check constraint fk_Build_Unit;

			print 'dbo.fk_Build_Unit check constraint altered';
		end;
	else
		print 'dbo.fk_Build_Unit check constraint NOT altered';
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