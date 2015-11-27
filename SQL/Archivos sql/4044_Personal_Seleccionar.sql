
DROP PROCEDURE IF EXISTS Personal_Seleccionar $$
CREATE PROCEDURE Personal_Seleccionar
(
	inId_personal INT
) 
BEGIN
SELECT rut, nombre, email, telefono, id_personal, contrasenia
FROM 
	personal pe_est
LEFT JOIN usuario us
	ON us.rut = pe_est.id_usuario
WHERE pe_est.id_personal = inId_personal;
END$$