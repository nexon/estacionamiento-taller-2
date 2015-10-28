
DROP PROCEDURE IF EXISTS registro_modificar$
CREATE PROCEDURE registro_modificar(in inId_registro INT, in inFecha_ingreso DATETIME, inFecha_salida DATETIME, in inMonto_total INT)
BEGIN
	update registro
	set
		fecha_ingreso = inFecha_ingreso,
		fecha_salida = inFecha_salida, 
		monto_total = inMonto_total
	where 
		id_registro = inId_registro;

END