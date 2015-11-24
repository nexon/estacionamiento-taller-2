DROP TABLE IF EXISTS usuario $$
CREATE TABLE usuario
(
 rut INT NOT NULL,
 nombre VARCHAR(45) NOT NULL,
 contrasenia VARCHAR(64) NOT NULL,
 email VARCHAR(45),
 telefono INT,
 PRIMARY KEY (rut)
)
$$