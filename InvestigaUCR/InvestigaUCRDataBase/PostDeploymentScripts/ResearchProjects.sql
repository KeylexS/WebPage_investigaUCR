/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO ResearchProject AS Target 
USING (VALUES 
('723-B9-343', 'Intervenciones en infancia temprana para reducir la desigualdad en las oportunidades educativas',
'',
0, '2019/1/1', '2021/1/1', 0),
('834-B8-A27', 
'Evaluación empírica de la metodología aFPA para la automatización de la medición del tamaño funcional del software', 
'Este proyecto tiene como objetivo evaluar empíricamente la metodología para la automatización de la medición del tamaño funcional del software (aFPA). En particular, la metodología de medición aFPA, propuesta como parte de la tesis de doctorado de Cristian Quesada López, se compone de tres procedimientos: medición automática de tamaño funcional, verificación automática de la exactitud de las mediciones de tamaño funcional y evaluación comparativa de modelos de estimación para el aprovechamiento de los resultados de la medición de tamaño funcional.
Este proyecto incluye la evaluación de los tres procedimientos y las herramientas prototipo de soporte. Los métodos empíricos de evaluación que se usaran son los de la ingeniería de software empírica incluyendo casos de estudio y cuasi-experimentos.
Durante las evaluaciones empíricas realizadas en la tesis de Cristian Quesada López se obtuvieron resultados prometedores y se determinaron oportunidades de mejora.
Se requiere realizar nuevas investigaciones empíricas y mejorar los prototipos de la metodología aFPA. Asimismo, se requieren nuevos casos de estudio, incluyendo la evaluación de aplicaciones reales de la industria. El proyecto realiza nuevos estudios empíricos de una de las líneas de investigación del Grupo de Investigación de Ingeniería de Software Empírica de la ECCI y se deriva de algunos de los trabajos futuros de la Tesis de Doctorado de Cristian Quesada López.
Asimismo, incluye los trabajos futuros mencionados en los TFIAs de maestría de Denisse Madrigal y Luis Carlos Salas que fueron colaboradores del Grupo de Investigación y participaron en algunas de las investigaciones realizadas en la tesis de doctorado mencionada anteriormente. Este proyecto desarrollará experticia en el tema de medición de tamaño funcional, estimación del esfuerzo del software y metodologías de la ingeniería de software empírica. El conocimiento generado será socializado mediante artículos científicos y puede ser aprovechado para los cursos y electivas relacionados con la Ingeniería de software en la ECCI y los cursos de métricas, medición, estimación, ingeniería de software empírica en el PCI. Finalmente, con el proyecto de investigación buscamos incidir en la industria de software nacional generando evidencia sobre la implementación de algunas de estas metodologías.',
0, '2018/3/1', '2021/12/31', 0),
('834-B7-749',
'Evaluación de herramientas automatizadas para pruebas de software basadas en modelos',
'Este proyecto tiene como objetivo caracterizar y evaluar herramientas automatizadas de pruebas de software basadas en modelos. Las metodologías que se usarán son tomadas de la ingeniería de software empírica, en particular, se hará una revisión sistemática de literatura, un cuasi-experimento y un caso de estudio.
Primeramente, se hará una caracterización de las principales herramientas de automatización de pruebas de software basadas en modelos mediante una revisión sistemática de literatura. En segundo lugar, se hará una comparación empírica del desempeño de tres herramientas de automatización de pruebas de software basadas en modelos, mediante un cuasi-experimento. En tercer lugar, se realizará un caso de estudio de la aplicación de una de
estas herramientas en una organización de software.
Este proyecto desarrollará experticia en el tema de pruebas automatizadas basadas en modelos e ingeniería de software empírica, que podrá ser usada en la ECCI y el PCI para generar TFIAS, tesis, futuros proyectos de investigación relacionados y colaboraciones con otras universidades estatales y extranjeras que trabajan en estos temas. Finalmente, mediante este proyecto podremos incidir en la industria de software nacional, con el fin de generar evidencia sobre la implementación de algunas de estas técnicas y herramientas que les sean de utilidad.',
0, '2017/3/1', '2020/2/28', 0),
('834-B5-A18', 
'Medición automatizada del tamaño funcional de aplicaciones transaccionales',
'',
0, '2015/8/1', '2017/7/31', 0),
('834-C1-011', 'Procedimiento automatizado de medición de contribuciones a partir de repositorios de proyectos de desarrollo de software',
'La medición de las contribuciones de los(as) desarrolladores(as) durante el desarrollo de un proyecto puede ayudar en la planificación, monitoreo y seguimiento del proyecto, la identificación de riesgos, la administración de la calidad, la coordinación de los equipos, el reconocimiento de miembros de equipo clave por su experticia y compromiso, la retroalimentación constante para la modificación de comportamientos, el incremento en la productividad y la toma de decisiones de negocio informadas.
Los procesos de ingeniería de software contemplan múltiples actividades para desarrollar, mantener, y operar software. Los procesos de software entrelazan actividades técnicas, colaborativas, y de gestión tales como la especificación de requerimientos, diseño, desarrollo, validación y verificación, calidad y riesgos, versionamiento, planificación y estimación. Los(as) desarrolladores(as) participan y contribuyen en múltiples actividades durante el desarrollo de software conforme este evoluciona. No obstante, la definición de métricas objetivas, justas y exactas para las contribuciones individuales es un problema retador y recolectar las mediciones considerando las múltiples actividades de ingeniería de software es una tarea compleja. Asimismo, estas medidas no sólo deben recolectarse en las distintas etapas del desarrollo sino también considerar la perspectiva de los distintos interesados del proyecto.
Este proyecto de investigación desarrolla un procedimiento automatizado de medición de contribuciones a partir de repositorios de proyectos de desarrollo de software. Para esto caracteriza los procesos de recolección de métricas de contribuciones, diseña e implementa el procedimiento de medición y evalúa su efectividad para medir automáticamente las contribuciones de los desarrolladores durante el desarrollo de un proyecto de software.
Este proyecto es parte del trabajo de tesis de maestría académica de Sivana Hamer.',
0, '2020/3/1', '2022/2/28', 0)
) 
AS Source ([ID], [Name], [Description], [GroupID], [Start_date], [End_date], [PersonalIdentification]) 
ON Target.[ID] = Source.[ID] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([ID], [Name], [Description], [GroupID], [Start_date], [End_date], [PersonalIdentification]) 
VALUES ([ID], [Name], [Description], [GroupID], [Start_date], [End_date], [PersonalIdentification]);