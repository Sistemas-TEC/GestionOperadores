CREATE PROCEDURE CreateOperator
    @cellphone NVARCHAR(20),
    @email NVARCHAR(255)
AS
BEGIN
    INSERT INTO Operator (cellphone, email)
    VALUES (@cellphone, @email);
END;

GO

CREATE PROCEDURE ReadOperator
    @email NVARCHAR(255)
AS
BEGIN
    SELECT * FROM Operator
    WHERE email = @email;
END;

GO

CREATE PROCEDURE DeleteOperator
    @email NVARCHAR(255)
AS
BEGIN
    DELETE FROM Operator
    WHERE email = @email;
END;

GO

CREATE PROCEDURE UpdateOperator
    @idOperador int,
    @cellphone nvarchar(20),
    @email nvarchar(255)
AS
BEGIN
    -- Check if the user with the provided id exists
    IF NOT EXISTS (SELECT 1 FROM Operator WHERE idOperator = @idOperador)
    BEGIN
        RETURN -1;
    END
	ELSE
	BEGIN
		-- Perform the update
		UPDATE Operator
		SET 
			cellphone = @cellphone,
			email = @email
		WHERE idOperator = @idOperador;
	END
END;

GO