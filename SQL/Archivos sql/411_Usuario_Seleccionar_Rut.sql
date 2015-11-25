DROP PROCEDURE IF EXISTS Usuario_Seleccionar_Rut $$
CREATE PROCEDURE Usuario_Seleccionar_Rut
(
	inRut INT
) 
BEGIN
SELECT
	rut, nombre, contrasenia, email, telefono
FROM usuario
WHERE 
	rut = inRut;
END$$
$$