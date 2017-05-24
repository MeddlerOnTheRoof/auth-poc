/*
Description:	CREATE Table dbo.UnitArmor
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(
		select 1 from information_schema.tables where 
		table_schema = 'dbo' and table_name = 'UnitArmor'
	)
		begin
			create table dbo.UnitArmor(
				UnitArmorId int identity(1,1) not null,

				UnitId int not null,
				ArmorTypeId int not null,
				UnitArmorValue int not null,

				CreatedByUser varchar(20) not null,
				CreatedByDate datetime not null,
				ModifiedByUser varchar(20) not null,
				ModifiedByDate datetime not null,
				constraint pk_UnitArmor primary key (
					UnitArmorId asc
				)
				-- add uq constraints
			)

			print 'dbo.UnitArmor CREATED';
		end;
	else
		print 'dbo.UnitArmor was already CREATED';

	if not exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_UnitArmor_Unit'
	)
		begin
			alter table dbo.UnitArmor with check add constraint fk_UnitArmor_Unit 
			foreign key(UnitId) references dbo.Unit (UnitId)

			print 'dbo.fk_UnitArmor_Unit constraint CREATED';
		end;
	else
		print 'dbo.fk_UnitArmor_Unit constraint NOT CREATED';

	if exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_UnitArmor_Unit'
	)
		begin
			alter table dbo.UnitArmor check constraint fk_UnitArmor_Unit;

			print 'dbo.fk_UnitArmor_Unit check constraint altered';
		end;
	else
		print 'dbo.fk_UnitArmor_Unit check constraint NOT altered';

	if not exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_UnitArmor_ArmorType'
	)
		begin
			alter table dbo.UnitArmor with check add constraint fk_UnitArmor_ArmorType 
			foreign key(ArmorTypeId) references dbo.ArmorType (ArmorTypeId)

			print 'dbo.fk_UnitArmor_ArmorType constraint CREATED';
		end;
	else
		print 'dbo.fk_UnitArmor_ArmorType constraint NOT CREATED';

	if exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_UnitArmor_ArmorType'
	)
		begin
			alter table dbo.UnitArmor check constraint fk_UnitArmor_ArmorType;

			print 'dbo.fk_UnitArmor_ArmorType check constraint altered';
		end;
	else
		print 'dbo.fk_UnitArmor_ArmorType check constraint NOT altered';

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