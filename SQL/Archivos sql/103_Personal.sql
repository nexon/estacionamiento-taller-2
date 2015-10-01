DROP TABLE IF EXISTS personal $$
CREATE TABLE personal
(  
 id_personal INT NOT NULL AUTO_INCREMENT,
 id_usuario INT NOT NULL,
 id_estacionamiento INT NOT NULL,
 propietario BOOLEAN NOT NULL,
 PRIMARY KEY (id_personal),
 FOREIGN KEY (id_usuario) REFERENCES usuario (id_usuario),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento)
)
$$