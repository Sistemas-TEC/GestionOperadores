-- Crear la tabla 'AdmOperator'
CREATE TABLE AdmOperator (
    idAdmOperator INT PRIMARY KEY,
    cellphone NVARCHAR(20),
    email NVARCHAR(255)
);

-- Crear la tabla 'User'
CREATE TABLE [User] (
    idUser INT PRIMARY KEY,
    email NVARCHAR(255)
);

-- Crear la tabla 'Operator'
CREATE TABLE Operator (
    idOperator INT PRIMARY KEY,
    cellphone NVARCHAR(20),
    email NVARCHAR(255)
);

-- Crear la tabla 'SchedulexOperator'
CREATE TABLE SchedulexOperator (
    day DATE,
    beginningHour TIME(0),
    finishingHour TIME(0),
    idSchedulexOperator INT PRIMARY KEY,
    idOperator INT,
    FOREIGN KEY (idOperator) REFERENCES Operator(idOperator)
);

-- Crear la tabla 'Equipment'
CREATE TABLE Equipment (
    idEquipment INT PRIMARY KEY,
    availability BIT,
    name NVARCHAR(255),
    description NVARCHAR(MAX),
    idUser INT,
    condition NVARCHAR(255),
    FOREIGN KEY (idUser) REFERENCES [User](idUser)
);

-- Crear la tabla 'SchedulexEquipment'
CREATE TABLE SchedulexEquipment (
    idSchedulexEquipment INT PRIMARY KEY,
    initialDate DATE,
    finalDate DATE,
    beginningHour TIME(0),
    finishingHour TIME(0),
    idEquipment INT,
    FOREIGN KEY (idEquipment) REFERENCES Equipment(idEquipment)
);

-- Crear la tabla 'Facility'
CREATE TABLE Facility (
    idFacilities INT PRIMARY KEY,
    capacity INT,
    idUser INT,
    FOREIGN KEY (idUser) REFERENCES [User](idUser)
);

-- Crear la tabla 'SchedulexFacility'
CREATE TABLE SchedulexFacility (
    idSchedulexFacility INT PRIMARY KEY,
    date DATE,
    beginningHour TIME(0),
    finishingHour TIME(0),
    idFacilities INT,
    FOREIGN KEY (idFacilities) REFERENCES Facility(idFacilities)
);

-- Crear la tabla 'Classroom'
CREATE TABLE Classroom (
    idClassroom VARCHAR(255) PRIMARY KEY,
    idFacilities INT,
    FOREIGN KEY (idFacilities) REFERENCES Facility(idFacilities)
);

-- Crear la tabla 'Laboratory'
CREATE TABLE Laboratory (
    idLaboratory VARCHAR(255) PRIMARY KEY,
    idFacilities INT,
    FOREIGN KEY (idFacilities) REFERENCES Facility(idFacilities)
);