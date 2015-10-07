
use `Estacionamiento`; $$
DROP PROCEDURE IF EXISTS Personal_Crear $$
CREATE PROCEDURE Personal_Crear(
 id_personal INT,
 id_usuario INT

)
BEGIN
INSERT INTO `Estacionamiento`.`Personal`
(id_personal,
id_usuario)
VALUES
(inId_personal,inId_usuario);
END $$