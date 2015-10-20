
 DROP PROCEDURE IF EXISTS Personal_Crear $$
 CREATE PROCEDURE Personal_Crear
 (
 	inId_usuario INT
 )
 BEGIN
 	INSERT INTO Personal(id_usuario)
 	VALUES (inId_usuario);
END$$
