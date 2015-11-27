
DROP PROCEDURE IF EXISTS registro_eliminar$$
CREATE PROCEDURE registro_eliminar(
	inId_estacionamiento INT,
	inCodigo varchar(15))
BEGIN
	delete from
		registro
	where 
		id_estacionamiento = inId_estacionamiento AND
		codigo = inCodigo AND
		fecha_salida IS NULL;

END$$