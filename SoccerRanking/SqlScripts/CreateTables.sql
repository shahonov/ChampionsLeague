create table tblTeams
(
ID int primary key identity(1, 1),
Name nvarchar(50) not null,
Wins int,
Draws int,
Losses int
);

create table tblPlayers
(
ID int primary key identity(1, 1),
Name nvarchar(100) not null,
TeamID int not null,
Role nvarchar(20),
ScoredGoals int,
YellowCards int,
RedCards int
);