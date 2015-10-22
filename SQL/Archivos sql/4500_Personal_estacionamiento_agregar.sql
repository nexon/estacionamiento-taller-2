DROP PROCEDURE IF EXISTS personal_estacionamiento_agregar $$
CREATE PROCEDURE personal_estacionamiento_agregar(in id_personalIn INT, in id_estacionamientoIn INT)
BEGIN
	insert into 
		personal_estacionamiento(id_personal, id_estacionamiento)
	values
		(id_personalIn, id_estacionamientoIn);

END
$$