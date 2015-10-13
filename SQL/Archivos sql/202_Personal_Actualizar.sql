
use `Estacionamiento`; $$
DROP PROCEDURE IF EXISTS Personal_Actualizar $$
CREATE PROCEDURE Personal_Actualizar (
 id_personal INT ,
 id_usuario INT 
)
BEGIN
UPDATE `Estacionamiento`.`Personal`
SET
id_usuario=id_usuario
WHERE `id_personal` =`id_personal`;
END $$