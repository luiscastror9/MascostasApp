CREATE TABLE [dbo].[Pub]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Raza] NVARCHAR(15) NULL, 
    [Ubicacion] NVARCHAR(30) NOT NULL, 
    [Sexo] NVARCHAR(10) NOT NULL, 
    [Vacunas] NVARCHAR(MAX) NULL, 
    [Edad] INT NULL, 
    [Descripcion] TEXT NOT NULL, 
    [Status] INT NULL
)
