
DROP PROCEDURE IF EXISTS `registro_actualizar`$
CREATE PROCEDURE `registro_actualizar`(in id_registroIn INT, in fecha_salidaIn DATETIME, in monto_totalIn INT)
BEGIN
	update registro
	set
		fecha_salida = fecha_salidaIn, 
		monto_total = monto_totalIn
	where id_registro = id_registroIn;

END