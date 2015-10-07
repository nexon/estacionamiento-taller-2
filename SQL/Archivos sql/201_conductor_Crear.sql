 DROP PROCEDURE IF EXISTS conductor_Crear $$
 CREATE PROCEDURE conductor_Crear
 (
 	IN inId_usuario INT,
 	IN inReputacion FLOAT
 )  
 BEGIN
 	INSERT INTO conductor(id_usuario,reputacion)
 	VALUES ((SELECT id_usuario FROM usuario Where id_usuario=inId_usuario),inReputacion);
END$$ 	
