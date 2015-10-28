DROP PROCEDURE IF EXISTS registro_seleccionar$
CREATE PROCEDURE registro_seleccionar(in inId_registro INT)
BEGIN
	select
		r.id_registro as registro_id_registro,
		r.fecha_reserva as registro_fecha_reserva,
		r.fecha_ingreso as registro_fecha_ingreso,
		r.fecha_salida as registro_fecha_salida,
		r.monto_total as registro_monto_total,
		r.id_estacionamiento as registro_id_estacionamiento,
		r.id_vehiculo as registro_id_vehiculo,
		r.id_espacio as registro_id_espacio
	from
		registro as r
	where
		r.id_registro = inId_registro
	limit
		1;
	
END

