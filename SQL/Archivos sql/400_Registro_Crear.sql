
DROP PROCEDURE IF EXISTS registro_crear$$
CREATE PROCEDURE registro_crear(in inFecha_reserva DATETIME, in inFecha_ingreso DATETIME, in inId_estacionamiento INT, in inId_vehiculo INT, in inId_espacio INT )
BEGIN
	insert into 
		registro(fecha_reserva, fecha_ingreso, id_estacionamiento, id_vehiculo, id_espacio)
	values
		(inFecha_reserva, inFecha_ingreso, inId_estacionamiento, inId_vehiculo, inId_espacio);

END$$
