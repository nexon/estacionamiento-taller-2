 DROP PROCEDURE IF EXISTS Conductor_Crear $$
 CREATE PROCEDURE Conductor_Crear
 (
 	inId_usuario INT
 ) 
 INSERT INTO conductor(id_usuario)
 	VALUES ((SELECT rut FROM usuario Where rut=inId_usuario));
 	
$$