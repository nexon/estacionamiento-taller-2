DROP PROCEDURE IF EXISTS personal_estacionamiento_agregar $$
CREATE PROCEDURE personal_estacionamiento_agregar(
	inIdPersonal INT, 
	inIdEstacionamientoIn INT,
	inIdRol
)
BEGIN
	insert into 
		personal_estacionamiento(id_personal, id_estacionamiento, id_rol)
	values
		(inIdPersonal, inIdEstacionamiento, inIdRol);

END
$$