DROP PROCEDURE IF EXISTS Vehiculo_Eliminar $$
	CREATE PROCEDURE `Vehiculo_Eliminar`(
		IN id int(11)
	)
	BEGIN
		DELETE FROM `estacionamiento`.`vehiculo`
	    
		WHERE `vehiculo`.`id_vehiculo`=id;

	END
$$