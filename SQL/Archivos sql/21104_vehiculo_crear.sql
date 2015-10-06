DROP PROCEDURE IF EXISTS vehiculo_crear $$
	CREATE PROCEDURE `vehiculo_crear`(
	    IN patente varchar(15),
	    IN id_conductor int(11)
	)
	BEGIN
		INSERT INTO `estacionamiento`.`vehiculo`
			(
				`patente`,
				`id_conductor`
			)
		VALUES
			(
				patente,
				id_conductor
			);
	END
$$