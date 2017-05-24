/*
Description:	CREATE Table dbo.ArmorType
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(
		select 1 from information_schema.tables where 
		table_schema = 'dbo' and table_name = 'ArmorType'
	)
		begin
			create table dbo.ArmorType(
				ArmorTypeId int identity(1,1) not null,
				ArmorTypeName varchar(25) not null,
				CreatedByUser varchar(20) not null,
				CreatedByDate datetime not null,
				ModifiedByUser varchar(20) not null,
				ModifiedByDate datetime not null,
				constraint pk_ArmorType primary key (
					ArmorTypeId asc
				),
				constraint uq_ArmorType_ArmorTypeName unique (
					ArmorTypeName
				)
			)

			print 'dbo.ArmorType CREATED';
		end;
	else
		print 'dbo.ArmorType was already CREATED';
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