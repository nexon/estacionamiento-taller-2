DROP PROCEDURE IF EXISTS usuario_modificar $$
CREATE PROCEDURE usuario_modificar(
	inRut INT,
    inNombre VARCHAR(45),
	inContrasenia VARCHAR(64),
    inEmail VARCHAR(45),
    inTelefono INT
)
BEGIN
	UPDATE usuario
	SET
		rut = inRut,
		nombre = inNombre,
        contrasenia = inContrasenia,
        email = inEmail,
        telefono = inTelefono

	WHERE rut = inRut;
END $$
