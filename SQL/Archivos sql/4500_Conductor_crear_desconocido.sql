 DROP PROCEDURE IF EXISTS Conductor_crear_desconocido $$
 CREATE PROCEDURE Conductor_Crear
 (
 	
 )
 INSERT INTO conductor(id_usuario)
 	VALUES (-1);
$$