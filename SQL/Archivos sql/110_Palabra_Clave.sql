DROP TABLE IF EXISTS palabra_clave $$
CREATE TABLE palabra_clave
(
 id_palabra INT NOT NULL AUTO_INCREMENT,
 clave VARCHAR(45) NOT NULL,
 PRIMARY KEY (id_palabra)
)
$$