DROP PROCEDURE IF EXISTS personal_estacionamiento_seleccionar $$
CREATE PROCEDURE personal_estacionamiento_seleccionar(
	inIdPersonal INT,
	inIdEstacionamiento INT
) 
BEGIN
  SELECT 
    *
  FROM 
	personal_estacionamiento
  WHERE
	id_personal = inIdPersonal AND
	id_estacionamiento = inIdEstacionamiento;
END
$$