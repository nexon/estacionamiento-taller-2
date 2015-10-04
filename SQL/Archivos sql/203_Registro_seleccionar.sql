DROP PROCEDURE IF EXISTS `registro_seleccionar`$
CREATE PROCEDURE `registro_seleccionar`(in idIn INT)
BEGIN
	select
		r.id_registro as registro_id_registro,
		r.fecha_ingreso as registro_fecha_ingreso,
		r.fecha_salida as registro_fecha_salida,
		r.monto_total as registro_monto_total,
		r.id_estacionamiento as registro_id_estacionamiento,
		r.id_vehiculo as registro_id_vehiculo
	from
		registro as r
	where
		r.id = idIn
	limit
		1;
	
END

