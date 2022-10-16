DROP DATABASE IF EXISTS SRD;
CREATE DATABASE SRD;
USE SRD;

CREATE TABLE Publicidades
(
IdPublicidad int auto_increment primary key, 
Banner blob,
Link varchar(120),
TituloPublicidad varchar(70)
);

CREATE TABLE Usuarios
(
Email varchar(70),
NombreUsuario varchar(50) unique,
Contraseña varchar(50),
NumeroTelefono varchar(15),
NivelPermisos int,
IdEventosFavoritos int,
IdEncuentrosFavoritos int,
IdEquiposFavoritos int 
);

CREATE TABLE EventosFavoritos
(
IdEventosFavoritos int primary key,
IdEvento int,
Email varchar(70)
);

CREATE TABLE EncuentrosFavoritos
(
IdEncuentrosFavoritos int primary key,
IdEncuentro int,
Email varchar(70)
);

CREATE TABLE EquiposFavoritos
(
IdEquiposFavoritos int primary key,
IdEquipo int,
Email varchar(70)
);

CREATE TABLE PublicidadesUsuarios
(
IdPublicidad int,
Email varchar(70),
NombreUsuario varchar(50),
Contraseña varchar(50),
NumeroTelefono varchar(15),
NivelPermisos int,
Banner blob,
Link varchar(120),
TituloPublicidad varchar(70),
IdEventosFavoritos int,
IdEncuentrosFavoritos int,
IdEquiposFavoritos int, 
primary key (IdPublicidad, Email)
);

CREATE TABLE Personas
(
IdPersona int primary key,
Nombre varchar(50)not null,
Apellido varchar(50) not null,
Nacionalidad varchar(50) not null
);

CREATE TABLE UsuariosPersonas
(
Email varchar(70),
IdPersona int,
Nombre varchar(50) not null,
Apellido varchar(50) not null,
Nacionalidad varchar(50) not null,
NombreUsuario varchar(50),
Contraseña varchar(50),
NumeroTelefono varchar(15),
NivelPermisos int,
IdEventosFavoritos int,
IdEncuentrosFavoritos int,
IdEquiposFavoritos int,
primary key (IdPersona, Email)
);

CREATE TABLE Arbitros
(
IdPersona int primary key,
Nombre varchar(50)not null,
Apellido varchar(50) not null,
Nacionalidad varchar(50) not null,
Rol varchar(30)
);

CREATE TABLE Deportistas
(
IdPersona int primary key,
Nombre varchar(50)not null,
Apellido varchar(50) not null,
Nacionalidad varchar(50) not null,
EstadoJugador varchar(50),
Descripcion text
);

CREATE TABLE Equipos
(
IdEquipo int primary key,
ImagenRepresentativa blob,
PaisOrigen varchar(80) not null,
NombreEquipo varchar(120) not null,
TipoEquipo varchar(15) not null
);

CREATE TABLE EquiposDeportistas
(
IdEquipo int,
IdPersona int,
ImagenRepresentativa blob,
PaisOrigen varchar(80) not null,
NombreEquipo varchar(120) not null,
EstadoJugador varchar(70) not null,
Descripcion text,
NumeroJugador int,
TipoEquipo varchar(15) not null,
primary key (IdEquipo, IdPersona)
);

CREATE TABLE EquiposFases
(
IdEquipo int,
NumeroFase int,
IdEvento int,
Uniforme blob,
ImagenRepresentativa blob,
PaisOrigen varchar(80) not null,
NombreEquipo varchar(120) not null,
EstadoFase varchar(70) not null,
NombreFase varchar(80),
Fecha date,
PosicionEquipo int,
EstadoEquipo varchar(80),
Puntaje int,
TipoEquipo varchar(15),
Tipofase tinyInt not null,
primary key (IdEquipo, NumeroFase, IdEvento)
);

CREATE TABLE EstadisticasJugador
(
IdEstadisticasJugador int,
IdEncuentro int,
Anotacion int,
Faltas varchar(80),
IdDeportista int,
primary key (IdEstadisticasJugador, IdEncuentro)
);

CREATE TABLE Fases
(
NumeroFase int,
IdEvento int,
Fecha date,
NombreFase varchar(120),
EstadoFase varchar(20),
Tipofase tinyInt not null,
primary key (NumeroFase, IdEvento)
);

CREATE TABLE EventosEncuentros
(
IdEvento int,
IdEncuentro int,
FechaEvento date not null,
NombreEvento varchar(70) not null,
HoraEvento time not null,
EstadoEvento varchar(20) not null,
LogoEvento blob,
LugarEvento varchar(50) not null,
Hora time not null,
LugarEncuentro varchar(100),
FechaEncuentro date,
Puntuacion int,
Posicion int,
NombreEncuentro varchar(50),
EstadoEncuentro varchar(50),
Clima varchar(50),
Tipoencuentro tinyInt not null,
primary key (IdEvento, IdEncuentro)
);

