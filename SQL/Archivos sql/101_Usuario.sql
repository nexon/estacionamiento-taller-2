DROP TABLE IF EXISTS usuario $$
CREATE TABLE usuario
(
 id_usuario INT NOT NULL AUTO_INCREMENT,
 nombre VARCHAR(45) NOT NULL,
 rut INT,
 contrasenia VARCHAR(45) NOT NULL,
 email VARCHAR(45) NOT NULL,
 telefono INT,
 PRIMARY KEY (id_usuario)
)
$$