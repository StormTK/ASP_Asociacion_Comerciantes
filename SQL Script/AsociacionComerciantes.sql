Create Table Usuario(
	idUsuario	int identity primary key,
	correo		nvarchar(60) NOT NULL,
	contraseña	nvarchar(18) NOT NULL,
	nombre		nvarchar(30) NOT NULL,
	apellido	nvarchar(30) NOT NULL,
	sexo		bit NOT NULL,
	rol			int NOT NULL,
	telefono	nvarchar(12) NULL,
	noCuenta	nvarchar(12) NULL,
	noTarjeta	nvarchar(12) NULL,
	estado		int NOT NULL
);

Create Table Historial(
	idHistorial	int,
	idusuario	int,
	fecha		datetime NOT NULL DEFAULT GETDATE(),
	descrip		varchar(80) NOT NULL,
	CONSTRAINT pk_accion PRIMARY KEY(idHistorial, idusuario),
	CONSTRAINT fk_usuario FOREIGN KEY(idusuario) REFERENCES Usuario(idUsuario)
);

INSERT INTO Usuario(correo, contraseña, nombre, apellido, sexo, rol, estado) Values('Admin@AsoComer.com','Admin1234567','Administrador','AsoComer',1, 1,1)
INSERT INTO Historial(idHistorial, idusuario, descrip) Values(1,1,'Se Registro en la Aplicacion')

Select * from Usuario;
Select * from Historial;
