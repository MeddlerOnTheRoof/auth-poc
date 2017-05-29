/*
Description:	CREATE Table dbo.Unit
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(
		select 1 from information_schema.tables where 
		table_schema = 'dbo' and table_name = 'Unit'
	)
		begin
			create table dbo.Unit(
				UnitId int identity(1,1) not null,
				UnitName varchar(25) not null,
				UnitTypeId int not null,
				Food int not null,
				Gold int not null,
				Stone int not null,
				Wood int not null,
				--BuildTime time not null default '00:00:00',
				MoveSpeed int not null,
				LineOfSight int not null,
				Health int not null,
				AttackRange int null,
				Attack int not null,
				AttackTypeId int not null,
				AttackSpeed int not null,
				CreatedByUser varchar(20) not null,
				CreatedByDate datetime not null,
				ModifiedByUser varchar(20) not null,
				ModifiedByDate datetime not null,
				constraint pk_Unit primary key (
					UnitId asc
				),
				constraint uq_Unit_UnitName unique (
					UnitName
				)
			)

			print 'dbo.Unit CREATED';
		end;
	else
		print 'dbo.Unit was already CREATED';

	if not exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Unit_UnitType'
	)
		begin
			alter table dbo.Unit with check add constraint fk_Unit_UnitType 
			foreign key(UnitTypeId) references dbo.UnitType (UnitTypeId)

			print 'dbo.fk_Unit_UnitType constraint CREATED';
		end;
	else
		print 'dbo.fk_Unit_UnitType constraint NOT CREATED';

	if exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Unit_UnitType'
	)
		begin
			alter table dbo.Unit check constraint fk_Unit_UnitType;

			print 'dbo.fk_Unit_UnitType check constraint altered';
		end;
	else
		print 'dbo.fk_Unit_UnitType check constraint NOT altered';

	if not exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Unit_AttackType'
	)
		begin
			alter table dbo.Unit with check add constraint fk_Unit_AttackType 
			foreign key(AttackTypeId) references dbo.AttackType (AttackTypeId)

			print 'dbo.fk_Unit_AttackType constraint CREATED';
		end;
	else
		print 'dbo.fk_Unit_AttackType constraint NOT CREATED';

	if exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_Unit_AttackType'
	)
		begin
			alter table dbo.Unit check constraint fk_Unit_AttackType;

			print 'dbo.fk_Unit_AttackType check constraint altered';
		end;
	else
		print 'dbo.fk_Unit_AttackType check constraint NOT altered';
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