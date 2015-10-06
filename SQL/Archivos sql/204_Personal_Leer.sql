DROP PROCEDURE IF EXISTS Personal_Leer $$
	CREATE PROCEDURE `Personal_Leer`(
		id_personal INT NOT NULL AUTO_INCREMENT
	)
	BEGIN
		SELECT `personal`.`id_personal`,
	    `personal`.`id_usuario`,
	    `personal`.`id_estacionamiento`
		FROM `estacionamiento`.`personal`
		WHERE personal.id_personal = id;
	END
$$

