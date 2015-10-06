DROP PROCEDURE IF EXISTS vehiculo_borrar $$
	CREATE PROCEDURE `vehiculo_borrar`(
		IN id int(11)
	)
	BEGIN
		DELETE FROM `estacionamiento`.`vehiculo`
	    
		WHERE `vehiculo`.`id_vehiculo`=id;

	END
$$