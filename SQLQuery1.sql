select Player.Name
	from Player
	
	join Position on Player.ID=Position.PlayerIDFK
	left join Team on Position.TeamIDFK=Team.ID
where Team.ID = 1;

--select * from Player;
--select * from Position;
--select * from Team;
