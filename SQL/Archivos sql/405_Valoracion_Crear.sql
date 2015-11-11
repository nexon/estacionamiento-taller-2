DROP PROCEDURE IF EXISTS valoracion_crear $$
CREATE PROCEDURE valoracion_crear(
	inValorConductor FLOAT,
	inValorEstacionamiento FLOAT,
	inIdUsuario INT,
	inIdEstacionamiento INT
	)
BEGIN
	INSERT INTO valoracion (valor_conductor,valor_estacionamiento,fecha_hora,id_conductor,id_estacionamiento)
	VALUES(inValorConductor,inValorEstacionamiento,NOW(),(SELECT id_conductor FROM conductor WHERE id_usuario = inIdUsuario LIMIT 1),inIdEstacionamiento);
END $$

