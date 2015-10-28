 DROP PROCEDURE IF EXISTS Conductor_crear_desconocido $$
 CREATE PROCEDURE Conductor_crear_desconocido
 (
 	
 )
 INSERT INTO conductor(id_usuario)
 	VALUES (-1);
$$