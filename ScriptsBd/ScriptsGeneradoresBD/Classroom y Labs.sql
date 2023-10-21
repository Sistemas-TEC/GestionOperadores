--Laboratory y Classroom

-- Crear un laboratorio (Laboratory)
CREATE PROCEDURE CreateLaboratory
    @idLaboratory VARCHAR(255),
    @idFacilities INT
AS
BEGIN
    INSERT INTO Laboratory (idLaboratory, idFacilities)
    VALUES (@idLaboratory, @idFacilities);
END;
GO
-- Leer todos los laboratorios (Laboratory)
CREATE PROCEDURE ReadAllLaboratories
AS
BEGIN
    SELECT * FROM Laboratory;
END;
GO
-- Leer un laboratorio (Laboratory) por su ID
CREATE PROCEDURE ReadLaboratoryByID
    @idLaboratory VARCHAR(255)
AS
BEGIN
    SELECT * FROM Laboratory WHERE idLaboratory = @idLaboratory;
END;
GO
-- Actualizar un laboratorio (Laboratory)
CREATE PROCEDURE UpdateLaboratory
    @idLaboratory VARCHAR(255),
    @idFacilities INT
AS
BEGIN
    UPDATE Laboratory
    SET idFacilities = @idFacilities
    WHERE idLaboratory = @idLaboratory;
END;

GO

-- Eliminar un laboratorio (Laboratory) por su ID
CREATE PROCEDURE DeleteLaboratory
    @idLaboratory VARCHAR(255)
AS
BEGIN
    DELETE FROM Laboratory WHERE idLaboratory = @idLaboratory;
END;

GO

----------------------------------------------------
----------------------------------------------------
----------------------------------------------------

--Classroom

-- Crear un aula (Classroom)
CREATE PROCEDURE CreateClassroom
    @idClassroom VARCHAR(255),
    @idFacilities INT
AS
BEGIN
    INSERT INTO Classroom (idClassroom, idFacilities)
    VALUES (@idClassroom, @idFacilities);
END;

GO
-- Leer todas las aulas (Classroom)
CREATE PROCEDURE ReadAllClassrooms
AS
BEGIN
    SELECT * FROM Classroom;
END;

GO
-- Leer un aula (Classroom) por su ID
CREATE PROCEDURE ReadClassroomByID
    @idClassroom VARCHAR(255)
AS
BEGIN
    SELECT * FROM Classroom WHERE idClassroom = @idClassroom;
END;

GO
-- Actualizar un aula (Classroom)
CREATE PROCEDURE UpdateClassroom
    @idClassroom VARCHAR(255),
    @idFacilities INT
AS
BEGIN
    UPDATE Classroom
    SET idFacilities = @idFacilities
    WHERE idClassroom = @idClassroom;
END;

GO

-- Eliminar un aula (Classroom) por su ID
CREATE PROCEDURE DeleteClassroom
    @idClassroom VARCHAR(255)
AS
BEGIN
    DELETE FROM Classroom WHERE idClassroom = @idClassroom;
END;