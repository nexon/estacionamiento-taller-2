DROP PROCEDURE IF EXISTS valoracion_crear $$
CREATE PROCEDURE valoracion_crear(
	inValorConductor FLOAT,
	inValorEstacionamiento FLOAT,
	inIdConductor INT,
	inIdEstacionamiento INT
	)
BEGIN
	INSERT INTO valoracion (valor_conductor,valor_estacionamiento,fecha_hora,id_conductor,id_estacionamiento)
	VALUES(inValorConductor,inValorEstacionamiento,NOW(),inIdConductor,inIdEstacionamiento);
END $$