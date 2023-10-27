
-- QUERY ADMOPERATOR
--Agrega un administrador de operadores
CREATE PROCEDURE CreateAdmOperator
    @idAdmOperator INT,
    @cellphone NVARCHAR(20),
    @email NVARCHAR(255)
AS
BEGIN
    INSERT INTO AdmOperator (idAdmOperator, cellphone, email)
    VALUES (@idAdmOperator, @cellphone, @email);
END;

GO
-- Leer todos los registros de operadores administrativos
CREATE PROCEDURE ReadAllAdmOperators
AS
BEGIN
    SELECT * FROM AdmOperator;
END;

GO
-- Actualizar un registro de operador administrativo
CREATE PROCEDURE UpdateAdmOperator
    @idAdmOperator INT,
    @cellphone NVARCHAR(20),
    @email NVARCHAR(255)
AS
BEGIN
    UPDATE AdmOperator
    SET cellphone = @cellphone, email = @email
    WHERE idAdmOperator = @idAdmOperator;
END;
GO

-- Eliminar un registro de operador administrativo
CREATE PROCEDURE DeleteAdmOperator
    @idAdmOperator INT
AS
BEGIN
    DELETE FROM AdmOperator WHERE idAdmOperator = @idAdmOperator;
END;