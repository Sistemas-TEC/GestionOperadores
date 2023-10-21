--Usuario

-- Crear un usuario (User)
CREATE PROCEDURE CreateUser
    @idUser INT,
    @email NVARCHAR(255)
AS
BEGIN
    INSERT INTO [User] (idUser, email)
    VALUES (@idUser, @email);
END;

GO
-- Leer todos los usuarios (User)
CREATE PROCEDURE ReadAllUsers
AS
BEGIN
    SELECT * FROM [User];
END;

GO
-- Leer un usuario (User) por su ID
CREATE PROCEDURE ReadUserByID
    @idUser INT
AS
BEGIN
    SELECT * FROM [User] WHERE idUser = @idUser;
END;

GO
-- Actualizar un usuario (User)
CREATE PROCEDURE UpdateUser
    @idUser INT,
    @email NVARCHAR(255)
AS
BEGIN
    UPDATE [User]
    SET email = @email
    WHERE idUser = @idUser;
END;

GO

-- Eliminar un usuario (User) por su ID
CREATE PROCEDURE DeleteUser
    @idUser INT
AS
BEGIN
    DELETE FROM [User] WHERE idUser = @idUser;
END;
