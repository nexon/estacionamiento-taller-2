DROP PROCEDURE IF EXISTS personal_estacionamiento_agregar $$
CREATE PROCEDURE personal_estacionamiento_agregar(
	inId_personal INT, 
	inId_estacionamientoIn INT,
	inId_rol
)
BEGIN
	insert into 
		personal_estacionamiento(id_personal, id_estacionamiento, id_rol)
	values
		(inId_personal, inId_estacionamiento, inId_rol);

END
$$