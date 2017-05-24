/*
Description:	CREATE Table dbo.Civilization
Author:			MeddlerOnTheRoof
Date:			May 23, 2017
*/

begin try
	use authpoc;

	if not exists(
		select 1 from information_schema.tables where 
		table_schema = 'dbo' and table_name = 'Civilization'
	)
		begin
			create table dbo.Civilization(
				CivilizationId int identity(1,1) not null,
				CivilizationName varchar(25) not null,
				CivilizationDescription varchar(200) not null,
				CreatedByUser varchar(20) not null,
				CreatedByDate datetime not null,
				ModifiedByUser varchar(20) not null,
				ModifiedByDate datetime not null,
				constraint pk_Civilization primary key (
					CivilizationId asc
				),
				constraint uq_Civilization_CivilizationName unique (
					CivilizationName
				)
			)

			print 'dbo.Civilization CREATED';
		end;
	else
		print 'dbo.Civilization was already CREATED';

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