DROP PROCEDURE IF EXISTS Vehiculo_Seleccionar $$
	CREATE PROCEDURE `Vehiculo_Seleccionar`(
		IN id int(11)
	)
	BEGIN
		SELECT `vehiculo`.`id_vehiculo`,
	    `vehiculo`.`patente`,
	    `vehiculo`.`id_conductor`
		FROM `estacionamiento`.`vehiculo`
		WHERE vehiculo.id_vehiculo = id;
	END
$$