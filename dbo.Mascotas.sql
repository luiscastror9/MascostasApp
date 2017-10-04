CREATE TABLE [dbo].[Mascotas] (
    [Id]          INT           NOT NULL IDENTITY,
    [Animal]      NVARCHAR (50) NULL,
    [Raza]        NVARCHAR (50) NULL,
    [Ubicacion]   NVARCHAR (50) NULL,
    [Sexo]        BIT           NULL,
    [Descripcion] NVARCHAR (50) NULL,
    [Vacunas]     NVARCHAR (50) NULL,
    [Edad]        INT           NULL,
    [Status]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

