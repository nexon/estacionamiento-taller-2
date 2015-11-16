DROP TABLE IF EXISTS personal_estacionamiento $$
CREATE TABLE personal_estacionamiento
(
 id_personal INT NOT NULL,
 id_estacionamiento INT NOT NULL,
 id_rol Int NOT NULL,
 PRIMARY KEY (id_personal, id_estacionamiento, id_rol),
 FOREIGN KEY (id_estacionamiento) REFERENCES estacionamiento (id_estacionamiento),
 FOREIGN KEY (id_personal) REFERENCES personal (id_personal),
 UNIQUE KEY id_personal_unico (id_personal,id_estacionamiento)
)
$$