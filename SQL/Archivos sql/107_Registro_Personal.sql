DROP TABLE IF EXISTS registro_personal $$
CREATE TABLE registro_personal
(
 id_registro_personal INT NOT NULL AUTO_INCREMENT,
 fecha_ingreso DATETIME NOT NULL,
 fecha_salida DATETIME,
 estacionamiento_id_estacionamiento INT NOT NULL,
 personal_id_empleado INT NOT NULL,
 PRIMARY KEY (id_registro_personal),
 FOREIGN KEY (estacionamiento_id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento),
 FOREIGN KEY (personal_id_empleado) REFERENCES personal (id_personal)
)
$$