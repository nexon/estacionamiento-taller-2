DROP PROCEDURE IF EXISTS conductor_obtenerConductor $$
CREATE PROCEDURE conductor_obtenerConductor
(IN id_conductorA INT) 
SELECT
	id_conductor,id_usuario,reputacion
From conductor
WHERE id_conductor=id_conductorA

