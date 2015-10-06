DROP PROCEDURE IF EXISTS estacionamiento.conductor_borrarConductor $$
CREATE PROCEDURE conductor_borrarConductor
(IN id_conductorA INT)
DELETE From estacionamiento.conductor
WHERE
	id_conductor=id_conductorA


