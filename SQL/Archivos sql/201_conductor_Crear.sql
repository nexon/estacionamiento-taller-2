 DROP PROCEDURE IF EXISTS Conductor_Crear $$
 CREATE PROCEDURE Conductor_Crear
 (
 	inId_usuario INT
 )  
 BEGIN
 	INSERT INTO conductor(id_usuario)
 	VALUES ((SELECT id_usuario FROM usuario Where id_usuario=inId_usuario));
END$$ 	
