
DROP PROCEDURE IF EXISTS espacio_crear$
CREATE PROCEDURE espacio_crear(in inCodigo VARCHAR(15), in inId_estacionamiento INT)
BEGIN
	insert into 
		espacio(codigo, id_estacionamiento)
	values
		(inCodigo, inId_estacionamiento);

END
