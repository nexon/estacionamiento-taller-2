DROP PROCEDURE IF EXISTS personal_estacionamiento_agregar $$
CREATE PROCEDURE personal_estacionamiento_agregar(
	inIdPersonal INT, 
	inIdEstacionamiento INT,
	inIdRol INT
)
BEGIN
	insert into 
		personal_estacionamiento(id_personal, id_estacionamiento, id_rol)
	values
		(inIdPersonal, inIdEstacionamiento, inIdRol);

END
$$