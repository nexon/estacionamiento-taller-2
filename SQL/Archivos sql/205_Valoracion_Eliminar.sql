DROP PROCEDURE IF EXISTS eliminarValoracion $$
CREATE PROCEDURE eliminarValoracion( 
	inIdValoracion INT
)
BEGIN
	DELETE FROM valoracion
	WHERE
		id_valoracion = inIdValoracion;
END $$