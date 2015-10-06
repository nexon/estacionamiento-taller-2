DROP PROCEDURE IF EXISTS vehiculo_actualizar $$
	CREATE PROCEDURE `vehiculo_actualizar`(
		IN patente_actual varchar(15),
		IN id int(11),
	    IN patente_nueva varchar(15)

	)
	BEGIN
		UPDATE `estacionamiento`.`vehiculo`
		SET
			`patente` = patente_nueva
		WHERE 
			`id_vehiculo` = id AND `patente` = patente_actual;
	END
$$