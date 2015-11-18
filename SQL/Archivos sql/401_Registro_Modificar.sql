
DROP PROCEDURE IF EXISTS registro_modificar$$
CREATE PROCEDURE registro_modificar(
	inId_estacionamiento INT,
	inCodigo varchar(15),
	inFecha_ingreso DATETIME, 
	inFecha_salida DATETIME, 
	inMonto_total INT)
BEGIN
	update registro
	set
		fecha_ingreso = inFecha_ingreso,
		fecha_salida = inFecha_salida, 
		monto_total = inMonto_total
	where 
		id_estacionamiento = inId_estacionamiento AND
		codigo = inCodigo AND
		monto_total IS NULL;
END$$