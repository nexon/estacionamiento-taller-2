DROP PROCEDURE IF EXISTS Personal_Seleccionar $$
	CREATE PROCEDURE `Personal_Seleccionar`(
		id_personal INT 
	)
	BEGIN
		SELECT `personal`.`id_personal`,
	    `personal`.`id_usuario`
		FROM `estacionamiento`.`personal`
		WHERE personal.id_personal = id;
	END
$$
