DROP DATABASE IF EXISTS SRD;
CREATE DATABASE SRD;
USE SRD;

CREATE TABLE Publicidades
(
IdPublicidad int AUTO_INCREMENT PRIMARY KEY, 
Banner BLOB,
Link VARCHAR(120),
TituloPublicidad VARCHAR(70)
);

CREATE TABLE Usuarios
(
Email VARCHAR(70) PRIMARY KEY,
NombreUsuario VARCHAR(50) unique,
Contrasena VARCHAR(200),
NumeroTelefono VARCHAR(15),
NivelPermisos INT,
IdEventosFavoritos INT,
IdEncuentrosFavoritos INT,
IdEquiposFavoritos INT 
);

CREATE TABLE EventosFavoritos
(
IdEventosFavoritos INT AUTO_INCREMENT PRIMARY KEY,
IdEvento INT,
Email VARCHAR(70) UNIQUE
);

CREATE TABLE EncuentrosFavoritos
(
IdEncuentrosFavoritos INT AUTO_INCREMENT PRIMARY KEY,
IdEncuentro INT,
Email VARCHAR(70) UNIQUE
);

CREATE TABLE EquiposFavoritos
(
IdEquiposFavoritos INT AUTO_INCREMENT PRIMARY KEY,
IdEquipo INT,
Email VARCHAR(70) UNIQUE
);

CREATE TABLE PublicidadesUsuarios
(
IdPublicidad INT,
Email VARCHAR(70),
NombreUsuario VARCHAR(50) UNIQUE,
Contrasena VARCHAR(200),
NumeroTelefono VARCHAR(15),
NivelPermisos INT,
Banner BLOB,
Link VARCHAR(120),
TituloPublicidad VARCHAR(70),
IdEventosFavoritos INT,
IdEncuentrosFavoritos INT,
IdEquiposFavoritos INT, 
PRIMARY KEY (IdPublicidad, Email)
);

CREATE TABLE Personas
(
IdPersona INT AUTO_INCREMENT PRIMARY KEY,
Nombre VARCHAR(50)NOT NULL,
Apellido VARCHAR(50) NOT NULL,
Nacionalidad varchar(50) NOT NULL
);

CREATE TABLE UsuariosPersonas
(
Email VARCHAR(70),
IdPersona INT,
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
Nacionalidad VARCHAR(50) not NULL,
NombreUsuario VARCHAR(50) UNIQUE,
Contrasena VARCHAR(200),
NumeroTelefono VARCHAR(15),
NivelPermisos INT,
IdEventosFavoritos INT,
IdEncuentrosFavoritos INT,
IdEquiposFavoritos INT,
PRIMARY KEY (IdPersona, Email)
);

CREATE TABLE Arbitros
(
IdPersona INT PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
Nacionalidad VARCHAR(50) NOT NULL,
Rol VARCHAR(30)
);

CREATE TABLE Deportistas
(
IdPersona INT PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
Nacionalidad VARCHAR(50) NOT NULL,
EstadoJugador VARCHAR(50),
Descripcion TEXT 
);

CREATE TABLE Equipos
(
IdEquipo INT AUTO_INCREMENT PRIMARY KEY,
ImagenRepresentativa BLOB,
PaisOrigen VARCHAR(80) NOT NULL,
NombreEquipo VARCHAR(120) NOT NULL,
TipoEquipo VARCHAR(15) NOT NULL
);

CREATE TABLE EquiposDeportistas
(
IdEquipo INT,
IdPersona INT,
ImagenRepresentativa BLOB,
PaisOrigen varchar(80) NOT NULL,
NombreEquipo varchar(120) NOT NULL,
EstadoJugador varchar(70) NOT NULL,
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
Descripcion TEXT,
TipoEquipo VARCHAR(15) NOT NULL,
PRIMARY KEY (IdEquipo, IdPersona)
);

CREATE TABLE EstadisticasJugador
(
IdEstadisticasJugador INT AUTO_INCREMENT,
IdEncuentro INT,
Anotacion INT,
Faltas VARCHAR(80),
IdDeportista INT,
PRIMARY KEY (IdEstadisticasJugador, IdEncuentro)
);

CREATE TABLE Fases
(
NumeroFase INT,
IdEvento INT,
Fecha DATE,
NombreFase VARCHAR(120),
EstadoFase VARCHAR(20),
Tipofase TINYINT NOT NULL,
TamañoGrupos INT,
PRIMARY KEY (NumeroFase, IdEvento)
);

CREATE TABLE EquiposFases
(
IdEquipo INT,
NumeroFase INT,
IdEvento INT,
ImagenRepresentativa BLOB,
PaisOrigen VARCHAR(80) NOT NULL,
NombreEquipo VARCHAR(120) NOT NULL,
EstadoFase VARCHAR(70) NOT NULL,
NombreFase VARCHAR(80),
Fecha DATE,
PosicionEquipo INT,
EstadoEquipo VARCHAR(80),
Puntaje INT,
TipoEquipo VARCHAR(15),
Tipofase TINYINT NOT NULL,
TamañoGrupos INT,
PRIMARY KEY (IdEquipo, NumeroFase, IdEvento)
);

CREATE TABLE Eventos
(
IdEvento INT AUTO_INCREMENT,
FechaEvento DATE NOT NULL,
NombreEvento VARCHAR(70) NOT NULL,
HoraEvento TIME NOT NULL,
EstadoEvento VARCHAR(20) NOT NULL,
LogoEvento BLOB,
LugarEvento VARCHAR(50) NOT NULL,
PRIMARY KEY (IdEvento)
);

CREATE TABLE Hito
(
IdHito INT AUTO_INCREMENT PRIMARY KEY,
NumeroRound INT, 
IdEncuentro INT,
TituloHito VARCHAR(70),
TiempoHito TIME
);

CREATE TABLE Categorias (
IdCategoria INT AUTO_INCREMENT PRIMARY KEY, 
NombreCategoria VARCHAR(50) NOT NULL 
);

CREATE TABLE Deportes (
 IdDeporte INT AUTO_INCREMENT PRIMARY KEY, 
 NombreDeporte VARCHAR(50) NOT NULL UNIQUE,
 ImagenDeporte BLOB,
 Destacado BOOL
);
 
CREATE TABLE DeportesCategorizados (
 IdDeporte INT,
 IdCategoria INT, 
 NombreDeporte VARCHAR(50) NOT NULL UNIQUE,
 ImagenDeporte BLOB,
 Destacado BOOL, 
 NombreCategoria VARCHAR(50) NOT NULL,
PRIMARY KEY (IdDeporte, IdCategoria)
 );
 
CREATE TABLE Encuentros (
 IdEncuentro INT AUTO_INCREMENT PRIMARY KEY,
 IdDeporte INT,
 IdCategoria INT,
 IdPersona INT,
 Hora TIME NOT NULL, 
 Lugar VARCHAR(120),
 FechaEncuentro DATE NOT NULL, 
 NombreEncuentro VARCHAR(50), 
 EstadoEncuentro VARCHAR(25) NOT NULL, 
 Clima VARCHAR(25),
 TipoEncuentro TINYINT NOT NULL
);

CREATE TABLE EncuentrosFases (
 IdEncuentro INT,
 NumeroFase INT,
 IdEvento INT,
 IdDeporte INT,
 IdCategoria INT,
 IdPersona INT,
 Hora TIME NOT NULL, 
 Lugar VARCHAR(120),
 FechaEncuentro DATE NOT NULL, 
 NombreEncuentro VARCHAR(50), 
 EstadoEncuentro VARCHAR(25) NOT NULL, 
 Clima VARCHAR(25),
 TipoEncuentro TINYINT NOT NULL,
 Fecha DATE,
 NombreFase VARCHAR(120),
 EstadoFase VARCHAR(20),
 Tipofase TINYINT NOT NULL,
 Puntaje INT,
 Posicion INT,
 TamañoGrupos INT,
 PRIMARY KEY (IdEncuentro, NumeroFase, IdEvento)
);

CREATE TABLE EquiposEncuentros (
 IdEquipo INT, 
 IdEncuentro INT,
 IdDeporte INT,
 IdCategoria INT,
 IdPersona INT,
 ImagenRepresentativa BLOB,
 PaisOrigen VARCHAR(80) NOT NULL,
 NombreEquipo VARCHAR(120) NOT NULL,
 TipoEquipo VARCHAR(15) NOT NULL,
 Hora TIME NOT NULL, 
 Lugar VARCHAR(120),
 FechaEncuentro DATE NOT NULL,
 NombreEncuentro VARCHAR (50),
 EstadoEncuentro VARCHAR(25) NOT NULL,
 Clima VARCHAR(25), 
 Puntuacion INT, 
 Posicion INT, 
 Alineacion BLOB,
 TipoEncuentro TINYINT NOT NULL,
 PRIMARY KEY (IdEquipo, IdEncuentro)
 );
 
CREATE TABLE Round (
NumeroRound INT, 
IdEncuentro INT,
TiempoTranscurridoRound TIME NOT NULL,
IdPuntuacionRound INT, 
IdHito INT,
PRIMARY KEY (NumeroRound, IdEncuentro)
);
 
 
CREATE TABLE PuntuacionRound (
IdPuntuacionRound INT AUTO_INCREMENT PRIMARY KEY,
NumeroRound INT, 
IdEncuentro INT,
Puntos INT,
IdEquipo INT NOT NULL
);


DROP USER IF EXISTS Usuario_A;
DROP USER IF EXISTS Usuario_B;
DROP USER IF EXISTS Usuario_C;
DROP USER IF EXISTS Usuario_D;
DROP USER IF EXISTS Usuario_E;


CREATE USER Usuario_A;
GRANT INSERT, UPDATE, DROP, CREATE ON Usuario TO Usuario_A;
GRANT INSERT, UPDATE, DROP, CREATE ON Publicidades TO Usuario_A;
GRANT INSERT, UPDATE, DROP, CREATE ON UsuariosPersonas TO Usuario_A;
GRANT INSERT, UPDATE, DROP, CREATE ON PublicidadesUsuarios TO Usuario_A;
GRANT INSERT, UPDATE, DROP, CREATE ON EncuentrosFavoritos TO Usuario_A;
GRANT INSERT, UPDATE, DROP, CREATE ON EquiposFvaoritos TO Usuario_A;
GRANT INSERT, UPDATE, DROP, CREATE ON EventosFavoritos TO Usuario_A;

CREATE USER Usuario_B;
GRANT INSERT, UPDATE, DROP ON Personas TO Usuario_B;
GRANT INSERT, UPDATE, DROP ON Deportistas TO Usuario_B;
GRANT INSERT, UPDATE, DROP ON Arbitros TO Usuario_B;
GRANT INSERT, UPDATE, DROP ON Equipos TO Usuario_B;
GRANT INSERT, UPDATE, DROP ON Categorias TO Usuario_B;
GRANT INSERT, UPDATE, DROP ON Deportes TO Usuario_B;
GRANT INSERT, UPDATE, DROP ON DeportesCategorizados TO Usuario_B;
GRANT INSERT, UPDATE, DROP ON EquiposDeportistas TO Usuario_B;

