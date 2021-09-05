CREATE TABLE Planeta(
	planetaId		INTEGER PRIMARY KEY IDENTITY, --identity es para que se incremente automAticamente 1,2,3...
	nombrePlaneta	NVARCHAR(MAX) NOT NULL,
	numeroAnillos	INTEGER NOT NULL,
	tipoPlaneta		NVARCHAR(100) NOT NULL,
	archivoPlaneta	VARBINARY(MAX),
	tipoArchivo		NVARCHAR(50) --esto es solo para guardar la extensiOn del archivo (pdf, png...)
)