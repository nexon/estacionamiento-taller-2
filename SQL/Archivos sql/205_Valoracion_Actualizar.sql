DROP PROCEDURE IF EXISTS valoracion_actualizar $$
CREATE PROCEDURE valoracion_actualizar(
	inIdValoracion INT,
	inValorConductor FLOAT,
	inValorEstacionamiento FLOAT
)
BEGIN
	UPDATE valoracion
	SET 
		valor_conductor = inValorConductor,
		valor_estacionamiento = inValorEstacionamiento,
		fecha_hora = NOW()
	WHERE id_valoracion = inIdValoracion;
END $$