CREATE USER Usuario_C;
GRANT INSERT, UPDATE, DROP ON Encuentros TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON Eventos TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON EquiposEncuentros TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON Round TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON PuntuacionRound TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON Hito TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON Fases TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON EstadisticasJugador TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON EncuentrosFases TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON EquiposFases TO Usuario_C;

CREATE USER Usuario_D;
GRANT SELECT ON Usuarios TO Usuario_D;
GRANT SELECT ON UsuariosPersonas TO Usuario_D;
GRANT SELECT ON PublicidadesUsuarios TO Usuario_D;
GRANT SELECT ON EncuentrosFavoritos TO Usuario_D;
GRANT SELECT ON EquiposFavoritos TO Usuario_D;
GRANT SELECT ON EventosFavoritos TO Usuario_D;

CREATE USER Usuario_E;
GRANT SELECT ON Publicidades TO Usuario_E;
GRANT SELECT ON Personas TO Usuario_E;
GRANT SELECT ON Deportistas TO Usuario_E;
GRANT SELECT ON Arbitros TO Usuario_E;
GRANT SELECT ON Equipos TO Usuario_E;
GRANT SELECT ON Categorias TO Usuario_E;
GRANT SELECT ON Deportes TO Usuario_E;
GRANT SELECT ON DeportesCategorizados TO Usuario_E;
GRANT SELECT ON EquiposDeportistas TO Usuario_E;
GRANT SELECT ON Encuentros TO Usuario_E;
GRANT SELECT ON Eventos TO Usuario_E;
GRANT SELECT ON EquiposEncuentros TO Usuario_E;
GRANT SELECT ON Round TO Usuario_E;
GRANT SELECT ON PuntuacionRound TO Usuario_E;
GRANT SELECT ON Hito TO Usuario_E;
GRANT SELECT ON Fases TO Usuario_E;
GRANT SELECT ON EstadisticasJugador TO Usuario_E;
GRANT SELECT ON EncuentrosFases TO Usuario_E;
GRANT SELECT ON EquiposFases TO Usuario_E;



ALTER TABLE Usuarios 
ADD CONSTRAINT FK_UsuariosEventosFavoritos 
FOREIGN KEY (IdEventosFavoritos) 
REFERENCES EventosFavoritos(IdEventosFavoritos)
ON DELETE CASCADE;

ALTER TABLE Usuarios 
ADD CONSTRAINT FK_UsuariosEncuentrosFavoritos 
FOREIGN KEY (IdEncuentrosFavoritos) 
REFERENCES EncuentrosFavoritos(IdEncuentrosFavoritos)
ON DELETE CASCADE;

ALTER TABLE Usuarios 
ADD CONSTRAINT FK_UsuariosEquiposFavoritos 
FOREIGN KEY (IdEquiposFavoritos) 
REFERENCES EquiposFavoritos(IdEquiposFavoritos)
ON DELETE CASCADE;

ALTER TABLE EventosFavoritos
ADD CONSTRAINT FK_EventosFavoritosEventos
FOREIGN KEY (IdEvento) 
REFERENCES Eventos(IdEvento)
ON DELETE CASCADE;

ALTER TABLE EncuentrosFavoritos
ADD CONSTRAINT FK_EncuentrosFavoritosEncuentros
FOREIGN KEY (IdEncuentro) 
REFERENCES Encuentros(IdEncuentro)
ON DELETE CASCADE;

ALTER TABLE EquiposFavoritos
ADD CONSTRAINT FK_EquiposFavoritosEquipos
FOREIGN KEY (IdEquipo) 
REFERENCES Equipos(IdEquipo)
ON DELETE CASCADE;

ALTER TABLE PublicidadesUsuarios
ADD CONSTRAINT FK_PublicidadesUsuariosEventosFavoritos 
FOREIGN KEY (IdEventosFavoritos) 
REFERENCES EventosFavoritos(IdEventosFavoritos)
ON DELETE CASCADE;

ALTER TABLE PublicidadesUsuarios
ADD CONSTRAINT FK_PublicidadesUsuariosEncuentrosFavoritos 
FOREIGN KEY (IdEncuentrosFavoritos) 
REFERENCES EncuentrosFavoritos(IdEncuentrosFavoritos)
ON DELETE CASCADE;

ALTER TABLE PublicidadesUsuarios 
ADD CONSTRAINT FK_PublicidadesUsuariosEquiposFavoritos 
FOREIGN KEY (IdEquiposFavoritos) 
REFERENCES EquiposFavoritos(IdEquiposFavoritos)
ON DELETE CASCADE;

ALTER TABLE UsuariosPersonas
ADD CONSTRAINT FK_UsuariosPersonasEventosFavoritos 
FOREIGN KEY (IdEventosFavoritos) 
REFERENCES EventosFavoritos(IdEventosFavoritos)
ON DELETE CASCADE;

ALTER TABLE UsuariosPersonas
ADD CONSTRAINT FK_UsuariosPersonasEncuentrosFavoritos 
FOREIGN KEY (IdEncuentrosFavoritos) 
REFERENCES EncuentrosFavoritos(IdEncuentrosFavoritos)
ON DELETE CASCADE;

ALTER TABLE UsuariosPersonas 
ADD CONSTRAINT FK_UsuariosPersonasEquiposFavoritos 
FOREIGN KEY (IdEquiposFavoritos) 
REFERENCES EquiposFavoritos(IdEquiposFavoritos)
ON DELETE CASCADE;

ALTER TABLE EquiposDeportistas
ADD CONSTRAINT FK_EquiposDeportistasEquipos
FOREIGN KEY (IdEquipo)
REFERENCES Equipos(IdEquipo)
ON DELETE CASCADE;

ALTER TABLE EquiposDeportistas
ADD CONSTRAINT FK_EquiposDeportistasDeportistas
FOREIGN KEY (IdPersona)
REFERENCES Deportistas(IdPersona)
ON DELETE CASCADE;

ALTER TABLE DeportesCategorizados
ADD CONSTRAINT FK_DeportesCategorizadosDeportes
FOREIGN KEY (IdDeporte)
REFERENCES Deportes(IdDeporte)
ON DELETE CASCADE;

ALTER TABLE DeportesCategorizados
ADD CONSTRAINT FK_DeportesCategorizadosCategorias
FOREIGN KEY (IdCategoria)
REFERENCES Categorias(IdCategoria)
ON DELETE CASCADE;

ALTER TABLE PuntuacionRound
ADD CONSTRAINT FK_PuntuacionRoundRound
FOREIGN KEY (NumeroRound, IdEncuentro)
REFERENCES Round(NumeroRound, IdEncuentro)
ON DELETE CASCADE;

ALTER TABLE Hito
ADD CONSTRAINT FK_HitoRound
FOREIGN KEY (NumeroRound, IdEncuentro)
REFERENCES Round(NumeroRound, IdEncuentro)
ON DELETE CASCADE;

ALTER TABLE EquiposEncuentros
ADD CONSTRAINT FK_EquiposEncuentrosEncuentros
FOREIGN KEY (IdEncuentro)
REFERENCES Encuentros(IdEncuentro)
ON DELETE CASCADE;

ALTER TABLE EquiposEncuentros
ADD CONSTRAINT FK_EquiposEncuentrosEquipos
FOREIGN KEY (IdEquipo)
REFERENCES Equipos(IdEquipo)
ON DELETE CASCADE;

ALTER TABLE Round
ADD CONSTRAINT FK_RoundEncuentros
FOREIGN KEY (IdEncuentro)
REFERENCES Encuentros(IdEncuentro)
ON DELETE CASCADE;

ALTER TABLE Encuentros
ADD CONSTRAINT FK_EncuentrosArbitros
FOREIGN KEY (IdPersona)
REFERENCES Arbitros(IdPersona);

ALTER TABLE EstadisticasJugador
ADD CONSTRAINT FK_EstadisticasJugadorDeportistas
FOREIGN KEY (IdDeportista)
REFERENCES Deportistas(IdPersona);

ALTER TABLE Usuarios
ADD CONSTRAINT CHK_Usuarios_NivelPermisos
CHECK (NivelPermisos >= 1 AND NivelPermisos <= 4);



INSERT INTO Publicidades (Banner, Link, TituloPublicidad) VALUES
('C:\Users\USUARIO\Downloads\Apple', 'https://www.apple.com/', 'Apple'),
('C:\Users\USUARIO\Pictures\Camera Roll', 'https://www.samsung.com/uy/', 'Samsung'),
('C:\Users\USUARIO\Documents\Sony', 'https://www.sony.es/', 'Sony'),
('C:\Users\USUARIO\Documents\Despegar', 'https://www.despegar.com.uy/', 'Despegar.com'),
('C:\Users\USUARIO\Videos\Sprite', 'https://www.coca-coladeuruguay.com.uy/marcas/sprite', 'Sprite'),
('C:\Users\USUARIO\Videos\Fanta', 'https://www.coca-coladeuruguay.com.uy/marcas/fanta', 'Fanta'),
('C:\Users\USUARIO\Videos\Smite', 'https://www.smitegame.com/', 'Smite'),
('C:\Users\USUARIO\Videos\Discord', 'https://discord.com/', 'Discord'),
('C:\Users\USUARIO\Videos\Sega', 'https://www.sega.es/', 'Sega'),
('C:\Users\USUARIO\Videos\Disney', 'https://disneylatino.com/', 'Disney'),
('C:\Users\USUARIO\Videos\Gatorade', 'https://www.gatorade.com/', 'Gatorade'),
('C:\Users\USUARIO\Videos\Duolingo', 'https://es.duolingo.com/', 'Duolingo'),
('C:\Users\USUARIO\Videos\Tramontina', 'https://www.tramontina.com.br/es', 'Tramontina'),
('C:\Users\USUARIO\Videos\Gotita', 'https://www.lagotita.com.uy/', 'Gotita'),
('C:\Users\USUARIO\Videos\Bimbo', 'https://www.grupobimbo.com/', 'Bimbo'),
('C:\Users\USUARIO\Videos\Mercedes', 'https://www.mercedes-benz.com.uy/', 'Mercedes'),
('C:\Users\USUARIO\Videos\Lacoste', 'https://global.lacoste.com/es/homepage', 'Lacoste'),
('C:\Users\USUARIO\Videos\Microsoft', 'https://www.microsoft.com/es-es', 'Microsoft'),
('C:\Users\USUARIO\Videos\Jameson', 'https://www.jamesonwhiskey.com', 'Jameson'),
('C:\Users\USUARIO\Videos\Tang', 'https://www.tang.com.uy/', 'Tang'),
('C:\Users\USUARIO\Videos\Volvo', 'https://www.volvocars.com/', 'Volvo');

