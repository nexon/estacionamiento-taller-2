DROP TABLE IF EXISTS personal $$
CREATE TABLE personal
(  
 id_personal INT NOT NULL AUTO_INCREMENT,
 id_usuario INT NOT NULL,
 PRIMARY KEY (id_personal),
 FOREIGN KEY (id_usuario) REFERENCES usuario (rut)
)
$$