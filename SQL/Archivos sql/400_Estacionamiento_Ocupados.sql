DROP PROCEDURE IF EXISTS Estacionamiento_Ocupados $$
CREATE PROCEDURE Estacionamiento_Ocupados (
	inID bigint
)
BEGIN

	SELECT
		patente, codigo ,fecha_reserva, fecha_ingreso
	FROM
		Espacio, Vehiculo, (SELECT fecha_reserva, fecha_ingreso, id_espacio, id_vehiculo 
								 FROM Registro
							  	 WHERE id_estacionamiento = inID AND fecha_ingreso is NOT NULL AND fecha_salida is NULL) AS ocupados
	WHERE Espacio.id_espacio = 	ocupados.id_espacio AND Vehiculo.id_vehiculo = ocupados.id_vehiculo;

END
$$