CREATE TABLE Eventos
(
IdEvento int,
FechaEvento date not null,
NombreEvento varchar(70) not null,
HoraEvento time not null,
EstadoEvento varchar(20) not null,
LogoEvento blob,
LugarEvento varchar(50) not null,
primary key (IdEvento)
);

CREATE TABLE Hito
(
IdHito int primary key,
NumeroRound int, 
IdEncuentro int,
TituloHito varchar(70),
TiempoHito time
);

CREATE TABLE Categorias (
IdCategoria int primary key, 
NombreCategoria varchar(50) not null
);

CREATE TABLE Deportes (
 IdDeporte int primary key, 
 NombreDeporte varchar(50) not null,
 ImagenDeporte blob,
 Destacado bool
);
 
CREATE TABLE DeportesCategorizados (
 IdDeporte int,
 IdCategoria int, 
 NombreDeporte varchar(50) not null,
 ImagenDeporte blob,
 Destacado bool, 
 NombreCategoria varchar(50) not null,
 primary key (IdDeporte, IdCategoria)
 );
 
CREATE TABLE Encuentros (
 IdEncuentro int primary key,
 IdDeporte int,
 IdCategoria int,
 IdPersona int,
 Hora time not null, 
 Lugar varchar(120),
 FechaEncuentro date not null, 
 NombreEncuentro varchar (50), 
 EstadoEncuentro varchar(25) not null, 
 Clima varchar(25),
 TipoEncuentro tinyInt not null
);

CREATE TABLE EquiposEncuentros (
 IdEquipo int, 
 IdEncuentro int,
 IdDeporte int,
 IdCategoria int,
 IdPersona int,
 Uniforme blob,
 ImagenRepresentativa blob,
 PaisOrigen varchar(80) not null,
 NombreEquipo varchar(120) not null,
 TipoEquipo varchar(15) not null,
 Hora time not null, 
 Lugar varchar(120),
 FechaEncuentro date not null,
 NombreEncuentro varchar (50),
 EstadoEncuentro varchar(25) not null,
 Clima varchar(25), 
 Puntuacion int, 
 Posicion int, 
 Alineacion blob,
 TipoEncuentro tinyInt not null,
 primary key (IdEquipo, IdEncuentro)
 );
 
