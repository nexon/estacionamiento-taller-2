DROP PROCEDURE IF EXISTS personal_estacionamiento_agregar $$
CREATE PROCEDURE personal_estacionamiento_agregar(
	inIdPersonal INT, 
	inIdEstacionamientoIn INT,
	inIdRol INT
)
BEGIN
	INSERT INTO
		personal_estacionamiento(id_personal, id_estacionamiento, id_rol)
	VALUES
		(inIdPersonal, inIdEstacionamiento, inIdRol);

END
$$