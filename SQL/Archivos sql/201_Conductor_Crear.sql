 DROP PROCEDURE IF EXISTS Conductor_Crear $$
 CREATE PROCEDURE Conductor_Crear
 (
 	IN inId_usuario INT
 )  
IF(SELECT id_usuario FROM conductor WHERE id_usuario = inId_usuario) THEN
    SELECT id_usuario from conductor where id_usuario = inId_usuario;
ELSE
INSERT INTO conductor(id_usuario)
 	VALUES ((SELECT id_usuario FROM usuario Where id_usuario=inId_usuario));
END IF;
$$