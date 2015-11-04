
DROP PROCEDURE IF EXISTS registro_eliminar$$
CREATE PROCEDURE registro_eliminar(in inId_registro INT)
BEGIN
	delete from
		registro
	where 
		id_registro = inId_registro;

END$$