INSERT INTO Personas (IdPersona, Nombre, Apellido, Nacionalidad) VALUES
('1', 'Alex', 'Sarasola', 'Uruguaya'),
('2', 'Perez', 'Gomez', 'Argentina'),
('3', 'Ana', 'Anniston', 'Estadounidense'),
('4', 'Lorenzo', 'DiCaprio', 'Italiana'),
('5', 'Teresa', 'Garcia', 'Mexicana'),
#Arbitros
('6', 'Lucas', 'Mariño', 'Uruguaya'),
('7', 'Eusebio', 'Martinez', 'Española'),
('8', 'Rita', 'Romero', 'Colombiana'),
('9', 'Ignacio', 'Nuñez', 'Brasileña'),
('10', 'Oriana', 'Pereira', 'Uruguaya'),
('11', 'Andre', 'Da Costa', 'Uruguaya'),
('12', 'Fernando', 'Buero', 'Irlandesa'),
('13', 'Erica', 'Filardi', 'Venezolana'),
('14', 'Rodrigo', 'Bartacovich', 'Rusa'),
('15', 'Camila', 'Bellati', 'Francesa'),
#Futbol
('16', 'Federico', 'Valverde', 'Uruguaya'),
('17', 'Luis', 'Suarez', 'Uruguaya'),
('18', 'Fernando', 'Muslera', 'Uruguaya'),
('19', 'Neymar', 'Da Silva Santos', 'Brasileña'),
('20', 'Lucas', 'Torreira', 'Uruguaya'),
('21', 'Mauro', 'Icardi', 'Argentina'),
('22', 'Diego', 'Forlan', 'Uruguaya'),
('23', 'Kylian', 'Mbappe', 'Francesa'),
('24', 'James', 'Rodriguez', 'Colombiana'),
('25', 'Pepe', 'Muñoz', 'Estadounidense'),
#Basquetbol
('26', 'Julio', 'Pereira', 'Brasileña'),
('27', 'Cesar', 'Cabral', 'Europea'),
('28', 'Nicolas', 'Piñeiro', 'Irlandesa'),
('29', 'Maicol', 'Rodriguez', 'Uruguaya'),
('30', 'Leticia', 'Romero', 'Boliviana'),
#Karate
('31', 'Franco', 'Reverdito', 'Española'),
('32', 'Esther', 'Niribao', 'Ecuatoriana'),
('33', 'Walter', 'Tonniolo', 'Peruana'),
('34', 'Valentin', 'Podesta', 'Mexicana'),
('35', 'Natalia', 'Gimenez', 'Italiana'),
#Natacion
('36', 'Alexander', 'Popov', 'Rusa'),
('37', 'Mark', 'Spitz', 'Chilena'),
('38', 'Jhonny', 'Weismuller', 'Puertoriqueña'),
('39', 'Inje', 'Bruijin', 'Canada'),
('40', 'Jenny', 'Thompson', 'Uruguaya'),
#TiroAlArco
('41', 'Antonio', 'Fernandez', 'Española'),
('42', 'Brady', 'Ellison', 'Africana'),
('43', 'Kim', 'Wojin', 'Japonesa'),
('44', 'Adriana', 'Martin', 'Española'),
('45', 'Miguel', 'Luz', 'Uruguaya'),
#Formula1
('46', 'Alberto', 'Ascari', 'Española'),
('47', 'Jackie', 'Stewart', 'Australiana'),
('48', 'Alain', 'Prost', 'Paraguaya'),
('49', 'Jim', 'Clark', 'Francesa'),
('50', 'Bill', 'Bukovich', 'Rusa'),
#Golf
('51', 'Tiger', 'Woods', 'Estadounidense'),
('52', 'Lee', 'Westwood', 'Italiana'),
('53', 'Martin', 'Kaymer', 'Angola'),
('54', 'Steve', 'Stricker', 'Turca'),
('55', 'Phil', 'Mickelson', 'Irani'),
#TiroAlPlato
('56', 'Xabier', 'Azpetia', 'India'),
('57', 'Pilar', 'Hudson', 'Canadiense'),
('58', 'Beto', 'Dembeto', 'Uruguaya'),
('59', 'Tony', 'Stark', 'Estadounidense'),
('60', 'Nick', 'Fury', 'Irlandesa'),
#TiroConPistola
('61', 'Norberto', 'De la Sol', 'Mexicano'),
('62', 'Nicole', 'Gonzalez', 'Canadiense'),
('63', 'Luana', 'Britos', 'Uruguaya'),
('64', 'Thanos', 'Talgico', 'Venezolana'),
('65', 'Ricar', 'Dito', 'Ucraniana'),
#Bolos
('66', 'Don', 'Carter', 'Argentino'),
('67', 'Julia', 'Gonzalez', 'Peruana'),
('68', 'Nila', 'Mento', 'Brasilera'),
('69', 'Toma', 'Tito', 'Caribeña'),
('70', 'Cristina', 'Gonzalez', 'Española'),
#Dardos
('71', 'Don', 'Jose', 'Argentino'),
('72', 'Marisel', 'Balvin', 'Colombiana'),
('73', 'Jocki', 'Chon', 'China'),
('74', 'Norma', 'Lines', 'Estadounidense'),
('75', 'Maria', 'De la Cruz', 'Egipcia'),
#TaiChi
('76', 'Jiffu', 'Kamada', 'Japonesa'),
('77', 'Po', 'Lian', 'Turco'),
('78', 'Tigresa', 'Ton', 'China'),
('79', 'Mantis', 'Tuti', 'Irani'),
('80', 'Mickey', 'Musca', 'Romana'),
#Judo
('81', 'Pibu', 'Tito', 'Irlandesa'),
('82', 'Rodrigo', 'Lemon', 'Argentino'),
('83', 'Ivanna', 'Noquiolo', 'Brasilera'),
('84', 'Ruben', 'Ado', 'Noruega'),
('85', 'Mini', 'Mouse', 'Italiana'),
#Taekwondo
('86', 'Bruce', 'Lee', 'China'),
('87', 'Jackie', 'Chan', 'Estadounidense'),
('88', 'Maria', 'Espinosa', 'Mexicana'),
('89', 'Servet', 'Tazegul', 'Noruega'),
('90', 'Jingyu', 'Wu', 'China'),
#MuayThai
('91', 'Buakaw ', 'Banchamek', 'China'),
('92', 'Filipović', 'Mart', 'Japonesa'),
('93', 'Sandoval', 'Anderson ', 'Brasilera'),
('94', 'Carano ', 'Ernesto ', 'Poonesia'),
('95', 'Dekkers', 'Ander ', 'India'),
#Sambo
('96', 'Shakira ', 'Gutierrez', 'Española'),
('97', 'Juan', 'Diaz', 'Mexicana'),
('98', 'Bruno', 'Daniels', 'Argentina'),
('99', 'Dario', 'Sosa', 'Polonesia'),
('100', 'Andres', 'Camargo', 'Canadiense'),
#JiuJitsu
('101', 'Brian', 'Gomez', 'Noruega'),
('102', 'Romeo', 'Santos', 'Argentina'),
('103', 'Maluma', 'Baby', 'Colombiana'),
('104', 'Jose', 'Jervasio', 'Indu'),
('105', 'Thomas', 'Shelby', 'Estadounidense'),
#Kickboxing
('106', 'Pedro', 'Picapiedra', 'Italiano'),
('107', 'Tulio', 'Mujica', 'Uruguay'),
('108', 'Tito', 'Bambino', 'Puertoriqueña'),
('109', 'Ester', 'Esposito', 'Española'),
('110', 'Melina', 'Nosebaña', 'Argentina'),
#Jiu Jitsu Brasileño
('111', 'Pelado', 'Caceres', 'Indu'),
('112', 'Alu', 'Nado', 'Irlandesa'),
('113', 'Bruno', 'Mars', 'Estadounidense'),
('114', 'Eduardo', 'Banardo', 'Inglesa'),
('115', 'Ricky', 'Martini', 'Bulgara'),
#Remo
('116', 'Remon', 'Golico', 'Ruso'),
('117', 'Remando', 'Lejos', 'Paraguaya'),
('118', 'Al Agua', 'Pato', 'Noruega'),
('119', 'Me', 'Ahogo', 'Española'),
('120', 'Rema', 'Nija', 'Uruguaya');


INSERT INTO Arbitros (IdPersona, Nombre, Apellido, Nacionalidad, Rol) VALUES
('6', 'Lucas', 'Mariño', 'Uruguaya', 'Arbitro en jefe'),
('7', 'Eusebio', 'Martinez', 'Española', 'Arbitro en jefe'),
('8', 'Rita', 'Romero', 'Colombiana', 'Arbitro en jefe'),
('9', 'Ignacio', 'Nuñez', 'Brasileña', 'Arbitro en jefe'),
('10', 'Oriana', 'Pereira', 'Uruguaya', 'Arbitro en jefe'),
('11', 'Andre', 'Da Costa', 'Uruguaya', 'Arbitro en jefe'),
('12', 'Fernando', 'Buero', 'Irlandesa', 'Arbitro en jefe'),
('13', 'Erica', 'Filardi', 'Venezolana', 'Arbitro en jefe'),
('14', 'Rodrigo', 'Bartacovich', 'Rusa', 'Arbitro en jefe'),
('15', 'Camila', 'Bellati', 'Francesa', 'Arbitro en jefe');
 
