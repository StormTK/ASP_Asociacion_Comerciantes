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

Create Table Accion(
	idAccion	int,
	idusuario	int,
	fecha		datetime NOT NULL,
	descrip		varchar(80) NOT NULL,
	CONSTRAINT pk_accion PRIMARY KEY(idAccion, idusuario),
	CONSTRAINT fk_usuario FOREIGN KEY(idusuario) REFERENCES Usuario(idUsuario)
);

INSERT INTO Usuario(correo, contraseña, nombre, apellido, Rol) Values('Admin@AsoComer','Admin1234567','Administrador','AsoComer', 1)
INSERT INTO Accion(idAccion, idusuario, fecha, descrip) Values(1,1,'2016-10-05T11:54:00','Se Registro en la Aplicacion')
Select * from Usuario;
UPDATE Usuario Set correo = 'ADMIN@ASOCOMER' where idUsuario = 1; 
Select * from Accion;