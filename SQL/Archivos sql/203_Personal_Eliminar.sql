DROP PROCEDURE IF EXISTS Personal_Modificar $$
CREATE PROCEDURE Personal_Modificar(
 id_personal INT 
)
BEGIN
DELETE FROM `Estacionamiento`.`Personal`
WHERE `id_personal` =`id_personal`;
END $$