INSERT INTO Deportistas (IdPersona, Nombre, Apellido, Nacionalidad, EstadoJugador, Descripcion) VALUES
#Futbol
('16', 'Federico', 'Valverde', 'Uruguaya','Activo', 'Federico Santiago Valverde Dipetta, conocido deportivamente como Valverde, es un futbolista uruguayo que juega como centrocampista en el Real Madrid Club de Fútbol de la Primera División de España desde la temporada 2018-19. Es desde 2017 internacional absoluto con la selección uruguaya.'),
('17', 'Luis', 'Suarez', 'Uruguaya', 'Activo', 'Luis Alberto Suárez Díaz es un futbolista uruguayo que juega como delantero en el Club Nacional de Football del Campeonato Uruguayo de Primera División Profesional, y en la Selección de fútbol de Uruguay'),
('18', 'Fernando', 'Muslera', 'Uruguaya', 'Activo', 'Néstor Fernando Muslera Micol es un futbolista uruguayo nacido en Argentina. Juega de guardameta en el Galatasaray de la Superliga de Turquía.​'),
('19', 'Neymar', 'Da Silva Santos', 'Brasileña', 'Activo','Neymar da Silva Santos Júnior, conocido como Neymar Júnior o simplemente Neymar, es un futbolista brasileño que juega como delantero en el Paris Saint-Germain F. C. de la Ligue 1 de Francia, y en la selección de fútbol de Brasil'),
('20', 'Lucas', 'Torreira', 'Uruguaya', 'Activo', 'Lucas Sebastián Torreira di Pascua es un futbolista uruguayo que juega como centrocampista en el Galatasaray S. K. de la Superliga de Turquía.​ Es internacional absoluto con Uruguay desde 2018.'),
('21', 'Mauro', 'Icardi', 'Argentina','Activo','Mauro Icardi es un futbolista argentino. Juega como delantero y su equipo actual es el Galatasaray Spor Kulübü de la SüperLig. También es internacional con la selección argentina.​'),
('22', 'Diego', 'Forlan', 'Uruguaya', 'Inactivo', 'Diego Forlán Corazzo es un exfutbolista y actual entrenador uruguayo. Se desempeñaba como delantero o mediapunta. Obtuvo dos Botas de Oro en las temporadas 2004-2005 y 2008-2009, ​ además del Balón de Oro al mejor jugador del Mundial 2010, ​​ como también uno de los mejores futbolistas del Villarreal Club de Fútbol'),
('23', 'Kylian', 'Mbappe', 'Francesa', 'Activo', 'Mario Antonio Núñez Villarroel, exfutbolista chileno. Jugaba de delantero y actualmente está retirado. Es ídolo y tercer goleador histórico de O Higgins con 82 anotaciones'),
('24', 'James', 'Rodriguez', 'Colombiana', 'Activo', 'Arma casitas desde los 12 años y juega en el barcelona de delantero, tiene 28 años el pibe.'),
('25', 'Pepe', 'Muñoz', 'Estadounidense', 'Activo', 'Mas activo que nunca, Pepe tiene 30 años, juega en el Villareal, es vegano a muerte, miralo al pepe, vegano y jugando en el villa.'),
#Basquetbol
('26', 'Julio', 'Pereira', 'Brasileña', 'Activo', 'Tiene 26 años, juega en la NBA, Anda volando.'),
('27', 'Cesar', 'Cabral', 'Europea', 'Activo', 'Tiene 78 años, juega en la NBA, no se deje engañar, el viejo cesar trapea con todos en la cancha, lo ve el Lebron y no cae todavia.'),
('28', 'Nicolas', 'Piñeiro', 'Irlandesa', 'Activo', 'Tiene 19 años, juega en los Bulls, jovencito y bien rapidito, nana el rayo Mcqueen .'),
('29', 'Maicol', 'Rodriguez', 'Uruguaya', 'Activo', 'Tiene 32 años, juega en los Bulls, el rey del basquet, entrenado por el mismisimo Maicol Jordan.'),
('30', 'Leticia', 'Romero', 'Boliviana', 'Activo', 'Tiene 12 años, juega en la NBA, parece de no creer pero a esa edad y jugando en la NBA, tenes que ser muy bueno, na mentira es sobrino de Maicol Jordan, con razon lo dejaron entrar.'),
#Karate
('31', 'Franco', 'Reverdito', 'Española', 'Activo', 'Letal, todo un fiero, con 20 años y 80kg de puro musculo, fija el oponente y lo derriba de frente.'),
('32', 'Esther', 'Niribao', 'Ecuatoriana', 'Activo', 'La queen, toda una fiera, derriba a los oponentes sin pensarlo.'),
('33', 'Walter', 'Tonniolo', 'Peruana', 'Activo', 'Derriba a todos narrando la historia de como Socrates derroto a un dinosaurio que quedaba vivo con su espada magica.'),
('34', 'Valentin', 'Podesta', 'Mexicana', 'Activo', 'El mas malo de todos, no me preguntes porque ni le preguntes a el, porque el petizo de 120kg es un toro furioso.'),
('35', 'Natalia', 'Gimenez', 'Italiana', 'Activa', 'No muy conocida, pero re creida, la natalia que viene de italia, entrenada por el mismisimo Ratatuille o como se escriba, es de las mas peligrosas.'),
#Natacion
('36', 'Michael', 'Phelps', 'Rusa', 'Activo', null),
('37', 'Ian', 'Thorpe', 'Chilena', 'Activo', null),
('38', 'Jhonny', 'Weismuller', 'Puertoriqueña', 'Activo', null),
('39', 'Inje', 'Bruijin', 'Canada', 'Activo', null),
('40', 'Jenny', 'Thompson', 'Uruguaya', 'Activo', null),
#TiroAlArco
('41', 'Antonio', 'Fernandez', 'Española', 'Activo', null),
('42', 'Brady', 'Ellison', 'Africana', 'Activo', null),
('43', 'Kim', 'Wojin', 'Japonesa', 'Activo', null),
('44', 'Adriana', 'Martin', 'Española', 'Activo', null),
('45', 'Miguel', 'Luz', 'Uruguaya', 'Activo', null),
#Formula1
('46', 'George', 'Russell', 'Española', 'Activo', null),
('47', 'Lewis', 'Hamilton', 'Australiana', 'Activo', null),
('48', 'Alain', 'Prost', 'Paraguaya', 'Activo', null),
('49', 'Jim', 'Clark', 'Francesa', 'Activo', null),
('50', 'Bill', 'Bukovich', 'Rusa', 'Activo', null),
#Golf
('51', 'Tiger', 'Woods', 'Estadounidense', 'Activo', null),
('52', 'Lee', 'Westwood', 'Italiana', 'Activo', null),
('53', 'Martin', 'Kaymer', 'Angola', 'Activo', null),
('54', 'Steve', 'Stricker', 'Turca', 'Activo', null),
('55', 'Phil', 'Mickelson', 'Irani', 'Activo', null),
#TiroAlPlato
('56', 'Xabier', 'Azpetia', 'India', 'Activo', null),
('57', 'Pilar', 'Hudson', 'Canadiense', 'Activo', null),
('58', 'Beto', 'Dembeto', 'Uruguaya', 'Activo', null),
('59', 'Tony', 'Stark', 'Estadounidense', 'Activo', null),
('60', 'Nick', 'Fury', 'Irlandesa', 'Activo', null),
#TiroConPistola
('61', 'Norberto', 'De la Sol', 'Mexicano', 'Activo', null),
('62', 'Nicole', 'Gonzalez', 'Canadiense', 'Activo', null),
('63', 'Luana', 'Britos', 'Uruguaya', 'Activo', null),
('64', 'Thanos', 'Talgico', 'Venezolana', 'Activo', null),
('65', 'Ricar', 'Dito', 'Ucraniana', 'Activo', null),
#Bolos
('66', 'Don', 'Carter', 'Argentino', 'Activo', null),
('67', 'Julia', 'Gonzalez', 'Peruana', 'Activo', null),
('68', 'Nila', 'Mento', 'Brasilera', 'Activo', null),
('69', 'Toma', 'Tito', 'Caribeña', 'Activo', null),
('70', 'Cristina', 'Gonzalez', 'Española', 'Activo', null),
#Dardos
('71', 'Don', 'Jose', 'Argentino', 'Activo', null),
('72', 'Marisel', 'Balvin', 'Colombiana', 'Activo', null),
('73', 'Jocki', 'Chon', 'China', 'Activo', null),
('74', 'Norma', 'Lines', 'Estadounidense', 'Activo', null),
('75', 'Maria', 'De la Cruz', 'Egipcia', 'Activo', null),
#TaiChi
('76', 'Jiffu', 'Kamada', 'Japonesa', 'Activo', null),
('77', 'Po', 'Lian', 'Turco', 'Activo', null),
('78', 'Tigresa', 'Ton', 'China', 'Activo', null),
('79', 'Mantis', 'Tuti', 'Irani', 'Activo', null),
('80', 'Mickey', 'Musca', 'Romana', 'Activo', null),
#Judo
('81', 'Pibu', 'Tito', 'Irlandesa', 'Activo', null),
('82', 'Rodrigo', 'Lemon', 'Argentino', 'Activo', null),
('83', 'Ivanna', 'Noquiolo', 'Brasilera', 'Activo', null),
('84', 'Ruben', 'Ado', 'Noruega', 'Activo', null),
('85', 'Mini', 'Mouse', 'Italiana', 'Activo', null),
#Taekwondo
('86', 'Bruce', 'Lee', 'China', 'Activo', null),
('87', 'Jackie', 'Chan', 'Estadounidense', 'Activo', null),
('88', 'Maria', 'Espinosa', 'Mexicana', 'Activo', null),
('89', 'Servet', 'Tazegul', 'Noruega', 'Activo', null),
('90', 'Jingyu', 'Wu', 'China', 'Inactivo', null),
#MuayThai
('91', 'Buakaw ', 'Banchamek', 'China', 'Inactivo', null),
('92', 'Filipović', 'Mart', 'Japonesa', 'Inactivo', null),
('93', 'Sandoval', 'Anderson ', 'Brasilera', 'Inactivo', null),
('94', 'Carano ', 'Ernesto ', 'Poonesia', 'Activo', null),
('95', 'Dekkers', 'Ander ', 'India', 'Activo', null),
#Sambo
('96', 'Shakira ', 'Gutierrez', 'Española', 'Activo', null),
('97', 'Juan', 'Diaz', 'Mexicana', 'Activo', null),
('98', 'Bruno', 'Daniels', 'Argentina', 'Activo', null),
('99', 'Dario', 'Sosa', 'Polonesia', 'Activo', null),
('100', 'Andres', 'Camargo', 'Canadiense', 'Activo', null),
#JiuJitsu
('101', 'Brian', 'Gomez', 'Noruega', 'Activo', null),
('102', 'Romeo', 'Santos', 'Argentina', 'Activo', null),
('103', 'Maluma', 'Baby', 'Colombiana', 'Activo', null),
('104', 'Jose', 'Jervasio', 'Indu', 'Activo', null),
('105', 'Thomas', 'Shelby', 'Estadounidense', 'Activo', null),
#Kickboxing
('106', 'Pedro', 'Picapiedra', 'Italiano', 'Activo', null),
('107', 'Tulio', 'Mujica', 'Uruguay', 'Activo', null),
('108', 'Tito', 'Bambino', 'Puertoriqueña', 'Activo', null),
('109', 'Ester', 'Esposito', 'Española', 'Activo', null),
('110', 'Melina', 'Nosebaña', 'Argentina', 'Activo', null),
#Jiu Jitsu Brasileño
('111', 'Pelado', 'Caceres', 'Indu', 'Inactivo', null),
('112', 'Alu', 'Nado', 'Irlandesa', 'Inactivo', null),
('113', 'Bruno', 'Mars', 'Estadounidense', 'Activo', null),
('114', 'Eduardo', 'Banardo', 'Inglesa', 'Activo', null),
('115', 'Ricky', 'Martini', 'Bulgara', 'Inactivo', null),
#Remo
('116', 'Remon', 'Golico', 'Ruso', 'Activo', null),
('117', 'Remando', 'Lejos', 'Paraguaya', 'Activo', null),
('118', 'Al Agua', 'Pato', 'Noruega', 'Inactivo', null),
('119', 'Me', 'Ahogo', 'Española', 'Inactivo', null),
('120', 'Rema', 'Nija', 'Uruguaya', 'Activo', null);


