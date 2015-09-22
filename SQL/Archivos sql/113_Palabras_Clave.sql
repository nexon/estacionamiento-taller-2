DROP TABLE IF EXISTS palabras_clave $$
CREATE TABLE palabras_clave
(
 id_palabra INT NOT NULL AUTO_INCREMENT,
 clave VARCHAR(45) NOT NULL,
 PRIMARY KEY (id_palabra)
)
$$