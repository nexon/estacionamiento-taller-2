DROP PROCEDURE IF EXISTS estacionamiento_personal $$
CREATE PROCEDURE estacionamiento_personal(
	inIdEstacionamiento INT
) 
BEGIN
SELECT rut, nombre, email, telefono, id_rol, id_personal, contrasenia
	FROM 
	(SELECT id_usuario, id_rol, p_est.id_personal 
	FROM personal_estacionamiento p_est
	LEFT JOIN personal per
		ON per.id_personal  = p_est.id_personal
	WHERE p_est.id_estacionamiento = 1) AS pe_est
	LEFT JOIN usuario us
		ON us.rut = pe_est.id_usuario;
END
$$