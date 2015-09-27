DROP TABLE IF EXISTS puntos_acceso $$
CREATE TABLE puntos_acceso
(
 id_punto_acceso INT NOT NULL AUTO_INCREMENT, 
 nombre VARCHAR(45) NOT NULL,
 direccion VARCHAR(45) NOT NULL,
 latitud DECIMAL(10,8) NOT NULL,
 longitud DECIMAL(11,8) NOT NULL,
 id_tipo INT NOT NULL,
 id_estacionamiento INT NOT NULL,
 PRIMARY KEY (id_punto_acceso),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamientos (id_estacionamiento),
 FOREIGN KEY (id_tipo) REFERENCES tipos_punto_acceso (id_tipo)
)
$$