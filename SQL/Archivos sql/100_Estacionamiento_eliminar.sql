DROP PROCEDURE IF EXISTS estacionamiento_eliminar $$
CREATE PROCEDURE estacionamiento_eliminar( 
	inIdEstacionamiento INT(11)
)
BEGIN
	DELETE FROM estacionamiento
	WHERE
		id_estacionamiento = inIdEstacionamiento;
END $$