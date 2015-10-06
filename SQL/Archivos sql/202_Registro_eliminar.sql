
DROP PROCEDURE IF EXISTS registro_eliminar$
CREATE PROCEDURE registro_eliminar(in id_registroIn INT)
BEGIN
	delete from
		registro
	where 
		id_registro = id_registroIn;

END