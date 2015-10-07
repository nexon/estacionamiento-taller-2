
DROP PROCEDURE IF EXISTS registro_modificar$
CREATE PROCEDURE registro_modificar(in id_registroIn INT, in fecha_ingresoIn INT, fecha_salidaIn DATETIME, in monto_totalIn INT)
BEGIN
	update registro
	set
		fecha_ingreso = fecha_ingresoIn,
		fecha_salida = fecha_salidaIn, 
		monto_total = monto_totalIn
	where 
		id_registro = id_registroIn;

END