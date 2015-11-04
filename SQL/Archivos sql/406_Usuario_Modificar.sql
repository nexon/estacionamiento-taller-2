DROP PROCEDURE IF EXISTS usuario_modificar $$
CREATE PROCEDURE usuario_modificar(
	inRut INT,
    inNombre VARCHAR(45),
	inContrasenia VARCHAR(45),
    inEmail VARCHAR(45),
    inTelefono INT
)
BEGIN
	UPDATE usuario
	SET
		nombre = inNombre,
        contrasenia = inContrasenia,
        email = inEmail,
        inTelefono = inTelefono

	WHERE rut = inRut;
END $$
