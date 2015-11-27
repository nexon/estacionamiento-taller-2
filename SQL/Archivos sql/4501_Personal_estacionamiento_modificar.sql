DROP PROCEDURE IF EXISTS personal_estacionamiento_modificar $$
CREATE PROCEDURE personal_estacionamiento_modificar(
	inIDPersonal INT,
  	inIDEstacionamiento INT,
  	inIDRol INT
)
BEGIN
	UPDATE personal_estacionamiento
	SET id_rol = inIDRol
	WHERE id_personal = inIDPersonal AND id_estacionamiento = inIDEstacionamiento;
END $$
