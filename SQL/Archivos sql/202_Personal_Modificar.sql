use `Estacionamiento`; $$
DROP PROCEDURE IF EXISTS Personal_Modificar $$
CREATE PROCEDURE Personal_Modificar(
 id_personal INT NOT NULL AUTO_INCREMENT,
 id_usuario INT NOT NULL,
 propietario BOOLEAN NOT NULL,
)
BEGIN
UPDATE `Estacionamiento`.`Personal`
SET
(id_usuario,
propietario)
WHERE `id_personal` =`id_personal`;
END $$