INSERT INTO Equipos (IdEquipo, ImagenRepresentativa, PaisOrigen, NombreEquipo, TipoEquipo) VALUES
('1', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg','Uruguay', 'Uruguay', 'Seleccion'),
('2', 'C:\Users\USUARIO\Downloads\FranciaLogo.jpg', 'Francia', 'Francia', 'Seleccion'),
('3', 'C:\Users\USUARIO\Downloads\ColombiaLogo.jpg', 'Colombia', 'Colombia', 'Seleccion'),
('4', 'C:\Users\USUARIO\Downloads\GeorgeLogo.jpg','Inglaterra', 'George Russell', 'Individual'),
('5', 'C:\Users\USUARIO\Downloads\LewisLogo.jpg', 'Inglaterra', 'Lewis Hamilton', 'Individual'),
('6', 'C:\Users\USUARIO\Downloads\BruceLeeLogo.jpg', 'Estados Unidos', 'Bruce Lee', 'Individual'),
('7','C:\Users\USUARIO\Downloads\JackieChanLogo.jpg',  'China', 'Jackie Chan', 'Individual'),
('8', 'C:\Users\USUARIO\Downloads\MichaelPhelpsLogo.jpg', 'Estados Unidos', 'Michael Phelps', 'Individual'),
('9', 'C:\Users\USUARIO\Downloads\IanThorpeLogo.jpg', 'Australia', 'Ian Thorpe', 'Individual'),
('10',  'C:\Users\USUARIO\Downloads\BrasilLogo.jpg', 'Brasil', 'Brasil', 'Seleccion');

INSERT INTO EquiposDeportistas(IdEquipo, IdPersona, ImagenRepresentativa, PaisOrigen, NombreEquipo, EstadoJugador, Nombre, Apellido, Descripcion, TipoEquipo) VALUES
('1' , '16', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', 'Playing', 'Federico', 'Valverde', 'Federico Santiago Valverde Dipetta, conocido deportivamente como Valverde, es un futbolista uruguayo.', 'Seleccion'),
('1' , '17', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', 'Playing', 'Luis', 'Suarez', 'Luis Alberto Suárez Díaz es un futbolista uruguayo que juega como delantero en el Club Nacional de Football del Campeonato Uruguayo de Primera División Profesional, y en la Selección de fútbol de Uruguay', 'Seleccion'),
('1' , '18', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', 'Playing', 'Fernando', 'Muslera', 'Néstor Fernando Muslera Micol es un futbolista uruguayo nacido en Argentina. Juega de guardameta en el Galatasaray de la Superliga de Turquía', 'Seleccion'),
('1' , '20', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', 'Playing', 'Lucas', 'Torreira', 'Lucas Sebastián Torreira di Pascua es un futbolista uruguayo que juega como centrocampista en el Galatasaray S. K. de la Superliga de Turquía.​ Es internacional absoluto con Uruguay desde 2018', 'Seleccion'),
('10', '19', 'C:\Users\USUARIO\Downloads\BrasilLogo.jpg', 'Brasil', 'Brasil', 'Playing', 'Neymar', 'Da Silva Santos', 'Neymar da Silva Santos Júnior, conocido como Neymar Júnior o simplemente Neymar, es un futbolista brasileño que juega como delantero en el Paris Saint-Germain F. C. de la Ligue 1 de Francia, y en la selección de fútbol de Brasil', 'Seleccion'),
('2' , '23', 'C:\Users\USUARIO\Downloads\FranciaLogo.jpg', 'Francia', 'Francia', 'Playing', 'Kylian', 'Mbappe', 'Kylian Mbappé Lottin es un futbolista francés que juega como delantero en el Paris Saint-Germain F. C. de la Ligue 1. Comenzó su carrera con el club Mónaco de la Ligue 1, haciendo su debut profesional en 2015, a los 16 años', 'Seleccion'),
('3' , '24', 'C:\Users\USUARIO\Downloads\ColombiaLogo.jpg', 'Colombia', 'Colombia', 'Playing', 'James', 'Rodriguez', 'James David Rodríguez Rubio, conocido como James Rodríguez, es un futbolista colombiano que juega como centrocampista y su equipo actual es el Olympiacos F. C. de la Superliga de Grecia. Es internacional con la selección de Colombia.', 'Seleccion'),
('4' , '46','C:\Users\USUARIO\Downloads\GeorgeLogo.jpg','Inglaterra', 'George Russell', 'Playing', 'George', 'Russell', 'George William Russell es un piloto británico de automovilismo.​ Fue campeón de GP3 Series en 2017 y de Fórmula 2 en 2018. Desde 2019 hasta 2021 compitió para Williams en Fórmula 1.​ Desde 2022 es piloto de la escudería Mercedes-AMG Petronas.', 'Individual'),
('5' , '47','C:\Users\USUARIO\Downloads\LewisLogo.jpg', 'Inglaterra', 'Lewis Hamilton', 'Playing', 'Lewis', 'Hamilton', 'Lewis Carl Davidson Larbalestier Hamilton​​ es un piloto británico de automovilismo. En Fórmula 1 desde 2007 hasta 2012, fue piloto de la escudería McLaren, con la cual fue campeón en 2008 y subcampeón en 2007.', 'Individual'),
('6' , '86','C:\Users\USUARIO\Downloads\BruceLeeLogo.jpg', 'Estados Unidos', 'Bruce Lee', 'Playing', 'Bruce', 'Lee', 'Bruce Lee fue un artista marcial, maestro de artes marciales, actor, cineasta, filósofo y escritor estadounidense de origen hongkonés', 'Individual'),
('7' , '87','C:\Users\USUARIO\Downloads\JackieChanLogo.jpg',  'China', 'Jackie Chan', 'Playing', 'Jackie', 'Chan', 'Chan Kong-sang, ​conocido por su nombre artístico Jackie Chan, es un artista marcial, comediante, cantante, actor, acróbata, doble de acción, coordinador de dobles de acción, director, guionista, productor y actor de voz chino.', 'Individual'),
('8' , '36','C:\Users\USUARIO\Downloads\MichaelPhelpsLogo.jpg', 'Estados Unidos', 'Michael Phelps', 'Playing', 'Michael', 'Phelps', 'Michael Fred Phelps II​ es un exnadador olímpico estadounidense​ y el deportista olímpico más condecorado de todos los tiempos, con un total de 28 medallas.​ Phelps también posee los récords de más medallas olímpicas de oro, más medallas de oro en eventos individuales y más medallas olímpicas en eventos masculinos.', 'Individual'),
('9' , '37','C:\Users\USUARIO\Downloads\IanThorpeLogo.jpg', 'Australia', 'Ian Thorpe', 'Playing', 'Ian', 'Thorpe', 'Ian James Thorpe, AO, es un nadador australiano, apodado Thorpedo y Thorpey. Ganó cinco medallas de oro en Juegos Olímpicos, siendo la mayor marca conseguida por cualquier deportista australiano, y en 2001 se convirtió en la única persona en ganar seis medallas de oro en un solo Campeonato Mundial de Natación.​', 'Individual');


INSERT INTO Categorias (IdCategoria, NombreCategoria) VALUES
('1', 'Juegos de pelota'),
('2', 'Artes marciales'),
('3', 'Acuáticos'),
('4', 'Motorizados'),
('5', 'Aéros'),
('6', 'Estrategia'),
('7', 'Extremos'),
('8', 'Danza'),
('9', 'Atletismo'),
('10', 'Individuales'),
('11', 'De mesa'),
('12', 'Precision'),
('13', 'Deslizamiento'),
('14', 'De invierno'),
('15', 'Ciclismo');

INSERT INTO Deportes (IdDeporte, ImagenDeporte, Destacado, NombreDeporte) VALUES
('1', 'C:\Users\USUARIO\Downloads\PelotaFutbol.jpg', true, 'Futbol'),
('2', 'C:\Users\USUARIO\Downloads\PelotaBasquet.jpg', true, 'Basquetbol'),
('3', 'C:\Users\USUARIO\Downloads\PersonaM.jpg', false, 'Karate'),
('4', 'C:\Users\USUARIO\Downloads\PersonaN.jpg', true, 'Natación'),
('5', 'C:\Users\USUARIO\Downloads\Auto.jpg', true, 'Fórmula 1'),
('6', 'C:\Users\USUARIO\Downloads\Arco.jpg', false, 'Tiro al arco'),
('7', 'C:\Users\USUARIO\Downloads\Golf.jpg', false, 'Golf'),
('8', 'C:\Users\USUARIO\Downloads\Plato.jpg', false, 'Tiro al plato'),
('9', 'C:\Users\USUARIO\Downloads\Arma.jpg', false, 'Tiro con pistola'),
('10', 'C:\Users\USUARIO\Downloads\Bolos.jpg', false, 'Bolos'),
('11', 'C:\Users\USUARIO\Downloads\Dardo.jpg', false, 'Dardos'),
('12', 'C:\Users\USUARIO\Downloads\Tai-Chi.jpg', false, 'Tai Chi'),
('13', 'C:\Users\USUARIO\Downloads\Judo.jpg', false, 'Judo'),
('14', 'C:\Users\USUARIO\Downloads\Taekwondo.jpg', false, 'Taekwondo'),
('15', 'C:\Users\USUARIO\Downloads\Muay-Thay.jpg', false, 'Muay Thay'),
('16', 'C:\Users\USUARIO\Downloads\Sambo.jpg', false, 'Sambo'),
('17', 'C:\Users\USUARIO\Downloads\JiuJitsu.jpg', false, 'Jiu Jitsu'),
('18', 'C:\Users\USUARIO\Downloads\KickBoxing.jpg', true, 'KickBoxing'),
('19', 'C:\Users\USUARIO\Downloads\JiuJitsuBrasileño.jpg', false, 'Jiu Jitsu Brasileño'),
('20', 'C:\Users\USUARIO\Downloads\Remo.jpg', false, 'Remo'),
('21', 'C:\Users\USUARIO\Downloads\EsquiAcuatico.jpg', false, 'Esqui Acuatico'),
('22', 'C:\Users\USUARIO\Downloads\Motonautica.jpg', false, 'Motonautica'),
('23', 'C:\Users\USUARIO\Downloads\JetSki.jpg', false, 'Jet Ski'),
('24', 'C:\Users\USUARIO\Downloads\Buceo.jpg', false, 'Buceo'),
('25', 'C:\Users\USUARIO\Downloads\Canoa.jpg', false, 'Canoa'),
('26', 'C:\Users\USUARIO\Downloads\KayakPolo.jpg', false, 'Kayak-Polo'),
('27', 'C:\Users\USUARIO\Downloads\Rally.jpg', true, 'Rally'),
('28', 'C:\Users\USUARIO\Downloads\Motocross.jpg', true, 'Motocross'),
('29', 'C:\Users\USUARIO\Downloads\Drifting.jpg', false, 'Drifting'),
('30', 'C:\Users\USUARIO\Downloads\Snocross.jpg', false, 'Snocross'),
('31', 'C:\Users\USUARIO\Downloads\Enduro.jpg', false, 'Enduro'),
('32', 'C:\Users\USUARIO\Downloads\Tenis.jpg', true, 'Tenis'),
('33', 'C:\Users\USUARIO\Downloads\Beisbol.jpg', true, 'Beisbol'),
('34', 'C:\Users\USUARIO\Downloads\Rugby.jpg', true, 'Rugby'),
('35', 'C:\Users\USUARIO\Downloads\Voleibol.jpg', false, 'Voleibol');

INSERT INTO DeportesCategorizados (IdDeporte, IdCategoria, ImagenDeporte, Destacado, NombreDeporte, NombreCategoria) VALUES
('1', '1', 'C:\Users\USUARIO\Downloads\PelotaFutbol.jpg', true, 'Futbol', 'Juegos de pelota'),
('2', '1', 'C:\Users\USUARIO\Downloads\PelotaBasquet.jpg', true, 'Basquetbol', 'Juegos de basquet'),
('3', '2', 'C:\Users\USUARIO\Downloads\PersonaM.jpg', false, 'Karate', 'Artes marciales'),
('4', '3', 'C:\Users\USUARIO\Downloads\PersonaN.jpg', true, 'Natación', 'Acuáticos'),
('5', '4', 'C:\Users\USUARIO\Downloads\Auto.jpg', true, 'Fórmula 1', 'Motorizados'),
('6', '12', 'C:\Users\USUARIO\Downloads\Arco.jpg', true, 'Tiro al arco', 'Precision'),
('7', '1', 'C:\Users\USUARIO\Downloads\Golf.jpg', true, 'Golf', 'Juegos de pelota'),
('8', '12', 'C:\Users\USUARIO\Downloads\Plato.jpg', false, 'Tiro al plato', 'Precision'),
('9', '12', 'C:\Users\USUARIO\Downloads\Arma.jpg', true, 'Tiro con pistola', 'Precision'),
('10', '1','C:\Users\USUARIO\Downloads\Bolos.jpg', false, 'Bolos', 'Juegos de pelota'),
('11', '12', 'C:\Users\USUARIO\Downloads\Dardo.jpg', true, 'Dardos', 'Precision'),
('12', '2', 'C:\Users\USUARIO\Downloads\Tai-Chi.jpg', false, 'Tai Chi', 'Artes marciales'),
('13', '2', 'C:\Users\USUARIO\Downloads\Judo.jpg', false, 'Judo', 'Artes marciales'),
('14', '2', 'C:\Users\USUARIO\Downloads\Taekwondo.jpg', true, 'Taekwondo', 'Artes marciales'),
('15', '2', 'C:\Users\USUARIO\Downloads\Muay-Thay.jpg', true, 'Muay Thay', 'Artes marciales'),
('16', '2', 'C:\Users\USUARIO\Downloads\Sambo.jpg', true, 'Sambo', 'Artes marciales'),
('17', '2', 'C:\Users\USUARIO\Downloads\JiuJitsu.jpg', true, 'Jiu Jitsu', 'Artes marciales'),
('18', '2', 'C:\Users\USUARIO\Downloads\KickBoxing.jpg', true, 'KickBoxing', 'Artes marciales'),
('19', '2', 'C:\Users\USUARIO\Downloads\JiuJitsuBrasileño.jpg', true, 'Jiu Jitsu Brasileño', 'Artes marciales'),
('20', '3', 'C:\Users\USUARIO\Downloads\Remo.jpg', false, 'Remo', 'Acuáticos'),
('21', '3', 'C:\Users\USUARIO\Downloads\EsquiAcuatico.jpg', false, 'Esqui Acuatico', 'Acuáticos'),
('22', '4', 'C:\Users\USUARIO\Downloads\Motonautica.jpg', true, 'Motonautica', 'Motorizados'),
('23', '4', 'C:\Users\USUARIO\Downloads\JetSki.jpg', false, 'Jet Ski', 'Motorizados'),
('24', '3', 'C:\Users\USUARIO\Downloads\Buceo.jpg', true, 'Buceo', 'Acuáticos'),
('25', '3', 'C:\Users\USUARIO\Downloads\Canoa.jpg', false, 'Canoa', 'Acuáticos'),
('26', '3', 'C:\Users\USUARIO\Downloads\KayakPolo.jpg', true, 'Kayak-Polo', 'Acuáticos'),
('27', '4', 'C:\Users\USUARIO\Downloads\Rally.jpg', true, 'Rally', 'Motorizados'),
('28', '4', 'C:\Users\USUARIO\Downloads\Motocross.jpg', true, 'Motocross', 'Motorizados'),
('29', '4', 'C:\Users\USUARIO\Downloads\Drifting.jpg', true, 'Drifting', 'Motorizados'),
('30', '4', 'C:\Users\USUARIO\Downloads\Snocross.jpg', false, 'Snocross', 'Motorizados'),
('31', '4', 'C:\Users\USUARIO\Downloads\Enduro.jpg', true, 'Enduro', 'Motorizados'),
('32', '1', 'C:\Users\USUARIO\Downloads\Tenis.jpg', true, 'Tenis', 'Juegos de pelota'),
('33', '1', 'C:\Users\USUARIO\Downloads\Beisbol.jpg', true, 'Beisbol', 'Juegos de pelota'),
('34', '1', 'C:\Users\USUARIO\Downloads\Rugby.jpg', true, 'Rugby', 'Juegos de pelota'),
('35', '1', 'C:\Users\USUARIO\Downloads\Voleibol.jpg', false, 'Voleibol', 'Juegos de pelota');

INSERT INTO Encuentros (IdEncuentro, IdDeporte, IdCategoria, IdPersona, Hora, Lugar, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima, TipoEncuentro) VALUES
('1', '1', '1', '6', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null, '1'),
('2', '3', '2', '7', '19:22', 'Dojo escondido entre los arbustos', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado', '1'),
('3', '5', '4', '8', '03:25', 'Av.18 de julio', '2022-09-1', 'Campeonato Mundial de formula1', 'In progress', 'Despejado', '1'),
('4', '1', '1', '9', '16:44', 'Estadio peñarol', '2021-04-30', 'Amistoso', 'Finished', 'Soleado', '1'),
('5', '4', '3', '10', '03:33', 'Asociación cristiana de jovenes', '2022-12-12', 'Competición de natación', 'Coming soon', null, '1');

INSERT INTO EquiposEncuentros (IdEncuentro, IdDeporte, IdCategoria, IdPersona, IdEquipo, Hora, Lugar, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima, ImagenRepresentativa, PaisOrigen, NombreEquipo, Puntuacion, Posicion, Alineacion, TipoEquipo, TipoEncuentro) VALUES
('1', '1', '1', '6', '1', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', '1', '1', 'C:\Users\USUARIO\Downloads\UruguayAlineacion.jpg', 'Seleccion', '1'),
('1', '1', '1', '6', '10', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\BrasilLogo.jpg', 'Brasil', 'Brasil', '3', '2', 'C:\Users\USUARIO\Downloads\BrasilAlineacion.jpg', 'Seleccion', '1'),
('2', '3', '2', '7', '6', '19:22', 'Lucha Karate', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado', 'C:\Users\USUARIO\Downloads\BruceLee.jpg', 'Estados Unidos','Bruce Lee', '4', null, null, 'Individual', '1'),
('2', '3', '2', '7', '7', '19:22', 'Lucha Karate', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado', 'C:\Users\USUARIO\Downloads\JackieChan.jpg', 'China', 'Jackie Chan', null, '3', 'C:\Users\USUARIO\Downloads\ChinaAlineacion.jpg', 'Individual', '1'),
('3', '5', '4', '8', '4', '03:25', 'Av.18 de julio', '2022-09-1', 'Campeonato Mundial de formula1', 'In progress', 'Despejado', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Inglaterra', 'George Russell', null, '4', 'C:\Users\USUARIO\Downloads\CarreraAlineacion.jpg', 'Individual', '1'),
('3', '5', '4', '8', '5', '03:25', 'Av.18 de julio', '2022-09-1', 'Campeonato Mundial de formula1', 'In progress', 'Despejado', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Inglaterra', 'Lewis Hamilton', null, '5', 'C:\Users\USUARIO\Downloads\CarreraAlineacion.jpg', 'Individual', '1'),
('4', '1', '1', '9', '2', '16:44', 'Estadio peñarol', '2021-04-30', 'Amistoso', 'Finished', 'Soleado', 'C:\Users\USUARIO\Downloads\FranciaLogo.jpg', 'Francia', 'Francia', null, '7', 'C:\Users\USUARIO\Downloads\FranciaAlineacion.jpg', 'Seleccion', '1'),
('4', '1', '1', '9', '3', '16:44', 'Estadio peñarol', '2021-04-30', 'Amistoso', 'Finished', 'Soleado', 'C:\Users\USUARIO\Downloads\ColombiaLogo.jpg', 'Colombia', 'Colombia', null, '8', 'C:\Users\USUARIO\Downloads\ColombiaAlineacion.jpg', 'Seleccion', '1'),
('5', '4', '3', '10', '8', '03:33', 'Asociación cristiana de jovenes', '2022-12-12', 'Competición de natación', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\MichaelPhelps.jpg', 'Estados Unidos', 'Michael Phelps', null, null, 'C:\Users\USUARIO\Downloads\NatacionAlineacion.jpg','Individual', '1'),
('5', '4', '3', '10', '9', '03:33', 'Asociación cristiana de jovenes', '2022-12-12', 'Competición de natación', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\IanThorpe.jpg', 'Australia', 'Ian Thorpe', null, null, 'C:\Users\USUARIO\Downloads\AustraliaAlineacion.jpg','Individual', '1');

INSERT INTO Round (NumeroRound, IdEncuentro, TiempoTranscurridoRound, IdPuntuacionRound, IdHito) VALUES
('1', '1', '00:45:00', '1', '1'),
('2', '1', '00:45:00', '2', '2'),
('1', '4', '00:15:00', '3', '3'),
('2', '4', '00:15:00', '4', '4'),
('3', '4', '00:15:00', '5', '5'),
('4', '4', '00:15:00', '6', '6'),
('1', '2', '00:10:12', '7', '7'),
('2', '2', '00:09:43', '8', '8'),
('3', '2', '00:14:15', '9', '9'),
('4', '2', '00:08:31', '10', '10'),
('5', '2', '00:03:38', '11', '11'),
('6', '2', '00:07:56', '12', '12'),
('1', '3', '01:12:12', '13', '13'),
('1', '5', '00:33:42', '14', '14');

INSERT INTO PuntuacionRound (IdPuntuacionRound, NumeroRound, IdEncuentro, Puntos, IdEquipo) VALUES
('1', '1', '1', '1', '1919'),
('2', '2', '1', '3', '1900'),
('3', '1', '4', '67', '4'),
('4', '2', '4', '78', '5'),
('5', '3', '4', '87', '4'),
('6', '4', '4', '104', '5'),
('7', '1', '2', '43', '32'),
('8', '2', '2', '56', '33'),
('9', '3', '2', '32', '32'),
('10', '4', '2', '15', '33'),
('11', '5', '2', '18', '32'),
('12', '6', '2', '32', '33'),
('13', '1', '3', null, '16'),
('14', '1', '5', null, '287');

INSERT INTO Hito (IdHito, NumeroRound, IdEncuentro, TituloHito, TiempoHito) VALUES
('1', '1', '1', 'Falta', '00:32:54'),
('2', '2', '1', 'Cambio', '00:27:34'),
('3', '1', '4', 'Falta', '00:12:21'),
('4', '2', '4', 'Tiro Libre', '00:07:51'),
('5', '3', '4', 'Falta', '00:03:11'),
('6', '4', '4', 'Cambio', '00:06:17'),
('7', '1', '2', 'Fin round', '00:10:12'),
('8', '2', '2', 'Fin round', '00:09:43'),
('9', '3', '2', 'Fin round', '00:14:15'),
('10', '4', '2', 'Fin round', '00:08:31'),
('11', '5', '2', 'Fin round', '00:03:38'),
('12', '6', '2', 'Fin round', '00:07:56'),
('13', '1', '3', 'Choque', '00:54:25'),
('14', '1', '5', 'Finaliza', '00:33:42');

INSERT INTO Eventos (IdEvento, FechaEvento, NombreEvento, HoraEvento, EstadoEvento, LogoEvento, LugarEvento) VALUES
('1', '2024-03-21', 'Copa Libertadores de America', '21:00', 'Coming soon', 'C:\Users\USUARIO\Downloads\CopaAmericaLogo.jpg', 'Estadio de Brasilia'),
('2', '2021-06-13', 'Evento beneficiario', '14:20', 'Finished', 'C:\Users\USUARIO\Downloads\TeletonLogo.jpg', 'Centro de ayuda'),
('3', '2022-04-30', 'Copa sin fin', '23:59', 'In progress', 'C:\Users\USUARIO\Downloads\InfinitoLogo.jpg', 'Borde'),
('4', '2023-01-3', 'Campeonato x', '03:50', 'Coming soon', 'C:\Users\USUARIO\Downloads\XLogo.jpg', 'Club X'),
('5', '2022-10-18', 'Campeonato de ajedrez ruso', '17:00', 'Coming soon', 'C:\Users\USUARIO\Downloads\AjedrezRusoLogo.jpg', 'Casa floreada');

INSERT INTO Fases (NumeroFase, IdEvento, EstadoFase, NombreFase, Fecha, Tipofase, TamañoGrupos) VALUES
('1', '1', 'En curso', 'Grupo A', '2022-12-2', '1', '2'),
('1', '4', 'En curso', 'Grupo B', '2034-10-19', '1', '1'),
('1', '2', 'Por venir', 'Grupo C', '2012-10-16', '1', '2'),
('1', '5', 'Ya casi viene', 'Grupo D', '2029-03-16', '1', '2'),
('1', '3', 'Casi casi', 'Grupo D', '2029-03-16', '1', '2');

INSERT INTO EncuentrosFases (IdEncuentro, NumeroFase, IdEvento, IdDeporte, IdCategoria, IdPersona, Hora, Lugar, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima, TipoEncuentro, EstadoFase, NombreFase, Fecha, Tipofase, Puntaje, Posicion, TamañoGrupos) VALUES
('1', '1', '1', '1', '1', '6', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null, '1', 'En curso', 'Grupo A', '2022-12-2', '1', '0', '1', '2'),
('2', '3', '1', '4', '2', '7', '19:22', 'Dojo escondido entre los arbustos', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado', '1', 'En curso', 'Grupo B', '2034-10-19', '1', '0', '1', '2'),
('3', '1', '2', '5', '4', '8', '03:25', 'Av.18 de julio', '2022-09-1', 'Campeonato Mundial de formula1', 'In progress', 'Despejado', '1', 'Por venir', 'Grupo C', '2012-10-16', '3', '0', '1', '2');

INSERT INTO EquiposFases(IdEquipo, NumeroFase, IdEvento, ImagenRepresentativa, PaisOrigen, NombreEquipo, EstadoFase, NombreFase, Fecha, PosicionEquipo, EstadoEquipo, Puntaje, TipoEquipo, Tipofase, TamañoGrupos) VALUES 
('1', '1', '1', 'C:\Users\USUARIO\Downloads\EquipoUruguayLogo.jpg', 'Uruguay', 'Uruguay', 'En curso', 'Grupo A', '2022-12-2', '1', 'Jugando', null, 'Seleccion', '1', '2'),
('10', '1', '1', 'C:\Users\USUARIO\Downloads\EquipoBrasilLogo.jpg', 'Brasil', 'Brasil', 'En curso', 'Grupo A', '2022-12-2', '1', 'Jugando', null, 'Seleccion', '1', '2'),
('9', '1', '3', 'C:\Users\USUARIO\Downloads\IanThorpeLogo.jpg', 'Autralia', 'Ian Thorpe', 'En curso', 'Grupo B', '2022-10-2', '1', 'Jugando', null, 'Individual', '1', '2'),
('8', '1', '3', 'C:\Users\USUARIO\Downloads\MichaelPhelpsLogo.jpg', 'Estados Unidos', 'Michael Phelps', 'En curso', 'Grupo B', '2022-10-2', '1', 'Jugando', null, 'Individual', '1', '2');

INSERT INTO EstadisticasJugador (IdEstadisticasJugador, IdEncuentro, Anotacion, Faltas, IdDeportista) VALUES
('1', '1', '3', '1', '16' ),
('2', '3', '1', '0', '46' ),
('3', '4', '3', '4', '23' ),
('4', '5', '3', '2', '36' );

INSERT INTO EventosFavoritos (IdEventosFavoritos, IdEvento, Email) VALUES
('1', '1', 'alexelleon2018@gmail.com'),
('2', '4', 'perezgomez45@gmail.com'),
('3', '3', 'analaurali@gmail.com'),
('4', '2', 'loloOne@gmail.com'),
('5', '2', 'lolaFive@gmail.com'),
('6', '5', 'admin@certus.com');
 
INSERT INTO EncuentrosFavoritos (IdEncuentrosFavoritos, IdEncuentro, Email) VALUES
('1', '1', 'alexelleon2018@gmail.com'),
('2', '3', 'perezgomez45@gmail.com'),
('3', '4', 'analaurali@gmail.com'),
('4', '5', 'loloOne@gmail.com'),
('5', '3', 'lolaFive@gmail.com'),
('6', '2', 'admin@certus.com');
 
INSERT INTO EquiposFavoritos (IdEquiposFavoritos, IdEquipo, Email) VALUES
('1', '1', 'alexelleon2018@gmail.com'),
('2', '5', 'perezgomez45@gmail.com'),
('3', '4', 'analaurali@gmail.com'),
('4', '10', 'loloOne@gmail.com'),
('5', '6', 'lolaFive@gmail.com'),
('6', '1', 'admin@certus.com'),
('7', '5', 'sinclair@hotmail.com'),
('8', '9', 'elseñordelaesquinaquevendetortafritas@gmail.com'),
('9', '8', 'Mufasa@gmail.com'),
('10', '7', 'simba@gmail.com');
 
INSERT INTO Usuarios (Email, NombreUsuario, Contraseña, NumeroTelefono, NivelPermisos, IdEventosFavoritos, IdEncuentrosFavoritos, IdEquiposFavoritos) values
('alexelleon2018@gmail.com', 'Alex001', 'Nomeacuerdomucho1234*', '092038170', '2', '1', '1', '1'),
('perezgomez45@gmail.com', 'perezito2233', 'estudiomucho90<<', '099456743', '1', '2', '2', '2'),
('analaurali@gmail.com', 'Lauranole2', 'altabaja221', '099445274', '2', '3', '3', '3'),
('loloOne@gmail.com', 'Elfaraon03', 'faraon03-', '092345221', '1', '4', '4', '4'),
('lolaFive@gmail.com', 'TheQueen121', 'fordescort1967>', '095567451', '1', '5', '5', '5'),
('admin@certus.com', 'Administrador', 'VS5CDbf6VrwLLxubdW0qRg==', null, '4', '6', '1', '6'),
('sinclair@hotmail.com', 'Simond', 'Badminton', 097862376, '2', '1', '1', '1'),
('subdito1@gmail.com', 'Subdito1', 'sub1', null, '3', '1', '1', '1'),
('señorarandom@gmail.com', 'Señora Random', 'haygentequerealmenteseponeestetipodenombres', 099999999, '1', '1', '1', '1'),
('elseñordelaesquinaquevendetortafritas@gmail.com', 'El tortafritero', 'Lasmejorestortafritasdelazonalaesquinadelautu', 091919191, '2', '1', '1', '1'),
('Tramontina@gmail.com', 'Tramontina', '826592659', 091657365, '1', '1', '1', '1'),
('simba@gmail.com', 'Simba', 'amipapaunñu', 095565676, '1', '1', '1', '1'),
('guillermoperez@gmail.com', 'El guille', 'alpaca', 093242381, '2', '2', '2', '2'),
('volar@gmail.com', 'Volar', 'violin', 091234623, '1', '1', '1', '1'),
('Cacatua@gmail.com', 'Cacatua', 'sacala1234', 091233453, '2', '1', '1', '1'),
('Cilnantro@gmail.com', 'Pepino', '3nsalad4', 097843777, '1', '1', '1', '1'),
('Sombra@gmail.com', 'Darker', 'Oscuridad', 092766246, '1', '1', '1', '1'),
('Mufasa@gmail.com', 'Mufasa', 'todoculpademihijo', 098324324, '1', '1', '1', '1'),
('Scar@gmail.com', 'Scar', 'ahorasoyadminXD', 094828434, '2', '1', '1', '1'),
('Lahyena@gmail.com', 'Hyena', 'MufasaUHHH', 091234123, '1', '1', '1', '1'),
('Nala@gmail.com', 'Nala', 'simbatutiomecaemal', 092344623, '1', '1', '1', '1'),
('Timon@gmail.com', 'Timon', 'insectosdebajodeltronco', 092363423, '1', '1', '1', '1'),
('Pumba@gmail.com', 'Pumba', 'troncoencimadelosinsectos', 093563423, '1', '1', '1', '1'),
('Rafiki@gmail.com', 'Rafiki', 'lasfrutasdelotrodiaestabansimba', null, '1', '1', '1', '1'),
('korino300@gmail.com', 'Hinoken', 'dragonoy300', 095243013, '2', '1', '1', '1'),
('Bastion@gmail.com', 'Vanguard', 'torreA4', 099939999, '1', '1', '1', '1'),
('Gaston1234@gmail.com', 'Gasty', '7261726', null, '1', '1', '1', '1'),
('Leonidas@gmail.com', 'Leo', 'termopilas', null, '2', '1', '1', '1'),
('Salazar@gmail.com', 'Salado', 'rimaters', 094527465, '1', '1', '1', '1'),
('Gimoteo@gmail.com', 'Gimoteo', 'it5f374fgyedxdb63664frh44', 092454374, '1', '1', '1', '1'),
('Lacoste@gmail.com', 'Lacoste', 'etsocal', null, '2', '1', '1', '1'),
('koala@gmail.com', 'koala', 'panda', 093053242, '1', '1', '1', '1'),
('rriittoo@gmail.com', 'Rito', 'ritual', 096268834, '1', '1', '1', '1'),
('Lucas1@gmail.com', 'Lucas', 'Elprimero', 091111111, '1', '1', '1', '1'),
('Lucas2@gmail.com', 'Lucas2', 'Elsegundo', 092222222, '1', '1', '1', '1'),
('Lucas3@gmail.com', 'Lucas3', 'Eltercero', 093333333, '1', '1', '1', '1'),
('Gerardo@gmail.com', 'Geo', 'laspiedras', 094625375, '1', '1', '1', '1'),
('ImagineDragons@gmail.com', 'Imagine', 'dragons', 091234567, '2', '1', '1', '1'),
('Desmond@gmail.com', 'Des', 'mond', 094636342, '1', '1', '1', '1'),
('Timoteo@gmail.com', 'Titi', 'teoteo', 093517352, '1', '1', '1', '1'),
('ZhangChu@gmail.com', 'Ah', 'Chu', 093615225, '1', '1', '1', '1'),
('Termodinamics@gmail.com', 'Im', 'boring', null, '1', '1', '1', '1'),
('Gelato@gmail.com', 'Helado', 'delimon', null, '1', '1', '1', '1'),
('Jason@gmail.com', 'Json', 'martes13', 091313131, '1', '1', '1', '1'),
('Kerosen@gmail.com', 'Kero', 'fire', 097474479, '1', '1', '1', '1'),
('Michi@gmail.com', 'Elmichi', 'karennomedadecomer', null, '1', '1', '1', '1'),
('Karen@gmail.com', 'Karen', 'misifusmiente', 095236756, '1', '1', '1', '1'),
('Lucas4@gmail.com', 'Lucas4', 'Elcuarto', 094444444, '1', '1', '1', '1'),
('Lucas5@gmail.com', 'Lucas5', 'Elquinto', 095555555, '1', '1', '1', '1'),
('Lucas6@gmail.com', 'Lucas6', 'Elsexto', 096666666, '1', '1', '1', '1'),
('Fiss@gmail.com', 'Freeze', 'Freezer', 093247242, '1', '1', '1', '1');

INSERT INTO PublicidadesUsuarios (IdPublicidad, Email, NombreUsuario, Contraseña, NumeroTelefono, NivelPermisos, Banner, Link, TituloPublicidad, IdEventosFavoritos, IdEncuentrosFavoritos, IdEquiposFavoritos) VALUES
('1', 'loloOne@gmail.com', 'Elfaraon03', 'faraon03-', '092345221', '1', 'C:\Users\USUARIO\Downloads\Apple', 'https://www.apple.com/', 'Apple', '4', '4', '4'),
('1', 'lolaFive@gmail.com', 'TheQueen121', 'fordescort1967>', '095567451', '1', 'C:\Users\USUARIO\Downloads\Apple', 'https://www.apple.com/', 'Apple', '5', '5', '5'),
('2', 'Tramontina@gmail.com', 'Tramontina', '826592659', 091657365, '1', 'C:\Users\USUARIO\Pictures\Camera Roll', 'https://www.samsung.com/uy/', 'Samsung', '1', '1', '1'),
('3', 'simba@gmail.com', 'Simba', 'amipapaunñu', 095565676, '1', 'C:\Users\USUARIO\Documents\Sony', 'https://www.sony.es/', 'Sony', '1', '1', '1'),
('4', 'volar@gmail.com', 'Volar', 'violin', 091234623, '1', 'C:\Users\USUARIO\Documents\Despegar', 'https://www.despegar.com.uy/', 'Despegar.com', '1', '1', '1'),
('5', 'Cilnantro@gmail.com', 'Pepino', '3nsalad4', 097843777, '1', 'C:\Users\USUARIO\Videos\Sprite', 'https://www.coca-coladeuruguay.com.uy/marcas/sprite', 'Sprite', '1', '1', '1'),
('5', 'perezgomez45@gmail.com', 'perezito2233', 'estudiomucho90<<', '099456743', '1', 'C:\Users\USUARIO\Videos\Sprite', 'https://www.coca-coladeuruguay.com.uy/marcas/sprite', 'Sprite', '1', '1', '1'),
('5', 'Sombra@gmail.com', 'Darker', 'Oscuridad', 092766246, '1', 'C:\Users\USUARIO\Videos\Sprite', 'https://www.coca-coladeuruguay.com.uy/marcas/sprite', 'Sprite',  '1', '1', '1'),
('1', 'Mufasa@gmail.com', 'Mufasa', 'todoculpademihijo', 098324324, '1', 'C:\Users\USUARIO\Downloads\Apple', 'https://www.apple.com/', 'Apple', '1', '1', '1'),
('6', 'Lahyena@gmail.com', 'Hyena', 'MufasaUHHH', 091234123, '1', 'C:\Users\USUARIO\Videos\Fanta', 'https://www.coca-coladeuruguay.com.uy/marcas/fanta', 'Fanta', '1', '1', '1'),
('7', 'Nala@gmail.com', 'Nala', 'simbatutiomecaemal', 092344623, '1', 'C:\Users\USUARIO\Videos\Smite', 'https://www.smitegame.com/', 'Smite', '1', '1', '1'),
('8', 'Timon@gmail.com', 'Timon', 'insectosdebajodeltronco', 092363423, '1', 'C:\Users\USUARIO\Videos\Discord', 'https://discord.com/', 'Discord', '1', '1', '1'),
('9', 'Pumba@gmail.com', 'Pumba', 'troncoencimadelosinsectos', 093563423, '1', 'C:\Users\USUARIO\Videos\Sega', 'https://www.sega.es/', 'Sega',  '1', '1', '1'),
('10', 'Rafiki@gmail.com', 'Rafiki', 'lasfrutasdelotrodiaestabansimba', null, '1','C:\Users\USUARIO\Videos\Disney', 'https://disneylatino.com/', 'Disney', '1', '1', '1'),
('11', 'Bastion@gmail.com', 'Vanguard', 'torreA4', 099999999, '1', 'C:\Users\USUARIO\Videos\Gatorade', 'https://www.gatorade.com/', 'Gatorade', '1', '1', '1'),
('12', 'Gaston1234@gmail.com', 'Gasty', '7261726', null, '1', 'C:\Users\USUARIO\Videos\Duolingo', 'https://es.duolingo.com/', 'Duolingo', '1', '1', '1'),
('13', 'Salazar@gmail.com', 'Salado', 'rimaters', 094527465, '1', 'C:\Users\USUARIO\Videos\Tramontina', 'https://www.tramontina.com.br/es', 'Tramontina', '1', '1', '1'),
('14', 'Gimoteo@gmail.com', 'Gimoteo', 'it5f374fgyedxdb63664frh44', 092454374, '1', 'C:\Users\USUARIO\Videos\Gotita', 'https://www.lagotita.com.uy/', 'Gotita',  '1', '1', '1'),
('15', 'koala@gmail.com', 'koala', 'panda', 093053242, '1', 'C:\Users\USUARIO\Videos\Bimbo', 'https://www.grupobimbo.com/', 'Bimbo', '1', '1', '1'),
('16', 'Desmond@gmail.com', 'Des', 'mond', 094636342, '1', 'C:\Users\USUARIO\Videos\Mercedes', 'https://www.mercedes-benz.com.uy/', 'Mercedes', '1', '1', '1');
 
INSERT INTO UsuariosPersonas (Email, IdPersona, Nombre, Apellido, Nacionalidad, NombreUsuario, Contraseña, NumeroTelefono, NivelPermisos, IdEventosFavoritos, IdEncuentrosFavoritos, IdEquiposFavoritos) VALUES
('alexelleon2018@gmail.com','61','Alex','Sarasola','Uruguaya','Alex001','Nomeacuerdomucho1234*','092038170', '2', '1', '1', '1'),
('perezgomez45@gmail.com','1019','Perez','Gomez','Argentina','perezito2233','estudiomucho90<<','099456743', '2', '2', '2', '2'),
('analaurali@gmail.com','1129','Ana','Anniston','Estadounidense','Lauranole2', 'altabaja221', '099445274', '2', '3', '3', '3'),
('loloOne@gmail.com', '2332', 'Lorenzo', 'DiCaprio','Italiana', 'Elfaraon03', 'faraon03-', '092345221', '1', '3', '3', '3'),
('lolaFive@gmail.com', '2113', 'Teresa', 'Garcia','Mexicana', 'TheQueen121', 'fordescort1967>', '095567451', '1', '4', '4', '4');

SELECT IdEncuentro, NombreEncuentro
FROM Encuentros INNER JOIN DeportesCategorizados ON Encuentros.IdDeporte = DeportesCategorizados.IdDeporte
WHERE NombreDeporte = 'Futbol' AND FechaEncuentro = '2022-12-17';

SELECT NombreUsuario
FROM Usuarios
WHERE NivelPermisos = 2;

SELECT NombreUsuario
FROM Usuarios INNER JOIN EquiposFavoritos ON Usuarios.IdEquiposFavoritos = EquiposFavoritos.IdEquiposFavoritos INNER JOIN Equipos ON EquiposFavoritos.IdEquipo = Equipos.IdEquipo
WHERE NivelPermisos = 2 AND NombreEquipo = 'Aguada';

SELECT NombreUsuario
FROM Usuarios
WHERE NivelPermisos < 2;

SELECT NombreDeporte, COUNT(Eventos.IdEvento)
FROM EncuentrosFases JOIN Encuentros ON (EncuentrosFases.IdEncuentro = Encuentros.IdEncuentro) JOIN DeportesCategorizados ON (Encuentros.IdDeporte = DeportesCategorizados.IdDeporte) JOIN Eventos ON (EncuentrosFases.IdEvento = Eventos.IdEvento)
WHERE EstadoEvento = 'In progress'
GROUP BY DeportesCategorizados.IdDeporte;

SELECT Alineacion
FROM EquiposEncuentros;

SELECT Deportistas.Nombre, Deportistas.Apellido, MAX(Anotacion)
FROM EstadisticasJugador JOIN Encuentros ON EstadisticasJugador.IdEncuentro = Encuentros.IdEncuentro JOIN EquiposEncuentros ON (Encuentros.IdEncuentro = EquiposEncuentros.IdEncuentro) JOIN Equipos ON EquiposEncuentros.IdEquipo = Equipos.IdEquipo JOIN EquiposDeportistas ON Equipos.IdEquipo = EquiposDeportistas.IdEquipo JOIN Deportistas ON (EquiposDeportistas.IdPersona = Deportistas.IdPersona)
GROUP BY EquiposDeportistas.IdEquipo;

SELECT Puntuacion
FROM EquiposEncuentros
WHERE IdEquipo = 1919
ORDER BY IdEncuentro DESC limit 5;

SELECT Equipos.IdEquipo, Equipos.NombreEquipo
FROM Equipos JOIN EquiposFases ON (Equipos.IdEquipo = EquiposFases.IdEquipo) JOIN Fases ON (EquiposFases.IdEvento = Fases.IdEvento) JOIN Eventos ON (Fases.IdEvento = Eventos.IdEvento)
WHERE NombreEvento = 'Copa Libertadores de America' AND EstadoEquipo != 'Eliminado';

SELECT NombreEvento, NombreDeporte, COUNT(IdEquipo)
FROM EncuentrosFases JOIN Eventos ON (EncuentrosFases.IdEvento = Eventos.IdEvento) JOIN DeportesCategorizados ON (EncuentrosFases.IdDeporte = DeportesCategorizados.IdDeporte) JOIN EquiposEncuentros ON (EncuentrosFases.IdEncuentro = EquiposEncuentros.IdEncuentro)
WHERE TipoEquipo = 'Individual'
GROUP BY Eventos.IdEvento;
