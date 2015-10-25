DROP PROCEDURE IF EXISTS Estacionamiento_Todos $$
CREATE PROCEDURE Estacionamiento_Todos (
	inID_Estacionamiento bigint
)
BEGIN

	SELECT
		codigo			AS Espacio_Codigo,
		patente			AS Vehiculo_Patente,
		fecha_reserva	AS fecha_Reserva,
		fecha_ingreso 	AS Fecha_Ingreso,
		fecha_salida 	AS Fecha_Salida
	FROM
		( SELECT codigo, id_vehiculo ,fecha_reserva, fecha_ingreso, fecha_salida FROM
							(SELECT id_espacio, codigo FROM Espacio WHERE id_estacionamiento = inID_Estacionamiento) as Espacios 
								LEFT JOIN Registro
								ON Registro.id_espacio = Espacios.id_espacio AND fecha_salida IS NULL  ) AS Todos
		LEFT JOIN Vehiculo
		ON Vehiculo.id_vehiculo = Todos.id_vehiculo;
END
$$