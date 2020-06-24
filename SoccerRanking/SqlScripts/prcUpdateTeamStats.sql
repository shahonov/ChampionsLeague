create procedure prcUpdateTeamStats
@TeamID int,
@Wins int,
@Draws int,
@Losses int
as
begin
update tblTeams
set Wins = @Wins,
Draws = @Draws,
Losses = @Losses
where ID = @TeamID
end