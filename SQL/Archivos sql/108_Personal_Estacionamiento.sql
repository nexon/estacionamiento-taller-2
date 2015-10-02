DROP TABLE IF EXISTS personal_estacionamiento $$
CREATE TABLE personal_estacionamiento
(
 id INT NOT NULL AUTO_INCREMENT,
 personal_id_empleado INT NOT NULL,
 estacionamiento_id_estacionamiento INT NOT NULL,
 PRIMARY KEY (id_registro_personal),
 FOREIGN KEY (estacionamiento_id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento),
 FOREIGN KEY (personal_id_empleado) REFERENCES personal (id_empleado)
)
$$