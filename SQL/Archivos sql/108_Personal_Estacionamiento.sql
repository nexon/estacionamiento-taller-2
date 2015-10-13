DROP TABLE IF EXISTS personal_estacionamiento $$
CREATE TABLE personal_estacionamiento
(
 id INT NOT NULL AUTO_INCREMENT,
 id_personal INT NOT NULL,
 id_estacionamiento INT NOT NULL,
 PRIMARY KEY (id),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento),
 FOREIGN KEY (id_personal) REFERENCES personal (id_personal)
)
$$