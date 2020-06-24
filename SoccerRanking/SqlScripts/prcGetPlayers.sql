create procedure prcGetPlayers
@TeamID int
as
begin
select * from tblPlayers where TeamID = @TeamID
end