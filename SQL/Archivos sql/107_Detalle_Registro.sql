DROP TABLE IF EXISTS detalle_registro $$
CREATE TABLE detalle_registro
(
 id_empleado INT NOT NULL,
 id_registro INT NOT NULL,
 detalle VARCHAR(10) NOT NULL,
 FOREIGN KEY (id_empleado) REFERENCES empleado (id_empleado),
 FOREIGN KEY (id_registro) REFERENCES registro (id_registro)
)
$$
/* Detalle {Entrada/Salida) */