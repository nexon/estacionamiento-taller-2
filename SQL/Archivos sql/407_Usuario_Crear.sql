
 DROP PROCEDURE IF EXISTS Usuario_Crear $$
 CREATE PROCEDURE Usuario_Crear
 (
 	inRut INT,
 	inNombre VARCHAR(45),
 	inContrasenia VARCHAR(45),
 	inEmail VARCHAR(45),
 	inTelefono INT
 )
 BEGIN
 	INSERT INTO Usuario(rut, nombre, contrasenia, email, telefono)
 	VALUES (inRut, inNombre, inContrasenia, inEmail, inTelefono);
END$$