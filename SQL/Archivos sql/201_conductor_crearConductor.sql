 DROP PROCEDURE IF EXISTS estacionamiento.conductor_crearConductor $$
 CREATE PROCEDURE conductor_crearConductor
 (IN id_usuarioA INT,IN reputaciona FLOAT)
  Begin
 	INSERT INTO estacionamiento.conductor(id_usuario,reputacion)
 	VALUES ((SELECT id_usuario FROM estacionamiento.usuario Where id_usuario=id_usuarioA),reputaciona);
END 	
