DROP PROCEDURE IF EXISTS Vehiculo_Crear $$
	CREATE PROCEDURE `Vehiculo_Crear`(
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