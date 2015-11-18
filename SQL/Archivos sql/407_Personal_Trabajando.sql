DROP PROCEDURE IF EXISTS personal_trabajando $$
CREATE PROCEDURE personal_trabajando(
	inIdEstacionamiento INT
) 
BEGIN
  SELECT 
    id_personal
  FROM 
	registro_personal
  WHERE
     inIdEstacionamiento = id_estacionamiento AND registro_personal.fecha_salida IS NULL;
END
$$