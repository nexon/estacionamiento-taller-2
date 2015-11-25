DROP PROCEDURE IF EXISTS registro_personal_salida $$
CREATE PROCEDURE registro_personal_salida(
	inIdRegistroPersonal INT,
    inSalida DATETIME
	)
BEGIN
	update registro_personal 
    set fecha_salida = inSalida
    where inIdRegistroPersonal = id_registro_personal;
END $$
