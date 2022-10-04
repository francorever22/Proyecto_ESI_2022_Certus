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
NumeroTelefono varchar(9),
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
NumeroTelefono varchar(9),
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
NumeroTelefono varchar(9),
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
Uniforme blob,
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
 Clima varchar(25)
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



DROP USER Usuario_A;
DROP USER Usuario_B;
DROP USER Usuario_C;
DROP USER Usuario_D;
DROP USER Usuario_E;

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



INSERT INTO Publicidades (Banner, Link, TituloPublicidad) VALUES
('C:\Users\USUARIO\Downloads', 'https://www.Apple.es/fotos-publicidad/imagenes', 'Apple'),
('C:\Users\USUARIO\Pictures\Camera Roll', 'https://www.Samsung.es/fotos-publicidad/imagenes', 'Samsung'),
('C:\Users\USUARIO\Documents', 'https://www.Sony.es/fotos-publicidad/imagenes', 'Sony'),
('C:\Program Files', 'https://www.Despegar.com.es/fotos-publicidad/imagenes', 'Despegar.com'),
('C:\Users\USUARIO\Videos', 'https://www.Sprite.es/fotos-publicidad/imagenes', 'Sprite');

INSERT INTO Personas (IdPersona, Nombre, Apellido, Nacionalidad) VALUES
('61', 'Alex', 'Sarasola', 'Uruguaya'),
('1019', 'Perez', 'Gomez', 'Argentina'),
('1129', 'Ana', 'Anniston', 'Estadounidense'),
('2332', 'Lorenzo', 'DiCaprio', 'Italiana'),
('2113', 'Teresa', 'Garcia', 'Mexicana'),
('79', 'Lucas', 'Mariño', 'Uruguaya'),
('1018', 'Eusebio', 'Martinez', 'Española'),
('1125', 'Rita', 'Romero', 'Colombiana'),
('2032', 'Ignacio', 'Nuñez', 'Brasileña'),
('2300', 'Oriana', 'Pereira', 'Uruguaya'),
('73', 'Federico', 'Valverde', 'Uruguaya'),
('1010', 'Luis', 'Suarez', 'Uruguaya'),
('1144', 'Fernando', 'Muslera', 'Uruguaya'),
('2021', 'Neymar', 'Da Silva Santos', 'Brasileña'),
('2019', 'Lucas', 'Torreira', 'Uruguaya');
 
INSERT INTO Arbitros (IdPersona, Nombre, Apellido, Nacionalidad, Rol) VALUES
('79', 'Lucas', 'Mariño', 'Uruguaya','Arbitro Jefe'),
('1018', 'Eusebio', 'Martinez', 'Española', 'Arbitro Jefe'),
('1125', 'Rita', 'Romero', 'Colombiana', 'Arbitro Jefe'),
('2032', 'Ignacio', 'Nuñez', 'Brasileña', 'Arbitro Jefe'),
('2300', 'Oriana', 'Pereira', 'Uruguaya', 'Arbitro Jefe');
 
INSERT INTO Deportistas (IdPersona, Nombre, Apellido, Nacionalidad, EstadoJugador, Descripcion) VALUES
('73', 'Federico', 'Valverde', 'Uruguaya', 'Activo', 'Federico Santiago Valverde Dipetta, conocido deportivamente como Valverde, es un futbolista uruguayo que juega como centrocampista en el Real Madrid Club de Fútbol de la Primera División de España desde la temporada 2018-19. Es desde 2017 internacional absoluto con la selección uruguaya.'),
('1010', 'Luis', 'Suarez', 'Uruguaya', 'Activo', 'Luis Alberto Suárez Díaz es un futbolista uruguayo que juega como delantero en el Club Nacional de Football del Campeonato Uruguayo de Primera División Profesional, y en la Selección de fútbol de Uruguay'),
('1144', 'Fernando', 'Muslera', 'Uruguaya', 'Activo', 'Néstor Fernando Muslera Micol es un futbolista uruguayo nacido en Argentina. Juega de guardameta en el Galatasaray de la Superliga de Turquía.​'),
('2021', 'Neymar', 'Da Silva Santos', 'Brasileña', 'Activo','Neymar da Silva Santos Júnior, conocido como Neymar Júnior o simplemente Neymar, es un futbolista brasileño que juega como delantero en el Paris Saint-Germain F. C. de la Ligue 1 de Francia, y en la selección de fútbol de Brasil'),
('2019', 'Lucas', 'Torreira', 'Uruguaya', 'Activo', 'Lucas Sebastián Torreira di Pascua es un futbolista uruguayo que juega como centrocampista en el Galatasaray S. K. de la Superliga de Turquía.​ Es internacional absoluto con Uruguay desde 2018.');

