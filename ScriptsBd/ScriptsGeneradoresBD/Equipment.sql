CREATE PROCEDURE CreateEquipment
    @availability BIT,
    @name NVARCHAR(255),
    @description NVARCHAR(MAX),
    @idUser INT,
    @condition NVARCHAR(255)
AS
BEGIN
    INSERT INTO Equipment (availability, name, description, idUser, condition)
    VALUES (@availability, @name, @description, @idUser, @condition);
END;

GO

CREATE PROCEDURE ReadEquipment
    @idEquipment INT
AS
BEGIN
    SELECT * FROM Equipment
    WHERE idEquipment = @idEquipment;
END;


GO


CREATE PROCEDURE ReadAllEquipment
    @idEquipment INT
AS
BEGIN
    SELECT * FROM Equipment
END;


GO

CREATE PROCEDURE UpdateEquipment
    @idEquipment INT,
    @availability BIT,
    @name NVARCHAR(255),
    @description NVARCHAR(MAX),
    @idUser INT,
    @condition NVARCHAR(255)
AS
BEGIN
    UPDATE Equipment
    SET availability = @availability,
        name = @name,
        description = @description,
        idUser = @idUser,
        condition = @condition
    WHERE idEquipment = @idEquipment;
END;


GO

CREATE PROCEDURE DeleteEquipment
    @idEquipment INT
AS
BEGIN
    DELETE FROM Equipment
    WHERE idEquipment = @idEquipment;
END;