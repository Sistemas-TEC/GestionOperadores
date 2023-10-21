--Facilities

-- Crear una instalación (Facility)
CREATE PROCEDURE CreateFacility
    @idFacilities INT,
    @capacity INT,
    @idUser INT
AS
BEGIN
    INSERT INTO Facility (idFacilities, capacity, idUser)
    VALUES (@idFacilities, @capacity, @idUser);
END;

GO

-- Leer todas las instalaciones (Facility)
CREATE PROCEDURE ReadAllFacilities
AS
BEGIN
    SELECT * FROM Facility;
END;
GO

-- Leer una instalación (Facility) por su ID
CREATE PROCEDURE ReadFacilityByID
    @idFacilities INT
AS
BEGIN
    SELECT * FROM Facility WHERE idFacilities = @idFacilities;
END;

GO

-- Actualizar una instalación (Facility)
CREATE PROCEDURE UpdateFacility
    @idFacilities INT,
    @capacity INT,
    @idUser INT
AS
BEGIN
    UPDATE Facility
    SET capacity = @capacity, idUser = @idUser
    WHERE idFacilities = @idFacilities;
END;

GO

-- Eliminar una instalación (Facility) por su ID
CREATE PROCEDURE DeleteFacility
    @idFacilities INT
AS
BEGIN
    DELETE FROM Facility WHERE idFacilities = @idFacilities;
END;

