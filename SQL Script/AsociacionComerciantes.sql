CREATE TABLE Usuario(
	idUsuario	INTEGER IDENTITY PRIMARY KEY,
	correo		NVARCHAR(60) NOT NULL,
	contraseña	NVARCHAR(18) NOT NULL,
	nombre		NVARCHAR(30) NOT NULL,
	apellido	NVARCHAR(30) NOT NULL,
	sexo		BIT NOT NULL,
	rol			INTEGER NOT NULL,
	telefono	NVARCHAR(12) NULL,
	noCuenta	NVARCHAR(12) NULL,
	noTarjeta	NVARCHAR(12) NULL,
	estado		INTEGER NOT NULL
);

CREATE TABLE Historial(
	idHistorial	INTEGER NOT NULL,
	idusuario	INTEGER NOT NULL,
	fecha		DATETIME NOT NULL DEFAULT GETDATE(),
	descrip		NVARCHAR(80) NOT NULL,
	CONSTRAINT pk_historial PRIMARY KEY(idHistorial, idusuario),
	CONSTRAINT fk_usuario FOREIGN KEY(idusuario) REFERENCES Usuario(idUsuario)
);

CREATE TABLE Zona(
    idZona		INTEGER NOT NULL PRIMARY KEY,
	nombre      VARCHAR (60) NOT NULL,
	idZonaS		INTEGER NULL,
	CONSTRAINT fk_zonasup FOREIGN KEY(idZonaS) REFERENCES Zona(idZona)
)

CREATE TABLE ZonaVecina(
    idZona		INTEGER NOT NULL,
	idZonaV		INTEGER NOT NULL,
	CONSTRAINT pk_zonavecina PRIMARY KEY(idZona, idZonaV),
	CONSTRAINT fk_zonapri FOREIGN KEY(idZona) REFERENCES Zona(idZona),
	CONSTRAINT fk_zonavec FOREIGN KEY(idZonaV) REFERENCES Zona(idZona)
)

CREATE TABLE Comercio
  (
    idComercio	INTEGER NOT NULL IDENTITY PRIMARY KEY,
    nombre      VARCHAR (60) NOT NULL ,
    siglas		VARCHAR (10) NOT NULL ,
    direccion   VARCHAR (30) NOT NULL ,
    email       VARCHAR (30) NOT NULL ,
    fax         VARCHAR (30) ,
    telefono    VARCHAR (8) ,
    estado      INTEGER NOT NULL ,
    idUsuario	INTEGER NOT NULL ,
    idZona      INTEGER NULL
  );

INSERT INTO Usuario(correo, contraseña, nombre, apellido, sexo, rol, estado) Values('ADMIN@ASOCOMER.COM','Admin1234567','Administrador','Asocomer',1, 1, 1)
INSERT INTO Historial(idHistorial, idusuario, descrip) Values(1,1,'Se Registro en la Aplicacion Web')

Select * from Usuario;
Select * from Historial
Select * from Zona

Select MAX(idHistorial) from Historial WHERE idusuario = 1
 delete from Zona where idZona < 14
/*INTO UPDATE Historial SET descrip = "Se Registro en la Aplicación Web" where idusuario = 1*/