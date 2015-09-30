DROP TABLE IF EXISTS empleados $$
CREATE TABLE empleados
(  
 id_empleado INT NOT NULL AUTO_INCREMENT,
 id_usuario INT NOT NULL,
 id_estacionamiento INT NOT NULL,
 propietario BOOLEAN NOT NULL,
 PRIMARY KEY (id_empleado),
 FOREIGN KEY (id_usuario) REFERENCES usuarios (id_usuario),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamientos (id_estacionamiento)
)
$$