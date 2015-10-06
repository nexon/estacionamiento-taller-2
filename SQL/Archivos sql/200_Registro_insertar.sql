
DROP PROCEDURE IF EXISTS registro_insertar$
CREATE PROCEDURE registro_insertar(in fecha_ingresoIn DATETIME, in id_estacionamientoIn INT, in id_vehiculoIn INT )
BEGIN
	insert into registro(fecha_ingreso, id_estacionamiento, id_vehiculo) values (fecha_ingresoIn, id_estacionamientoIn, id_vehiculoIn);

END
