DROP PROCEDURE IF EXISTS Personal_SeleccionarPorRut $$
CREATE PROCEDURE Personal_SeleccionarPorRut
(
	inRut INT
) 
BEGIN
SELECT rut, nombre, email, telefono, id_personal, contrasenia
FROM 
	personal p
	INNER JOIN Usuario u
	ON (p.id_usuario = u.rut AND p.id_usuario = inRut);
END$$