DROP PROCEDURE IF EXISTS Personal_Estacionamiento_Todos $$
CREATE PROCEDURE Personal_Estacionamiento_Todos(
	inIdEstacionamiento INT
) 
BEGIN
  SELECT 
  	personal.id_personal		AS Personal_ID,
    rut			    AS Usuario_rut,
	nombre			AS Usuario_Nombre,
	contrasenia	    AS Usuario_Contrasenia,	
	email 	        AS Usuario_Email,
	telefono	    AS Usuario_Telefono
  FROM 
	personal_estacionamiento, personal, usuario
  WHERE
	usuario.rut = personal.id_usuario AND 
	personal.id_personal = personal_estacionamiento.id_personal AND
	personal_estacionamiento.id_estacionamiento = inIdEstacionamiento;
END
$$