INSERT INTO Equipos (IdEquipo, Uniforme, ImagenRepresentativa, PaisOrigen, NombreEquipo, TipoEquipo) VALUES
('1919', 'C:\Users\USUARIO\Downloads\UruguayUniforme.jpg', 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg','Uruguay', 'Uruguay', 'Seleccion'),
('5', 'C:\Users\USUARIO\Downloads\AguadaUniforme.jpg', 'C:\Users\USUARIO\Downloads\AguadaLogo.jpg', 'Uruguay', 'Aguada', 'Club'),
('4', 'C:\Users\USUARIO\Downloads\OlimpiaUniforme.jpg', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Uruguay', 'Olimpia', 'Club'),
('16', 'C:\Users\USUARIO\Downloads\GeorgeUniforme.jpg', 'C:\Users\USUARIO\Downloads\GeorgeLogo.jpg','Inglaterra', 'George Russell', 'Individual'),
('17', 'C:\Users\USUARIO\Downloads\LewisUniforme.jpg', 'C:\Users\USUARIO\Downloads\LewisLogo.jpg', 'Inglaterra', 'Lewis Hamilton', 'Individual'),
('32', 'C:\Users\USUARIO\Downloads\BruceLeeUniforme.jpg', 'C:\Users\USUARIO\Downloads\BruceLeeLogo.jpg', 'Estados Unidos', 'Bruce Lee', 'Individual'),
('33', 'C:\Users\USUARIO\Downloads\JackieChanUniforme.jpg','C:\Users\USUARIO\Downloads\JackieChanLogo.jpg',  'China', 'Jackie Chan', 'Individual'),
('287', 'C:\Users\USUARIO\Downloads\MichaelPhelpsUniforme.jpg', 'C:\Users\USUARIO\Downloads\MichaelPhelpsLogo.jpg', 'Estados Unidos', 'Michael Phelps', 'Individual'),
('567', 'C:\Users\USUARIO\Downloads\IanThorpeUniforme.jpg', 'C:\Users\USUARIO\Downloads\IanThorpeLogo.jpg', 'Australia', 'Ian Thorpe', 'Individual'),
('1900', 'C:\Users\USUARIO\Downloads\BrasilUniforme.jpg',  'C:\Users\USUARIO\Downloads\BrasilLogo.jpg', 'Brasil', 'Brasil', 'Seleccion');

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
('5', 'Aéros');

INSERT INTO Deportes (IdDeporte, ImagenDeporte, Destacado, NombreDeporte) VALUES
('1', 'C:\Users\USUARIO\Downloads\PelotaFutbol.jpg', true, 'Futbol'),
('2', 'C:\Users\USUARIO\Downloads\PelotaBasquet.jpg', true, 'Basquetbol'),
('3', 'C:\Users\USUARIO\Downloads\PersonaM.jpg', false, 'Karate'),
('4', 'C:\Users\USUARIO\Downloads\PersonaN.jpg', true, 'Natación'),
('5', 'C:\Users\USUARIO\Downloads\Auto.jpg', true, 'Fórmula 1');

INSERT INTO DeportesCategorizados (IdDeporte, IdCategoria, ImagenDeporte, Destacado, NombreDeporte, NombreCategoria) VALUES
('1', '1', 'C:\Users\USUARIO\Downloads\PelotaFutbol.jpg', true, 'Futbol', 'Juegos de pelota'),
('2', '1', 'C:\Users\USUARIO\Downloads\PelotaBasquet.jpg', true, 'Basquetbol', 'Juegos de pelota'),
('3', '2', 'C:\Users\USUARIO\Downloads\PersonaM.jpg', false, 'Karate', 'Artes marciales'),
('4', '3', 'C:\Users\USUARIO\Downloads\PersonaN.jpg', true, 'Natación', 'Acuáticos'),
('5', '4', 'C:\Users\USUARIO\Downloads\Auto.jpg', true, 'Fórmula 1', 'Motorizados');

INSERT INTO Encuentros (IdEncuentro, IdDeporte, IdCategoria, IdPersona, Hora, Lugar, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima) VALUES
('1', '1', '1', '79', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null),
('2', '3', '2', '1018', '19:22', 'Dojo escondido entre los arbustos', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado'),
('3', '5', '4', '2032', '03:25', 'Av.18 de julio', '2022-09-1', 'La noche en que se escribio esto', 'In progress', 'Despejado'),
('4', '2', '1', '79', '16:44', 'Estadio peñarol', '2021-04-30', 'Amistoso', 'Finished', 'Soleado'),
('5', '4', '3', '2300', '03:33', 'Asociación cristiana de jovenes', '2022-12-12', 'Competición de natación', 'Coming soon', null);

INSERT INTO EquiposEncuentros (IdEncuentro, IdDeporte, IdCategoria, IdPersona, IdEquipo, Hora, Lugar, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima, ImagenRepresentativa, PaisOrigen, NombreEquipo, Puntuacion, Posicion, Alineacion, TipoEquipo) VALUES
('1', '1', '1', '79', '1919', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\UruguayLogo.jpg', 'Uruguay', 'Uruguay', null, '1', 'C:\Users\USUARIO\Downloads\UruguayAlineacion.jpg', 'Seleccion'),
('1', '1', '1', '79', '1900', '13:30', 'Estadio centenario', '2022-12-17', 'Especial de navidad', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\BrasilLogo.jpg', 'Brasil', 'Brasil', '3', '2', 'C:\Users\USUARIO\Downloads\BrasilAlineacion.jpg', 'Seleccion'),
('2', '3', '2', '1018', '32', '19:22', 'Dojo escondido entre los arbustos', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado', 'C:\Users\USUARIO\Downloads\BruceLee.jpg', 'Estados Unidos','Bruce Lee', '4', null, null, 'Individual'),
('2', '3', '2', '1018', '33', '19:22', 'Dojo escondido entre los arbustos', '1978-06-5', 'Amistoso, pero no mucho', 'Finished', 'Nublado', 'C:\Users\USUARIO\Downloads\JackieChan.jpg', 'China', 'Jackie Chan', null, '3', 'C:\Users\USUARIO\Downloads\ChinaAlineacion.jpg', 'Individual'),
('3', '5', '4', '16', '2032', '03:25', 'Av.18 de julio', '2022-09-1', 'La noche en que se escribio esto', 'In progress', 'Despejado', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Inglaterra', 'George Russell', null, '4', 'C:\Users\USUARIO\Downloads\CarreraAlineacion.jpg', 'Individual'),
('3', '5', '4', '17', '2031', '03:25', 'Av.18 de julio', '2022-09-1', 'La noche en que se escribio esto', 'In progress', 'Despejado', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Inglaterra', 'Lewis Hamilton', null, '5', 'C:\Users\USUARIO\Downloads\CarreraAlineacion.jpg', 'Individual'),
('4', '2', '1', '79', '4', '16:44', 'Estadio peñarol', '2021-04-30', 'Amistoso', 'Finished', 'Soleado', 'C:\Users\USUARIO\Downloads\OlimpiaLogo.jpg', 'Uruguay', 'Olimpia', null, '7', 'C:\Users\USUARIO\Downloads\OlimpiaAlineacion.jpg', 'Club'),
('4', '2', '1', '79', '5', '16:44', 'Estadio peñarol', '2021-04-30', 'Amistoso', 'Finished', 'Soleado', 'C:\Users\USUARIO\Downloads\AguadaLogo.jpg', 'Uruguay', 'Aguada', null, '8', 'C:\Users\USUARIO\Downloads\AguadaAlineacion.jpg', 'Club'),
('5', '4', '3', '2300', '287', '03:33', 'Asociación cristiana de jovenes', '2022-12-12', 'Competición de natación', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\MichaelPhelps.jpg', 'Estados Unidos', 'Michael Phelps', null, null, 'C:\Users\USUARIO\Downloads\NatacionAlineacion.jpg','Individual'),
('5', '4', '3', '2300', '567', '03:33', 'Asociación cristiana de jovenes', '2022-12-12', 'Competición de natación', 'Coming soon', null, 'C:\Users\USUARIO\Downloads\IanThorpe.jpg', 'Australia', 'Ian Thorpe', null, null, 'C:\Users\USUARIO\Downloads\AustraliaAlineacion.jpg','Individual');

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

INSERT INTO EventosEncuentros(IdEvento, IdEncuentro, FechaEvento, NombreEvento, HoraEvento, EstadoEvento, LogoEvento, LugarEvento, Hora, LugarEncuentro, FechaEncuentro, NombreEncuentro, EstadoEncuentro, Clima) VALUES
('1', '1','2024-03-21', 'Copa Libertadores de America', '21:00', 'Coming soon', 'C:\Users\USUARIO\Downloads\CopaAmericaLogo.jpg', 'Estadio de Brasilia', '13:00', 'Estadio Campeon del Siglo', '2022-06-22', 'Uruguay vs Brasil', 'En juego', 'Lluvioso'),
('4', '3', '2023-09-11', 'Partidito de basquet', '13:30', 'Estadio centenario', 'C:\Users\USUARIO\Downloads\BasquetLogo.jpg', 'Pando', '18:00', 'Canchita de los pibes ', '2022-12-17', 'Especial de navidad', 'Coming soon', null),
('3', '4', '2021-06-13', 'Evento beneficiario', '14:20', 'Finished', 'C:\Users\USUARIO\Downloads\TeletonLogo.jpg', 'Centro de ayuda', '12:00', 'Donde cayo el avion', '2026-02-16', 'Dar caridad y amor', 'En transcurso', 'LLuvia de meteoritos'),
('2', '5', '2027-05-12', 'Competencia de baile', '03:33', 'In process', 'C:\Users\USUARIO\Downloads\AsociacionLogo.jpg', 'Asociación cristiana de jovenes', '19:00', 'Vaticano', '2022-12-12', 'Competición de natación', 'Coming soon', null);

INSERT INTO Fases(NumeroFase, IdEvento, EstadoFase, NombreFase, Fecha) VALUES
('1', '1', 'En curso', 'Grupo A', '2022-12-2'),
('2', '4', 'En curso', 'Grupo B', '2034-10-19'),
('3', '2', 'Por venir', 'Grupo C', '2012-10-16'),
('4', '5', 'Ya casi viene', 'Grupo D', '2029-03-16'),
('5', '3', 'Casi casi', 'Grupo D', '2029-03-16');

INSERT INTO EstadisticasJugador(IdEstadisticasJugador, IdEncuentro, Anotacion, Faltas, IdDeportista) VALUES
('1', '1', '3', '1', '73' ),
('2', '3', '1', '0', '1010' ),
('3', '4', '3', '4', '2019' ),
('4', '5', '3', '2', '2021' );

INSERT INTO EquiposFases(IdEquipo, NumeroFase, IdEvento, ImagenRepresentativa, PaisOrigen, NombreEquipo, EstadoFase, NombreFase, Fecha, PosicionEquipo, EstadoEquipo, Puntaje, TipoEquipo) VALUES 
('1919', '1', '1', 'C:\Users\USUARIO\Downloads\EquipoUruguayLogo.jpg', 'Uruguay', 'Uruguay', 'En curso', 'Grupo A', '2022-12-2', '1', 'Jugando', null, 'Seleccion'),
('1900', '1', '1', 'C:\Users\USUARIO\Downloads\EquipoBrasilLogo.jpg', 'Brasil', 'Brasil', 'En curso', 'Grupo A', '2022-12-2', '1', 'Jugando', null, 'Seleccion'),
('567', '2', '3', 'C:\Users\USUARIO\Downloads\IanThorpeLogo.jpg', 'Autralia', 'Ian Thorpe', 'En curso', 'Grupo B', '2022-10-2', '1', 'Jugando', null, 'Individual'),
('287', '2', '3', 'C:\Users\USUARIO\Downloads\MichaelPhelpsLogo.jpg', 'Estados Unidos', 'Michael Phelps', 'En curso', 'Grupo B', '2022-10-2', '1', 'Jugando', null, 'Individual');

INSERT INTO EventosFavoritos (IdEventosFavoritos, IdEvento, Email) VALUES
('15', '1', 'alexelleon2018@gmail.com'),
('34', '4', 'perezgomez45@gmail.com'),
('111', '3', 'analaurali@gmail.com'),
('1234', '2', 'loloOne@gmail.com'),
('1235', '2', 'lolaFive@gmail.com'),
('1', '5', 'admin@certus.com');
 
INSERT INTO EncuentrosFavoritos (IdEncuentrosFavoritos, IdEncuentro, Email) VALUES
('8', '1', 'alexelleon2018@gmail.com'),
('9', '3', 'perezgomez45@gmail.com'),
('234', '4', 'analaurali@gmail.com'),
('777', '5', 'loloOne@gmail.com'),
('789', '3', 'lolaFive@gmail.com'),
('1', '2', 'admin@certus.com');
 
INSERT INTO EquiposFavoritos (IdEquiposFavoritos, IdEquipo, Email) VALUES
('67', '1919', 'alexelleon2018@gmail.com'),
('22', '5', 'perezgomez45@gmail.com'),
('68', '4', 'analaurali@gmail.com'),
('80', '17', 'loloOne@gmail.com'),
('235', '16', 'lolaFive@gmail.com'),
('1', '1900', 'admin@certus.com');
 
INSERT INTO Usuarios (Email, NombreUsuario, Contraseña, NumeroTelefono, NivelPermisos, IdEventosFavoritos, IdEncuentrosFavoritos, IdEquiposFavoritos) values
('alexelleon2018@gmail.com', 'Alex001', 'Nomeacuerdomucho1234*', '092038170', '2', '15', '8', '67'),
('perezgomez45@gmail.com', 'perezito2233', 'estudiomucho90<<', '099456743', '1', '34', '9', '22'),
('analaurali@gmail.com', 'Lauranole2', 'altabaja221', '099445274', '2', '111', '234', '68'),
('loloOne@gmail.com', 'Elfaraon03', 'faraon03-', '092345221', '1', '1234', '777', '80'),
('lolaFive@gmail.com', 'TheQueen121', 'fordescort1967>', '095567451', '1', '1235', '789', '235'),
('admin@certus.com', 'Administrador', '122333', null, '4', '1', '1', '1'),
('sinclair@hotmail.com', 'Simond', 'Badminton', 097862376, '2', '5', '12', '103'),
('subdito1@gmail.com', 'Subdito1', 'sub1', null, '3', '1', '1', '1'),
('señorarandom@gmail.com', 'Señora Random', 'haygentequerealmenteseponeestetipodenombres', 099999999, '1', '11', '107', '34'),
('elseñordelaesquinaquevendetortafritas@gmail.com', 'El tortafritero', 'Lasmejorestortafritasdelazonasevendenenlaesquinadelautu', 091919191, '2', '7', '17', '37'),
('Tramontina@gmail.com', 'Tramontina', '826592659', 091657365, '1', '43', '24', '3'),
('simba@gmail.com', 'Simba', 'amipapaloatropellounñu', 095565676, '1', '46', '42', '14'),
('guillermoperez@gmail.com', 'El guille', 'alpaca', 093242381, '2', '26', '45', '16'),
('volar@gmail.com', 'Volar', 'violin', 091234623, '1', '34', '41', '13'),
('Cacatua@gmail.com', 'Cacatua', 'sacala1234', 091233453, '2', '12', '14', '11'),
('Cilnantro@gmail.com', 'Pepino', '3nsalad4', 097843777, '1', '74', '81', '4'),
('Sombra@gmail.com', 'Darker', 'Oscuridad', 092766246, '1', '76', '46', '12'),
('Mufasa@gmail.com', 'Mufasa', 'todoculpademihijo', 098324324, '1', '23', '45', '12'),
('Scar@gmail.com', 'Scar', 'ahorasoyadminXD', 094828434, '2', '42', '12', '45'),
('Lahyena@gmail.com', 'Hyena', 'MufasaUHHH', 091234123, '1', '15', '63', '15'),
('Nala@gmail.com', 'Nala', 'simbatutiomecaemal', 092344623, '1', '53', '46', '14'),
('Timon@gmail.com', 'Timon', 'insectosdebajodeltronco', 092363423, '1', '53', '46', '14'),
('Pumba@gmail.com', 'Pumba', 'troncoencimadelosinsectos', 093563423, '1', '43', '12', '53'),
('Rafiki@gmail.com', 'Rafiki', 'lasfrutasdelotrodiaestabanfuertessimba', null, '1', '54', '26', '73');

INSERT INTO PublicidadesUsuarios (IdPublicidad, Email, NombreUsuario, Contraseña, NumeroTelefono, NivelPermisos, Banner, Link, TituloPublicidad, IdEventosFavoritos, IdEncuentrosFavoritos, IdEquiposFavoritos) VALUES
('994', 'alexelleon2018@gmail.com', 'Alex001', 'Nomeacuerdomucho1234*', '092038170', '2', 'C:\Users\USUARIO\Downloads', 'https://www.Apple.es/fotos-publicidad/imagenes', 'Apple', '15', '8', '67'),
('2339', 'perezgomez45@gmail.com', 'perezito2233', 'estudiomucho90<<', '099456743', '1', 'C:\Users\USUARIO\Pictures\Camera Roll', 'https://www.Samsung.es/fotos-publicidad/imagenes', 'Samsung', '34', '9', '22'),
('1177', 'analaurali@gmail.com', 'Lauranole2', 'altabaja221', '099445274', '2', 'C:\Users\USUARIO\Documents', 'https://www.Sony.es/fotos-publicidad/imagenes', 'Sony',  '111', '234', '68'),
('4444', 'loloOne@gmail.com', 'Elfaraon03', 'faraon03-', '092345221', '1', 'C:\Program Files', 'https://www.Despegar.com.es/fotos-publicidad/imagenes', 'Despegar.com', '1234', '777', '80'),
('3499','lolaFive@gmail.com', 'TheQueen121', 'fordescort1967>', '095567451', '1', 'C:\Users\USUARIO\Videos', 'https://www.Sprite.es/fotos-publicidad/imagenes', 'Sprite', '1235', '789', '235');
 
INSERT INTO UsuariosPersonas (Email, IdPersona, Nombre, Apellido, Nacionalidad, NombreUsuario, Contraseña, NumeroTelefono, NivelPermisos, IdEventosFavoritos, IdEncuentrosFavoritos, IdEquiposFavoritos) VALUES
('alexelleon2018@gmail.com','61','Alex','Sarasola','Uruguaya','Alex001','Nomeacuerdomucho1234*','092038170', '2', '15', '8', '67'),
('perezgomez45@gmail.com','1019','Perez','Gomez','Argentina','perezito2233','estudiomucho90<<','099456743', '1', '34', '9', '22'),
('analaurali@gmail.com','1129','Ana','Anniston','Estadounidense','Lauranole2', 'altabaja221', '099445274', '2', '111', '234', '68'),
('loloOne@gmail.com', '2332', 'Lorenzo', 'DiCaprio','Italiana', 'Elfaraon03', 'faraon03-', '092345221', '1', '1234', '777', '80'),
('lolaFive@gmail.com', '2113', 'Teresa', 'Garcia','Mexicana', 'TheQueen121', 'fordescort1967>', '095567451', '1', '1235', '789', '235');
