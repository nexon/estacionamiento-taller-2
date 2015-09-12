DROP TABLE IF EXISTS usuarios $$
CREATE TABLE usuarios
(
 id_usuario INT NOT NULL AUTO_INCREMENT,
 nombre VARCHAR(45) NOT NULL,
 rut VARCHAR(15),
 contrasenia VARCHAR(45) NOT NULL,
 PRIMARY KEY (id_usuario)
)
$$