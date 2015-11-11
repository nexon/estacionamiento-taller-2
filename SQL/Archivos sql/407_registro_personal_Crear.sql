DROP PROCEDURE IF EXISTS registro_personal_crear $$
CREATE PROCEDURE registro_personal_crear(
	inIngreso DATETIME,
	inSalida DATETIME,
	inIdPersonal INT,
	inIdEstacionamiento INT
	)
BEGIN
	INSERT INTO registro_personal (fecha_ingreso,fecha_salida,id_estacionamiento,id_personal)
	VALUES(inIngreso,inSalida,inIdEstacionamiento,inIdPersonal);
END $$

