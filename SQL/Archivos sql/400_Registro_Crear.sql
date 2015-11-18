
DROP PROCEDURE IF EXISTS registro_crear$$
CREATE PROCEDURE registro_crear(inFecha_reserva DATETIME, inFecha_ingreso DATETIME, inId_estacionamiento INT, inId_vehiculo varchar(15), inCodigo varchar(15))
BEGIN
	insert into 
		registro(fecha_reserva, fecha_ingreso, id_estacionamiento, id_vehiculo, codigo)
	values
		(inFecha_reserva, inFecha_ingreso, inId_estacionamiento, inId_vehiculo, inCodigo);

END$$
