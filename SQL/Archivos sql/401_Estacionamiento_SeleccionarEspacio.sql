DROP PROCEDURE IF EXISTS Estacionamiento_SeleccionarEspacio $$

CREATE PROCEDURE Estacionamiento_SeleccionarEspacio (
	inID bigint,
	inCodigo VARCHAR(15)
)
BEGIN
	SELECT
		codigo             as inCodigo,
		id_estacionamiento as inID
	FROM
		Espacio
	WHERE
		id_estacionamiento = inID and codigo = inCodigo;

END
$$