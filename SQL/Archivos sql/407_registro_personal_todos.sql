DROP PROCEDURE IF EXISTS registro_personal_todos $$
CREATE PROCEDURE registro_personal_todos(
	inIdEstacionamiento INT(11)
) 
BEGIN
  SELECT
	rp.id_registro_personal,
	u.nombre, 
    u.rut,
    rp.fecha_ingreso,
    rp.fecha_salida
  FROM 
	(SELECT
		r.id_registro_personal,
		r.fecha_ingreso,
        r.fecha_salida,
        r.id_estacionamiento,
        p.id_usuario
	 FROM
		registro_personal r
	 INNER JOIN personal p
     ON r.id_personal = p.id_personal
    ) as rp
  INNER JOIN
	usuario u
  ON
	 rp.id_usuario = u.rut and rp.id_estacionamiento = inIdEstacionamiento;
END $$