CREATE TABLE [dbo].[Usuario] (
    [ID]                  INT           IDENTITY (1, 1) NOT NULL,
    [Empresa]             NVARCHAR (50) NULL,
    [Nombre]              NVARCHAR (50) NULL,
    [Apellido]            NVARCHAR (50) NULL,
    [Nombre de Usuario]   NVARCHAR (50) NULL,
    [Pass]                NVARCHAR (50) NULL,
    [Localidad]           NVARCHAR (50) NULL,
    [Fecha de nacimiento] DATE          NULL,
    [DNI]                 NVARCHAR (50) NULL,
    [Tipo de usuario]     NCHAR (10)    NULL,
    [Email]               NVARCHAR (50) NULL,
	[CPass]               NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

