use `Estacionamiento`; $$
DROP PROCEDURE IF EXISTS Personal_Crear $$
CREATE PROCEDURE Personal_Crear(
 id_personal INT NOT NULL AUTO_INCREMENT,
 id_usuario INT NOT NULL,
 propietario BOOLEAN NOT NULL,
)
BEGIN
INSERT INTO `Estacionamiento`.`Personal`
(id_personal,
id_usuario,
propietario)
VALUES
(inId_personal,inId_usuario,inPropietario);
END $$

