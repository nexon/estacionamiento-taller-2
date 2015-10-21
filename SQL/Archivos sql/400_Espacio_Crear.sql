
DROP PROCEDURE IF EXISTS espacio_crear$
CREATE PROCEDURE espacio_crear(in codigoIn VARCHAR(15), in id_estacionamientoIn INT)
BEGIN
	insert into 
		espacio(codigo, id_estacionamiento)
	values
		(codigoIn, id_estacionamientoIn);

END
