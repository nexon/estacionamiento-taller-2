DROP PROCEDURE IF EXISTS personal_estacionamiento_modificar $$
CREATE PROCEDURE personal_estacionamiento_modificar(
	inIdPersonal INT,
  inIdEstacionamiento INT,
	inIdRol INT
)
BEGIN
	UPDATE personal_estacionamiento
	SET
		rol = inIdRol

	WHERE id_personal = inIdPersonal AND id_estacionamiento = inIdEstacionamiento AND id_rol = inIdRol;
END $$
