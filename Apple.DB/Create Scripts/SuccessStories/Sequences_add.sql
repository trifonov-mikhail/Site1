IF NOT EXISTS(SELECT ID FROM Sequences WHERE Description = 'SuccessStories')
BEGIN
	INSERT INTO Sequences(Value, Description) VALUES (0, 'SuccessStories') 
END