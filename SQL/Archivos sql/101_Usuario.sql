DROP TABLE IF EXISTS usuario $$
CREATE TABLE usuario
(
 rut INT NOT NULL,
 nombre VARCHAR(45) NOT NULL,
 contrasenia VARCHAR(45) NOT NULL,
 PRIMARY KEY (rut)
)
$$