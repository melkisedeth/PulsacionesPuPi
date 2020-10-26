CREATE TABLE Persona (
    Identificacion NVARCHAR(10) NOT NULL PRIMARY KEY,
    Nombres NVARCHAR(30),
    Apellidos NVARCHAR(30),
    Edad INT,
    Sexo NVARCHAR(9),
    Pulsaciones DECIMAL(4,1)
)

DROP TABLE Persona

DELETE FROM Persona

SELECT * FROM Persona

COMMIT