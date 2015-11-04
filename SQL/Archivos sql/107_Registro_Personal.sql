DROP TABLE IF EXISTS registro_personal $$
CREATE TABLE registro_personal
(
 id_registro_personal INT NOT NULL AUTO_INCREMENT,
 fecha_ingreso DATETIME NOT NULL,
 fecha_salida DATETIME,
 id_estacionamiento INT NOT NULL,
 id_personal INT NOT NULL,
 PRIMARY KEY (id_registro_personal),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento),
 FOREIGN KEY (id_personal) REFERENCES personal (id_personal)
)
$$