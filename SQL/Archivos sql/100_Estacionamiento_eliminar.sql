DROP PROCEDURE IF EXISTS estacionamiento_eliminar $$
CREATE PROCEDURE estacionamiento_eliminar( 
	inIdEstacionamiento INT
)
BEGIN
	DELETE FROM estacionamiento
	WHERE
		id_estacionamiento = inIdEstacionamiento;
END $$