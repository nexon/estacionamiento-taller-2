DROP PROCEDURE IF EXISTS valoracion_eliminar $$
CREATE PROCEDURE valoracion_eliminar( 
	inIdValoracion INT
)
BEGIN
	DELETE FROM valoracion
	WHERE
		id_valoracion = inIdValoracion;
END $$