DROP PROCEDURE IF EXISTS conductor_actualizarConductor $$
CREATE PROCEDURE conductor_actualizarConductor
(IN id_conductor INT,IN id_usuario INT,IN reputacion FLOAT)
UPDATE conductor
SET 
id_usuario = id_usuario,
reputacion = reputacion
Where
	id_conductor = id_conductor



