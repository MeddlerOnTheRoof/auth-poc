/*
Description:	CREATE Table dbo.AttackType
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(
		select 1 from information_schema.tables where 
		table_schema = 'dbo' and table_name = 'AttackType'
	)
		begin
			create table dbo.AttackType(
				AttackTypeId int identity(1,1) not null,
				AttackTypeName varchar(25) not null,
				ArmorTypeId int not null,
				CreatedByUser varchar(20) not null,
				CreatedByDate datetime not null,
				ModifiedByUser varchar(20) not null,
				ModifiedByDate datetime not null,
				constraint pk_AttackType primary key (
					AttackTypeId asc
				),
				constraint uq_AttackType_AttackTypeName unique (
					AttackTypeName
				),
				constraint uq_AttackType_ArmorTypeId unique (
					ArmorTypeId
				)
			)

			print 'dbo.AttackType CREATED';
		end;
	else
		print 'dbo.AttackType was already CREATED';

	if not exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_AttackType_ArmorType'
	)
		begin
			alter table dbo.AttackType with check add constraint fk_AttackType_ArmorType 
			foreign key(ArmorTypeId) references dbo.ArmorType (ArmorTypeId)

			print 'dbo.fk_AttackType_ArmorType constraint CREATED';
		end;
	else
		print 'dbo.fk_AttackType_ArmorType constraint NOT CREATED';

	if exists(
		select 1 from information_schema.table_constraints where
		constraint_schema = 'dbo' and constraint_name = 'fk_AttackType_ArmorType'
	)
		begin
			alter table dbo.AttackType check constraint fk_AttackType_ArmorType;

			print 'dbo.fk_AttackType_ArmorType check constraint altered';
		end;
	else
		print 'dbo.fk_AttackType_ArmorType check constraint NOT altered';
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