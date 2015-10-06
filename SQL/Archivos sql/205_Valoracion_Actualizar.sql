DROP PROCEDURE IF EXISTS actualizarValoracion $$
CREATE PROCEDURE actualizarValoracion(
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