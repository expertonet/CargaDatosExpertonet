
insert into experton_expertonet.nomRoles (id_rol,nombre_rol)values(1,'Administrador ExpertoNet');
insert into experton_expertonet.nomGrupoRoles (id_grupo_rol, nombre_grupo_rol)values(1, 'ExpertoNet');
insert into experton_expertonet.nomGrupoRoles_x_Roles (id_grupo_rol, id_rol)values(1,1);

insert into experton_expertonet.nomNivelAcceso (id_nivel_acceso, Nivel_Acceso)values(1,'Administrador');
insert into experton_expertonet.nomNivelAcceso (id_nivel_acceso, Nivel_Acceso)values(2,'Desarrollo');
insert into experton_expertonet.nomNivelAcceso (id_nivel_acceso, Nivel_Acceso)values(3,'Usuario');
insert into experton_expertonet.nomNivelAcceso (id_nivel_acceso, Nivel_Acceso)values(4,'Empresa');
insert into experton_expertonet.nomNivelAcceso (id_nivel_acceso, Nivel_Acceso)values(5,'Empleado');
insert into experton_expertonet.nomNivelAcceso (id_nivel_acceso, Nivel_Acceso)values(6,'Invitado');

insert into experton_expertonet.nomOrganizaciones(id_organizacion, NombreOrganizacion, id_organizacion_original)values(1, 'ExpertoNet S.A. de C.V.', '1');
insert into experton_expertonet.nomOrganizaciones(id_organizacion, NombreOrganizacion, id_organizacion_original)values(2, 'Grupo Autofin S.A', '0100');
insert into experton_expertonet.nomOrganizaciones(id_organizacion, NombreOrganizacion, id_organizacion_original)values(3, 'ExpertoNet S.A. de C.V.', 'bnet');

insert into experton_expertonet.nomEmpresas (id_empresa, NombreEmpresa, id_empresa_original,RFC,RazonSocial)values(1, 'Expertonet Nominas', '1', 'EXPERTONET123', 'EXPERTONET S.A. DE C.V.');
insert into experton_expertonet.nomEmpresas (id_empresa, NombreEmpresa, id_empresa_original,RFC,RazonSocial)values(2, 'DVA Logistica Integral Corporativa, S.A. de C.V.', 'LIC', 'DVALOGISTICA', 'DVALOGISTICA S.A. DE C.V.');
insert into experton_expertonet.nomEmpresas (id_empresa, NombreEmpresa, id_empresa_original,RFC,RazonSocial)values(3, 'King Autobuses de México, S.A. de C.V.', 'KAM', 'KINGAUTOBUSES', 'KINGAUTOBUSES S.A. DE C.V.');
insert into experton_expertonet.nomEmpresas (id_empresa, NombreEmpresa, id_empresa_original,RFC,RazonSocial)values(4, 'Lux Motors Veracruz, S.A. de C.V.', 'LMV', 'LUXMOTORS', 'LUXMOTORS S.A. DE C.V.');
insert into experton_expertonet.nomEmpresas (id_empresa, NombreEmpresa, id_empresa_original,RFC,RazonSocial)values(5, 'Binet S.A de C.V.', '5', 'TBN110919K19', 'TECNOLOGIA BI NET MEXICO" SA DE CV');

insert into experton_expertonet.nomLugaresTrabajo (id_lugartrabajo, NombreLugarTrabajo, id_lugartrabajo_original)values(1, 'CDMX', '1');
insert into experton_expertonet.nomLugaresTrabajo (id_lugartrabajo, NombreLugarTrabajo, id_lugartrabajo_original)values(2, 'CORPORATIVO', '00018');
insert into experton_expertonet.nomLugaresTrabajo (id_lugartrabajo, NombreLugarTrabajo, id_lugartrabajo_original)values(3, 'HIDALGO_FHA', '00064');
insert into experton_expertonet.nomLugaresTrabajo (id_lugartrabajo, NombreLugarTrabajo, id_lugartrabajo_original)values(4, 'VERACRUZ_LMV_AGE', '00013');
insert into experton_expertonet.nomLugaresTrabajo (id_lugartrabajo, NombreLugarTrabajo, id_lugartrabajo_original)values(5, 'CDMX', '5');

insert into experton_expertonet.nomTiposEmpleados (id_TipoEmpleado, NombreTipoEmpleado, id_TipoEmpleado_original)values(1, 'Asalariado', '1');
insert into experton_expertonet.nomTiposEmpleados (id_TipoEmpleado, NombreTipoEmpleado, id_TipoEmpleado_original)values(2, 'Asalariado', '01');
insert into experton_expertonet.nomTiposEmpleados (id_TipoEmpleado, NombreTipoEmpleado, id_TipoEmpleado_original)values(3, 'Honorarios', '03');
insert into experton_expertonet.nomTiposEmpleados (id_TipoEmpleado, NombreTipoEmpleado, id_TipoEmpleado_original)values(4, 'Comisionista', '04');
insert into experton_expertonet.nomTiposEmpleados (id_TipoEmpleado, NombreTipoEmpleado, id_TipoEmpleado_original)values(5, 'Asalariado', '5');

insert into experton_expertonet.TipoSistema (id_TipoSistema, TipoSistema)values(1, 'Nomina');
insert into experton_expertonet.TipoSistema (id_TipoSistema, TipoSistema)values(2, 'Facturas');


insert into experton_expertonet.nomUsuarios (id_usuario, nombre_usuario, contrasena, id_empleado, id_organizacion, id_empresa, id_lugartrabajo, id_TipoEmpleado, id_nivel_acceso,id_TipoSistema)values(1,'expadmin','123',1,1,1,1,1,4,2);
insert into experton_expertonet.nomUsuarios (id_usuario, nombre_usuario, contrasena, id_empleado, id_organizacion, id_empresa, id_lugartrabajo, id_TipoEmpleado, id_nivel_acceso,id_TipoSistema)values(2,'afmadmin','123',1,1,1,1,1,4,2);

insert into experton_expertonet.nomUsuario_x_GrupoRoles (id_usuario, id_grupo_rol)values(1,1);
insert into experton_expertonet.nomUsuario_x_GrupoRoles (id_usuario, id_grupo_rol)values(2,1);

insert into experton_expertonet.nomOrganizacion_x_Rol (id_organizacion, id_rol)values(1,1);

insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(1,'Perfil','mnu_perfil');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(2,'Empleados','mnu_empleados_0');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(3,'Asistencia','mnu_asistencia');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(4,'Vacaciones','mnu_vacaciones');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(5,'Cursos DC-4','mnu_cursosdc4');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(6,'Empleados DC-4','mnu_empleadosdc4');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(7,'Asignar Cursos DC-4','mnu_asignarcursosdc4');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(8,'Generar DC-4','mnu_generardc4');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(9,'Impresión DC-3','mnu_generardc3');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(10,'Catálogo Frecuencia','mnu_catfreq');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(11,'Catálogo ISR','mnu_catisr');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(12,'Catálogo Subsidio','mnu_catsubsidio');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(13,'Carga Social','mnu_cargasocial_0');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(14,'Recibos de Nómina','mnu_recibosnomina');
insert into experton_expertonet.nomMenus(id_menu, nombre_menu, html_index)values(15,'Lista de Facturas','mnu_listafacturas');

insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(1,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(2,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(3,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(4,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(5,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(6,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(7,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(8,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(9,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(10,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(11,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(12,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(13,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(14,1);
insert into experton_expertonet.nomMenu_x_Rol(id_menu, id_rol)values(15,1);