CREATE TABLE Round (
NumeroRound int, 
IdEncuentro int,
TiempoTranscurridoRound time not null,
IdPuntuacionRound int, 
IdHito int,
primary key (NumeroRound, IdEncuentro)
);
 
 
CREATE TABLE PuntuacionRound (
IdPuntuacionRound int primary key,
NumeroRound int, 
IdEncuentro int,
Puntos int,
IdEquipo int not null
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
GRANT INSERT, UPDATE, DROP ON EventosEncuentros TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON Fases TO Usuario_C;
GRANT INSERT, UPDATE, DROP ON EstadisticasJugador TO Usuario_C;
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
GRANT SELECT ON EventosEncuentros TO Usuario_E;
GRANT SELECT ON Fases TO Usuario_E;
GRANT SELECT ON EstadisticasJugador TO Usuario_E;
GRANT SELECT ON EquiposFases TO Usuario_E;



ALTER TABLE Usuarios 
ADD CONSTRAINT FK_UsuariosEventosFavoritos 
FOREIGN KEY (IdEventosFavoritos) 
REFERENCES EventosFavoritos(IdEventosFavoritos);

ALTER TABLE Usuarios 
ADD CONSTRAINT FK_UsuariosEncuentrosFavoritos 
FOREIGN KEY (IdEncuentrosFavoritos) 
REFERENCES EncuentrosFavoritos(IdEncuentrosFavoritos);

ALTER TABLE Usuarios 
ADD CONSTRAINT FK_UsuariosEquiposFavoritos 
FOREIGN KEY (IdEquiposFavoritos) 
REFERENCES EquiposFavoritos(IdEquiposFavoritos);

ALTER TABLE EventosFavoritos
ADD CONSTRAINT FK_EventosFavoritosEventos
FOREIGN KEY (IdEvento) 
REFERENCES Eventos(IdEvento);

ALTER TABLE EncuentrosFavoritos
ADD CONSTRAINT FK_EncuentrosFavoritosEncuentros
FOREIGN KEY (IdEncuentro) 
REFERENCES Encuentros(IdEncuentro);

ALTER TABLE EquiposFavoritos
ADD CONSTRAINT FK_EquiposFavoritosEquipos
FOREIGN KEY (IdEquipo) 
REFERENCES Equipos(IdEquipo);

ALTER TABLE PublicidadesUsuarios
ADD CONSTRAINT FK_PublicidadesUsuariosEventosFavoritos 
FOREIGN KEY (IdEventosFavoritos) 
REFERENCES EventosFavoritos(IdEventosFavoritos);

ALTER TABLE PublicidadesUsuarios
ADD CONSTRAINT FK_PublicidadesUsuariosEncuentrosFavoritos 
FOREIGN KEY (IdEncuentrosFavoritos) 
REFERENCES EncuentrosFavoritos(IdEncuentrosFavoritos);

ALTER TABLE PublicidadesUsuarios 
ADD CONSTRAINT FK_PublicidadesUsuariosEquiposFavoritos 
FOREIGN KEY (IdEquiposFavoritos) 
REFERENCES EquiposFavoritos(IdEquiposFavoritos);

ALTER TABLE UsuariosPersonas
ADD CONSTRAINT FK_UsuariosPersonasEventosFavoritos 
FOREIGN KEY (IdEventosFavoritos) 
REFERENCES EventosFavoritos(IdEventosFavoritos);

ALTER TABLE UsuariosPersonas
ADD CONSTRAINT FK_UsuariosPersonasEncuentrosFavoritos 
FOREIGN KEY (IdEncuentrosFavoritos) 
REFERENCES EncuentrosFavoritos(IdEncuentrosFavoritos);

ALTER TABLE UsuariosPersonas 
ADD CONSTRAINT FK_UsuariosPersonasEquiposFavoritos 
FOREIGN KEY (IdEquiposFavoritos) 
REFERENCES EquiposFavoritos(IdEquiposFavoritos);

ALTER TABLE PuntuacionRound
ADD CONSTRAINT FK_PuntuacionRoundRound
FOREIGN KEY (NumeroRound, IdEncuentro)
REFERENCES Round(NumeroRound, IdEncuentro);

ALTER TABLE Hito
ADD CONSTRAINT FK_HitoRound
FOREIGN KEY (NumeroRound, IdEncuentro)
REFERENCES Round(NumeroRound, IdEncuentro);

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
('61', 'Alex', 'Sarasola', 'Uruguaya'),
('1019', 'Perez', 'Gomez', 'Argentina'),
('1129', 'Ana', 'Anniston', 'Estadounidense'),
('2332', 'Lorenzo', 'DiCaprio', 'Italiana'),
('2113', 'Teresa', 'Garcia', 'Mexicana'),
#Arbitros
('79', 'Lucas', 'Mariño', 'Uruguaya'),
('1018', 'Eusebio', 'Martinez', 'Española'),
('1125', 'Rita', 'Romero', 'Colombiana'),
('2032', 'Ignacio', 'Nuñez', 'Brasileña'),
('2300', 'Oriana', 'Pereira', 'Uruguaya'),
('80', 'Andre', 'Da Costa', 'Uruguaya'),
('34', 'Fernando', 'Buero', 'Irlandesa'),
('1031', 'Erica', 'Filardi', 'Venezolana'),
('6580', 'Rodrigo', 'Bartacovich', 'Rusa'),
('6300', 'Camila', 'Bellati', 'Francesa'),
#Futbol
('73', 'Federico', 'Valverde', 'Uruguaya'),
('1010', 'Luis', 'Suarez', 'Uruguaya'),
('1144', 'Fernando', 'Muslera', 'Uruguaya'),
('2021', 'Neymar', 'Da Silva Santos', 'Brasileña'),
('2019', 'Lucas', 'Torreira', 'Uruguaya'),
('2009', 'Mauro', 'Icardi', 'Argentina'),
('2012', 'Diego', 'Forlan', 'Uruguaya'),
('2022', 'Mario', 'Nuñez', 'Uruguaya'),
('2050', 'Armando', 'Casita', 'Argentina'),
('2052', 'Pepe', 'Muñoz', 'Estadounidense'),
#Basquetbol
('1199', 'Julio', 'Pereira', 'Brasileña'),
('2000', 'Cesar', 'Cabral', 'Europea'),
('2002', 'Nicolas', 'Piñeiro', 'Irlandesa'),
('2004', 'Maicol', 'Rodriguez', 'Uruguaya'),
('2006', 'Leticia', 'Romero', 'Boliviana'),
#Karate
('2034', 'Franco', 'Reverdito', 'Española'),
('2090', 'Esther', 'Niribao', 'Ecuatoriana'),
('2099', 'Walter', 'Tonniolo', 'Peruana'),
('2081', 'Valentin', 'Podesta', 'Mexicana'),
('2082', 'Natalia', 'Gimenez', 'Francesa'),
#Natacion
('2039', 'Alexander', 'Popov', 'Rusa'),
('2095', 'Mark', 'Spitz', 'Chilena'),
('2094', 'Jhonny', 'Weismuller', 'Puertoriqueña'),
('2076', 'Inje', 'Bruijin', 'Canada'),
('2044', 'Jenny', 'Thompson', 'Uruguaya'),
#TiroAlArco
('2033', 'Antonio', 'Fernandez', 'Española'),
('2001', 'Brady', 'Ellison', 'Africana'),
('1701', 'Kim', 'Wojin', 'Japonesa'),
('1605', 'Adriana', 'Martin', 'Española'),
('1606', 'Miguel', 'Luz', 'Uruguaya'),
#Formula1
('2055', 'Alberto', 'Ascari', 'Española'),
('1789', 'Jackie', 'Stewart', 'Australiana'),
('1778', 'Alain', 'Prost', 'Paraguaya'),
('1655', 'Jim', 'Clark', 'Francesa'),
('1490', 'Bill', 'Bukovich', 'Rusa'),
#Golf
('2777', 'Tiger', 'Woods', 'Estadounidense'),
('1333', 'Lee', 'Westwood', 'Italiana'),
('1444', 'Martin', 'Kaymer', 'Angola'),
('1212', 'Steve', 'Stricker', 'Turca'),
('1126', 'Phil', 'Mickelson', 'Irani'),
#TiroAlPlato
('2558', 'Xabier', 'Azpetia', 'India'),
('1344', 'Pilar', 'Hudson', 'Canadiense'),
('1414', 'Beto', 'Dembeto', 'Uruguaya'),
('1042', 'Tony', 'Stark', 'Estadounidense'),
('1020', 'Nick', 'Fury', 'Irlandesa'),
#TiroConPistola
('2554', 'Norberto', 'De la Sol', 'Mexicano'),
('1007', 'Nicole', 'Gonzalez', 'Canadiense'),
('1098', 'Luana', 'Britos', 'Uruguaya'),
('1013', 'Thanos', 'Talgico', 'Venezolana'),
('1979', 'Ricar', 'Dito', 'Ucraniana'),
#Bolos
('2107', 'Don', 'Carter', 'Argentino'),
('1023', 'Julia', 'Gonzalez', 'Peruana'),
('1030', 'Nila', 'Mento', 'Brasilera'),
('1040', 'Toma', 'Tito', 'Caribeña'),
('1960', 'Cristina', 'Gonzalez', 'Española'),
#Dardos
('2101', 'Don', 'Jose', 'Argentino'),
('3056', 'Marisel', 'Balvin', 'Colombiana'),
('4070', 'Jocki', 'Chon', 'China'),
('5000', 'Norma', 'Lines', 'Estadounidense'),
('5100', 'Maria', 'De la Cruz', 'Egipcia'),
#TaiChi
('3033', 'Jiffu', 'Kamada', 'Japonesa'),
('3766', 'Po', 'Lian', 'Turco'),
('4001', 'Tigresa', 'Ton', 'China'),
('4999', 'Mantis', 'Tuti', 'Irani'),
('5104', 'Mickey', 'Musca', 'Romana'),
#Judo
('3022', 'Pibu', 'Tito', 'Irlandesa'),
('3762', 'Rodrigo', 'Lemon', 'Argentino'),
('4011', 'Ivanna', 'Noquiolo', 'Brasilera'),
('4800', 'Ruben', 'Ado', 'Noruega'),
('5200', 'Mini', 'Mouse', 'Italiana'),
#Taekwondo
('3011', 'Chih Hsiung', 'Huang', 'China'),
('3300', 'Mauro', 'Sarmiento', 'Italiana'),
('4379', 'Maria', 'Espinosa', 'Mexicana'),
('4602', 'Servet', 'Tazegul', 'Noruega'),
('5250', 'Jingyu', 'Wu', 'China'),
#MuayThai
('4678', 'Buakaw ', 'Banchamek', 'China'),
('1289', 'Filipović', 'Mart', 'Japonesa'),
('6669', 'Sandoval', 'Anderson ', 'Brasilera'),
('6969', 'Carano ', 'Ernesto ', 'Poonesia'),
('5959', 'Dekkers', 'Ander ', 'India'),
#Sambo
('568', 'Shakira ', 'Gutierrez', 'Española'),
('750', 'Juan', 'Diaz', 'Mexicana'),
('7450', 'Bruno', 'Daniels', 'Argentina'),
('7120', 'Dario', 'Sosa', 'Polonesia'),
('5321', 'Andres', 'Camargo', 'Canadiense'),
#JiuJitsu
('520', 'Brian', 'Gomez', 'Noruega'),
('302', 'Romeo', 'Santos', 'Argentina'),
('7455', 'Maluma', 'Baby', 'Colombiana'),
('7175', 'Jose', 'Jervasio', 'Indu'),
('5375', 'Thomas', 'Shelby', 'Estadounidense');

INSERT INTO Arbitros (IdPersona, Nombre, Apellido, Nacionalidad, Rol) VALUES
('79', 'Lucas', 'Mariño', 'Uruguaya','Arbitro Jefe'),
('1018', 'Eusebio', 'Martinez', 'Española', 'Arbitro Jefe'),
('1125', 'Rita', 'Romero', 'Colombiana', 'Arbitro Jefe'),
('2032', 'Ignacio', 'Nuñez', 'Brasileña', 'Arbitro Jefe'),
('2300', 'Oriana', 'Pereira', 'Uruguaya', 'Arbitro Jefe'),
('80', 'Andre', 'Da Costa', 'Uruguaya', 'Arbitro Jefe'),
('34', 'Fernando', 'Buero', 'Irlandesa', 'Arbitro Jefe'),
('1031', 'Erica', 'Filardi', 'Venezolana', 'Arbitro Jefe'),
('6580', 'Rodrigo', 'Bartacovich', 'Rusa', 'Arbitro Jefe'),
('6300', 'Camila', 'Bellati', 'Francesa', 'Arbitro Jefe');
 
INSERT INTO Deportistas (IdPersona, Nombre, Apellido, Nacionalidad, EstadoJugador, Descripcion) VALUES
('73', 'Federico', 'Valverde', 'Uruguaya', 'Activo', 'Federico Santiago Valverde Dipetta, conocido deportivamente como Valverde, es un futbolista uruguayo que juega como centrocampista en el Real Madrid Club de Fútbol de la Primera División de España desde la temporada 2018-19. Es desde 2017 internacional absoluto con la selección uruguaya.'),
('1010', 'Luis', 'Suarez', 'Uruguaya', 'Activo', 'Luis Alberto Suárez Díaz es un futbolista uruguayo que juega como delantero en el Club Nacional de Football del Campeonato Uruguayo de Primera División Profesional, y en la Selección de fútbol de Uruguay'),
('1144', 'Fernando', 'Muslera', 'Uruguaya', 'Activo', 'Néstor Fernando Muslera Micol es un futbolista uruguayo nacido en Argentina. Juega de guardameta en el Galatasaray de la Superliga de Turquía.​'),
('2021', 'Neymar', 'Da Silva Santos', 'Brasileña', 'Activo','Neymar da Silva Santos Júnior, conocido como Neymar Júnior o simplemente Neymar, es un futbolista brasileño que juega como delantero en el Paris Saint-Germain F. C. de la Ligue 1 de Francia, y en la selección de fútbol de Brasil'),
('2019', 'Lucas', 'Torreira', 'Uruguaya', 'Activo', 'Lucas Sebastián Torreira di Pascua es un futbolista uruguayo que juega como centrocampista en el Galatasaray S. K. de la Superliga de Turquía.​ Es internacional absoluto con Uruguay desde 2018.');

INSERT INTO Equipos (IdEquipo, ImagenRepresentativa, PaisOrigen, NombreEquipo, TipoEquipo) VALUES
('1919', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg','Uruguay', 'Uruguay', 'Seleccion'),
('5', 'C:\Users\USUARIO\Downloads\AguadaLogo.jpg', 'Uruguay', 'Aguada', 'Club'),
('4', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Uruguay', 'Olimpia', 'Club'),
('16', 'C:\Users\USUARIO\Downloads\GeorgeLogo.jpg','Inglaterra', 'George Russell', 'Individual'),
('17', 'C:\Users\USUARIO\Downloads\LewisLogo.jpg', 'Inglaterra', 'Lewis Hamilton', 'Individual'),
('32', 'C:\Users\USUARIO\Downloads\BruceLeeLogo.jpg', 'Estados Unidos', 'Bruce Lee', 'Individual'),
('33','C:\Users\USUARIO\Downloads\JackieChanLogo.jpg',  'China', 'Jackie Chan', 'Individual'),
('287', 'C:\Users\USUARIO\Downloads\MichaelPhelpsLogo.jpg', 'Estados Unidos', 'Michael Phelps', 'Individual'),
('567', 'C:\Users\USUARIO\Downloads\IanThorpeLogo.jpg', 'Australia', 'Ian Thorpe', 'Individual'),
('1900',  'C:\Users\USUARIO\Downloads\BrasilLogo.jpg', 'Brasil', 'Brasil', 'Seleccion');

INSERT INTO EquiposDeportistas(IdEquipo, IdPersona, ImagenRepresentativa, PaisOrigen, NombreEquipo, EstadoJugador, Descripcion, NumeroJugador, TipoEquipo) VALUES
('1919', '0073', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', 'Activo','Federico Santiago Valverde Dipetta, conocido deportivamente como Valverde, es un futbolista uruguayo.', '15', 'Seleccion'),
('1919', '1010', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', 'Activo','Luis Alberto Suárez Díaz es un futbolista uruguayo que juega como delantero en el Club Nacional de Football del Campeonato Uruguayo de Primera División Profesional, y en la Selección de fútbol de Uruguay', '9', 'Seleccion'),
('1919', '1144', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', 'Activo','Néstor Fernando Muslera Micol es un futbolista uruguayo nacido en Argentina. Juega de guardameta en el Galatasaray de la Superliga de Turquía', '1', 'Seleccion'),
('1919', '2019', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', 'Activo', 'Lucas Sebastián Torreira di Pascua es un futbolista uruguayo que juega como centrocampista en el Galatasaray S. K. de la Superliga de Turquía.​ Es internacional absoluto con Uruguay desde 2018', '14', 'Seleccion'),
('1900', '2021', 'C:\Users\USUARIO\Downloads\BrasilLogo.jpg', 'Brasil', 'Brasil', 'Activo', 'Neymar da Silva Santos Júnior, conocido como Neymar Júnior o simplemente Neymar, es un futbolista brasileño que juega como delantero en el Paris Saint-Germain F. C. de la Ligue 1 de Francia, y en la selección de fútbol de Brasil', '10', 'Seleccion');

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
('2', '1', 'C:\Users\USUARIO\Downloads\PelotaBasquet.jpg', true, 'Basquetbol', 'Juegos de pelota'),
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

INSERT INTO Encuentros (IdEncuentro, IdDeporte, IdCategoria, IdPersona, Hora, Lugar, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima, Tipoencuentro) VALUES
('1', '1', '1', '79', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null, '1'),
('2', '3', '2', '1018', '19:22', 'Dojo escondido entre los arbustos', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado', '1'),
('3', '5', '4', '2032', '03:25', 'Av.18 de julio', '2022-09-1', 'La noche en que se escribio esto', 'In progress', 'Despejado', '1'),
('4', '2', '1', '79', '16:44', 'Estadio peñarol', '2021-04-30', 'Amistoso', 'Finished', 'Soleado', '1'),
('5', '4', '3', '2300', '03:33', 'Asociación cristiana de jovenes', '2022-12-12', 'Competición de natación', 'Coming soon', null, '1');

INSERT INTO EquiposEncuentros (IdEncuentro, IdDeporte, IdCategoria, IdPersona, IdEquipo, Hora, Lugar, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima, ImagenRepresentativa, PaisOrigen, NombreEquipo, Puntuacion, Posicion, Alineacion, TipoEquipo, Tipoencuentro) VALUES
('1', '1', '1', '79', '1919', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', '1', '1', 'C:\Users\USUARIO\Downloads\UruguayAlineacion.jpg', 'Seleccion', '1'),
('1', '1', '1', '79', '1900', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\BrasilLogo.jpg', 'Brasil', 'Brasil', '3', '2', 'C:\Users\USUARIO\Downloads\BrasilAlineacion.jpg', 'Seleccion', '1'),
('2', '3', '2', '1018', '32', '19:22', 'Dojo escondido entre los arbustos', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado', 'C:\Users\USUARIO\Downloads\BruceLee.jpg', 'Estados Unidos','Bruce Lee', '4', null, null, 'Individual', '1'),
('2', '3', '2', '1018', '33', '19:22', 'Dojo escondido entre los arbustos', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado', 'C:\Users\USUARIO\Downloads\JackieChan.jpg', 'China', 'Jackie Chan', null, '3', 'C:\Users\USUARIO\Downloads\ChinaAlineacion.jpg', 'Individual', '1'),
('3', '5', '4', '16', '2032', '03:25', 'Av.18 de julio', '2022-09-1', 'La noche en que se escribio esto', 'In progress', 'Despejado', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Inglaterra', 'George Russell', null, '4', 'C:\Users\USUARIO\Downloads\CarreraAlineacion.jpg', 'Individual', '1'),
('3', '5', '4', '17', '2031', '03:25', 'Av.18 de julio', '2022-09-1', 'La noche en que se escribio esto', 'In progress', 'Despejado', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Inglaterra', 'Lewis Hamilton', null, '5', 'C:\Users\USUARIO\Downloads\CarreraAlineacion.jpg', 'Individual', '1'),
('4', '2', '1', '79', '4', '16:44', 'Estadio peñarol', '2021-04-30', 'Amistoso', 'Finished', 'Soleado', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Uruguay', 'Olimpia', null, '7', 'C:\Users\USUARIO\Downloads\OlimpiaAlineacion.jpg', 'Club', '1'),
('4', '2', '1', '79', '5', '16:44', 'Estadio peñarol', '2021-04-30', 'Amistoso', 'Finished', 'Soleado', 'C:\Users\USUARIO\Downloads\AguadaLogo.jpg', 'Uruguay', 'Aguada', null, '8', 'C:\Users\USUARIO\Downloads\AguadaAlineacion.jpg', 'Club', '1'),
('5', '4', '3', '2300', '287', '03:33', 'Asociación cristiana de jovenes', '2022-12-12', 'Competición de natación', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\MichaelPhelps.jpg', 'Estados Unidos', 'Michael Phelps', null, null, 'C:\Users\USUARIO\Downloads\NatacionAlineacion.jpg','Individual', '1'),
('5', '4', '3', '2300', '567', '03:33', 'Asociación cristiana de jovenes', '2022-12-12', 'Competición de natación', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\IanThorpe.jpg', 'Australia', 'Ian Thorpe', null, null, 'C:\Users\USUARIO\Downloads\AustraliaAlineacion.jpg','Individual', '1');

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

INSERT INTO EventosEncuentros(IdEvento, IdEncuentro, FechaEvento, NombreEvento, HoraEvento, EstadoEvento, LogoEvento, LugarEvento, Hora, LugarEncuentro, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima, Tipoencuentro) VALUES
('1', '1','2024-03-21', 'Copa Libertadores de America', '21:00', 'Coming soon', 'C:\Users\USUARIO\Downloads\CopaAmericaLogo.jpg', 'Estadio de Brasilia', '13:00', 'Estadio Campeon del Siglo', '2022-06-22', 'Uruguay vs Brasil', 'En juego', 'Lluvioso', '1'),
('4', '3', '2023-09-11', 'Partidito de basquet', '13:30', 'Coming soon', 'C:\Users\USUARIO\Downloads\BasquetLogo.jpg', 'Pando', '18:00', 'Canchita de los pibes ', '2022-12-17', 'Especial de navidad', 'Coming soon', null, '1'),
('3', '4', '2021-06-13', 'Evento beneficiario', '14:20', 'Finished', 'C:\Users\USUARIO\Downloads\TeletonLogo.jpg', 'Centro de ayuda', '12:00', 'Donde cayo el avion', '2026-02-16', 'Dar caridad y amor', 'En transcurso', 'LLuvia de meteoritos', '1'),
('2', '5', '2027-05-12', 'Competencia de baile', '03:33', 'In progress', 'C:\Users\USUARIO\Downloads\AsociacionLogo.jpg', 'Asociación cristiana de jovenes', '19:00', 'Vaticano', '2022-12-12', 'Competición de natación', 'Coming soon', null, '1');

INSERT INTO Fases(NumeroFase, IdEvento, EstadoFase, NombreFase, Fecha, Tipofase) VALUES
('1', '1', 'En curso', 'Grupo A', '2022-12-2', '1'),
('1', '4', 'En curso', 'Grupo B', '2034-10-19', '1'),
('1', '2', 'Por venir', 'Grupo C', '2012-10-16', '1'),
('1', '5', 'Ya casi viene', 'Grupo D', '2029-03-16', '1'),
('1', '3', 'Casi casi', 'Grupo D', '2029-03-16', '1');

INSERT INTO EstadisticasJugador(IdEstadisticasJugador, IdEncuentro, Anotacion, Faltas, IdDeportista) VALUES
('1', '1', '3', '1', '73' ),
('2', '3', '1', '0', '1010' ),
('3', '4', '3', '4', '2019' ),
('4', '5', '3', '2', '2021' );

INSERT INTO EquiposFases(IdEquipo, NumeroFase, IdEvento, ImagenRepresentativa, PaisOrigen, NombreEquipo, EstadoFase, NombreFase, Fecha, PosicionEquipo, EstadoEquipo, Puntaje, TipoEquipo, Tipofase) VALUES 
('1919', '1', '1', 'C:\Users\USUARIO\Downloads\EquipoUruguayLogo.jpg', 'Uruguay', 'Uruguay', 'En curso', 'Grupo A', '2022-12-2', '1', 'Jugando', null, 'Seleccion', '1'),
('1900', '1', '1', 'C:\Users\USUARIO\Downloads\EquipoBrasilLogo.jpg', 'Brasil', 'Brasil', 'En curso', 'Grupo A', '2022-12-2', '1', 'Jugando', null, 'Seleccion', '1'),
('567', '1', '3', 'C:\Users\USUARIO\Downloads\IanThorpeLogo.jpg', 'Autralia', 'Ian Thorpe', 'En curso', 'Grupo B', '2022-10-2', '1', 'Jugando', null, 'Individual', '1'),
('287', '1', '3', 'C:\Users\USUARIO\Downloads\MichaelPhelpsLogo.jpg', 'Estados Unidos', 'Michael Phelps', 'En curso', 'Grupo B', '2022-10-2', '1', 'Jugando', null, 'Individual', '1');

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
('6', '2', 'admin@certus.com'),
('7', '4', 'admin@certus.com');
 
INSERT INTO EquiposFavoritos (IdEquiposFavoritos, IdEquipo, Email) VALUES
('1', '1919', 'alexelleon2018@gmail.com'),
('2', '5', 'perezgomez45@gmail.com'),
('3', '4', 'analaurali@gmail.com'),
('4', '17', 'loloOne@gmail.com'),
('5', '16', 'lolaFive@gmail.com'),
('6', '1900', 'admin@certus.com'),
('7', '16', 'sinclair@hotmail.com'),
('8', '567', 'elseñordelaesquinaquevendetortafritas@gmail.com'),
('9', '32', 'Mufasa@gmail.com'),
('10', '33', 'simba@gmail.com');
 
INSERT INTO Usuarios (Email, NombreUsuario, Contraseña, NumeroTelefono, NivelPermisos, IdEventosFavoritos, IdEncuentrosFavoritos, IdEquiposFavoritos) values
('alexelleon2018@gmail.com', 'Alex001', 'Nomeacuerdomucho1234*', '092038170', '2', '1', '1', '1'),
('perezgomez45@gmail.com', 'perezito2233', 'estudiomucho90<<', '099456743', '1', '2', '2', '2'),
('analaurali@gmail.com', 'Lauranole2', 'altabaja221', '099445274', '2', '3', '3', '3'),
('loloOne@gmail.com', 'Elfaraon03', 'faraon03-', '092345221', '1', '4', '4', '4'),
('lolaFive@gmail.com', 'TheQueen121', 'fordescort1967>', '095567451', '1', '5', '5', '5'),
('admin@certus.com', 'Administrador', '122333', null, '4', '6', '1', '6'),
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
('Bastion@gmail.com', 'Vanguard', 'torreA4', 099999999, '1', '1', '1', '1'),
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

SELECT NombreDeporte, COUNT(IdEvento)
FROM EventosEncuentros JOIN Encuentros ON (EventosEncuentros.IdEncuentro = Encuentros.IdEncuentro) JOIN DeportesCategorizados ON (Encuentros.IdDeporte = DeportesCategorizados.IdDeporte)
WHERE EstadoEvento = 'In progress'
GROUP BY DeportesCategorizados.IdDeporte;

SELECT Alineacion
FROM EquiposEncuentros;

SELECT Nombre, Apellido, MAX(Anotacion)
FROM EstadisticasJugador JOIN Encuentros ON EstadisticasJugador.IdEncuentro = Encuentros.IdEncuentro JOIN EquiposEncuentros ON (Encuentros.IdEncuentro = EquiposEncuentros.IdEncuentro) JOIN Equipos ON EquiposEncuentros.IdEquipo = Equipos.IdEquipo JOIN EquiposDeportistas ON Equipos.IdEquipo = EquiposDeportistas.IdEquipo JOIN Deportistas ON (EquiposDeportistas.IdPersona = Deportistas.IdPersona)
GROUP BY EquiposDeportistas.IdEquipo;

SELECT Puntuacion
FROM EquiposEncuentros
WHERE IdEquipo = 1919
ORDER BY IdEncuentro DESC limit 5;

SELECT Equipos.IdEquipo, Equipos.NombreEquipo
FROM Equipos INNER JOIN EquiposFases ON Equipos.IdEquipo = EquiposFases.IdEquipo INNER JOIN Fases ON EquiposFases.IdEvento = Fases.IdEvento INNER JOIN Eventos ON Fases.IdEvento = Eventos.IdEvento
WHERE NombreEvento = 'Copa Libertadores de America' AND EstadoEquipo != 'Eliminado';

SELECT NombreEvento, NombreDeporte, COUNT(IdEquipo)
FROM EventosEncuentros JOIN Encuentros ON (EventosEncuentros.IdEncuentro = Encuentros.IdEncuentro) JOIN DeportesCategorizados ON (Encuentros.IdDeporte = DeportesCategorizados.IdDeporte) JOIN EquiposEncuentros ON (Encuentros.IdEncuentro = EquiposEncuentros.IdEncuentro)
WHERE TipoEquipo = 'Individual'
GROUP BY IdEvento;
