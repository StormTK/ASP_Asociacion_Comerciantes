Create Table Usuario(
	idUsuario	int identity primary key,
	correo		nvarchar(60) NOT NULL,
	contraseña	nvarchar(18) NOT NULL,
	nombre		nvarchar(30) NOT NULL,
	apellido	nvarchar(30) NOT NULL,
	Rol			int NOT NULL,
	telefono	nvarchar(12) NULL,
	noCuenta	nvarchar(12) NULL,
	noTarjeta	nvarchar(12) NULL
);

Select * from Usuario;