DROP TABLE IF EXISTS tipo_punto_acceso $$
CREATE TABLE tipos_punto_acceso
(
 id_tipo INT NOT NULL AUTO_INCREMENT,
 nombre VARCHAR(45) NOT NULL,
 PRIMARY KEY (id_tipo)
)
$$