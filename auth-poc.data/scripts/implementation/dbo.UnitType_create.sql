/*
Description:	CREATE Table dbo.UnitType
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(
		select 1 from information_schema.tables where 
		table_schema = 'dbo'  and table_name = 'UnitType'
	)
		begin
			create table dbo.UnitType(
				UnitTypeId int identity(1,1) not null,
				UnitTypeName varchar(25) not null,
				CreatedByUser varchar(20) not null,
				CreatedByDate datetime not null,
				ModifiedByUser varchar(20) not null,
				ModifiedByDate datetime not null,
				constraint pk_UnitType primary key (
					UnitTypeId asc
				),
				constraint uq_UnitType_UnitTypeName unique (
					UnitTypeName
				)
			)

			print 'dbo.UnitType CREATED';
		end;
	else
		print 'dbo.UnitType was already CREATED';
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