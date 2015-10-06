DROP PROCEDURE IF EXISTS vehiculo_leer $$
	CREATE PROCEDURE `vehiculo_leer`(
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