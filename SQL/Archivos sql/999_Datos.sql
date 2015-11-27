/* Se crean los estacionamientos con datos de prueba y se guarda el ID en el cual se insertaron */
INSERT INTO Estacionamiento (nombre, direccion, email, telefono, tiempo_minimo, tarifa_minuto, apertura, cierre, coordenadaLatitud, coordenadaLongitud)
			VALUES("Estacionamiento 1",  "Calle de test #1" ,"estacionamiento1@email.cl", 12345678, 15, 300, "2015-00-00 10:00:00", "2015-00-00 19:00:00", -34.976727, -71.234773)$
set @ID1 = last_insert_id()$
INSERT INTO Estacionamiento (nombre, direccion, email, telefono, tiempo_minimo, tarifa_minuto, apertura, cierre, coordenadaLatitud, coordenadaLongitud)
			VALUES("Estacionamiento 2",  "Calle de test #2" ,"estacionamiento2@email.cl", 23456789, 10, 350, "2015-00-00 11:00:00", "2015-00-00 21:00:00", -34.977948, -71.241025)$
set @ID2 = last_insert_id()$
INSERT INTO Estacionamiento (nombre, direccion, email, telefono, tiempo_minimo, tarifa_minuto, apertura, cierre, coordenadaLatitud, coordenadaLongitud)
			VALUES("Estacionamiento 3",  "Calle de test #3" ,"estacionamiento3@email.cl", 34567890, 20, 200, "2015-00-00 10:30:00", "2015-00-00 20:30:00", -34.989780, -71.244480)$
set @ID3 = last_insert_id()$
/* rut de los usuarios a ingresar */
set @rut1 = 14844371$
set @rut2 = 10169292$
/* Se ingresan los nuevos usuarios con contraseña = 123456 */
INSERT INTO Usuario (rut, nombre, contrasenia, email, telefono) 
			VALUES(@rut1, "Usuario 1", "ec278a38901287b2771a13739520384d43e4b078f78affe702def108774cce24", "usuario1@taller.cl", 96543211 )$
INSERT INTO Usuario (rut, nombre, contrasenia, email, telefono) 
			VALUES(@rut2, "Usuario 2", "ec278a38901287b2771a13739520384d43e4b078f78affe702def108774cce24", "usuario2@taller.cl", 86543546 )$
/* Se crea el Personal para los usuarios anteriores y se guarda el id en el que se insertaron */
INSERT INTO Personal (id_usuario) VALUES(@rut1)$
set @id_personal1 = last_insert_id()$
INSERT INTO Personal (id_usuario) VALUES(@rut2)$
set @id_personal2 = last_insert_id()$
/* Se asocia a los usuarios de tipo personal con sus respectivos estacionamientos (rol 1 = Propietario) */
INSERT INTO Personal_Estacionamiento (id_personal, id_estacionamiento, id_rol) VALUES(@id_personal1, @ID1, 1)$
INSERT INTO Personal_Estacionamiento (id_personal, id_estacionamiento, id_rol) VALUES(@id_personal1, @ID2, 1)$
INSERT INTO Personal_Estacionamiento (id_personal, id_estacionamiento, id_rol) VALUES(@id_personal2, @ID3, 1)$

/* Se agrega el usuario y conductor desconocido */
INSERT INTO Usuario(rut, nombre, contrasenia, email, telefono) VALUES (-1, "desconocido", "desconocido", "desconocido@desconocido.cl", 00000000)$
INSERT INTO Conductor(id_usuario) VALUES (-1)$