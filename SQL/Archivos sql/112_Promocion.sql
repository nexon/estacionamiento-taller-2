DROP TABLE IF EXISTS promocion $$
CREATE TABLE promociones
(
 id_promo INT NOT NULL AUTO_INCREMENT,
 nombre VARCHAR(45) NOT NULL,
 descripcion VARCHAR(120) NOT NULL,
 fecha_inicio DATE NOT NULL,
 fecha_termino DATE NOT NULL,
 id_estacionamiento INT NOT NULL,
 PRIMARY KEY (id_promo),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento)
)
$$