DROP PROCEDURE IF EXISTS Usuario_Seleccionar $$
CREATE PROCEDURE Usuario_Seleccionar
(
	inEmail VARCHAR(45)
) 
BEGIN
SELECT
	rut, nombre, contrasenia, email, telefono
FROM usuario
WHERE 
	email = inEmail;
END$$
$$