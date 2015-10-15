DROP TABLE IF EXISTS conductor $$
CREATE TABLE conductor
(
 id_conductor INT NOT NULL AUTO_INCREMENT,
 id_usuario INT NOT NULL,
 PRIMARY KEY (id_conductor),
 FOREIGN KEY (id_usuario) REFERENCES usuario (rut)
)
$$