DROP PROCEDURE IF EXISTS usuario_modificar $$
CREATE PROCEDURE usuario_modificar(
	inRut INT,
    inNombre VARCHAR(45),
	inContrasenia VARCHAR(45),
)
BEGIN
	UPDATE usuario
	SET 
		nombre = inNombre,
        contrasenia = inContrasenia,
        
	WHERE rut = inRut;
END $$