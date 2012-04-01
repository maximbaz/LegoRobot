use [LegoRobot.Model.RouteContext]
go

create trigger [TriggerInsteadOfInsertRouteErrors] on [RouteErrors]
instead of insert
as
	if not exists(
		select * from [inserted]
		join [RouteErrors] as [present] on 
			[inserted].[RouteId] = [present].[RouteId] and 
			[inserted].[PointId] = [present].[PointId])
	insert into [RouteErrors] select * from [inserted]
go