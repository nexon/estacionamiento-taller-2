
DROP PROCEDURE IF EXISTS registro_crear$
CREATE PROCEDURE registro_crear(in fecha_reservaIn DATETIME, in fecha_ingresoIn DATETIME, in id_estacionamientoIn INT, in id_vehiculoIn INT, in id_espacioIn INT )
BEGIN
	insert into 
		registro(fecha_reserva, fecha_ingreso, id_estacionamiento, id_vehiculo, id_espacio)
	values
		(fecha_reservaIn, fecha_ingresoIn, id_estacionamientoIn, id_vehiculoIn, id_espacioIn);

END
