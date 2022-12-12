/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--User Story: SD-RG-1.5 & TT: PIIB22II02-453 Fix database postdeplyment
MERGE INTO [ResearchCenter] AS TARGET
USING (VALUES
	    (1, 'CITIC')
)
AS Source([Id], [Name])
ON TARGET.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id], [Name]) 
VALUES ([Id], [Name]);

MERGE INTO [Group] AS Target 
USING (VALUES 
	  ('CRCUCRCITICESE','Grupo de investigación en ingeniería de software empírica', 1, 
	  'La Ingeniería de Software Experimental es la parte de la Ingeniería de Software que se enfoca en reunir evidencia, 
	  a través de mediciones y experimentos que involucran sistemas de software (productos de software, procesos y recursos).
	  Esta información está destinada a ser utilizada como la base de teorías sobre los procesos involucrados en la 
	  Ingeniería de Software (la teoría respaldada por datos es un principio fundamental del método científico). 
	  Varios grupos de investigación usan principalmente técnicas empíricas y experimentales. 
	  La Ingeniería de Software Empírica es un concepto relacionado, y a veces utilizado como sinónimo de la Ingeniería de 
	  Software Experimental. La Ingeniería de Software Empírica enfatiza el uso de estudios empíricos de todo tipo 
	  para acumular conocimiento. Los métodos utilizados incluyen experimentos, estudios de casos, encuestas y el 
	  uso de los datos disponibles.', null),
	  ('CRCUCRCITICHCI','Grupo de investigación en Interacción Humano Computador', 1, 
	  'La interacción humano-computador (HCI) es el estudio y diseño planificado de actividades humanas y de computadora.
	  HCI utiliza la productividad, la seguridad y el entretenimiento para apoyar y cumplir con las actividades de la 
	  computadora humana y se aplica a varios tipos de sistemas informáticos, incluidos el control del tráfico aéreo, 
	  el procesamiento nuclear, las oficinas y los juegos de computadora. Los sistemas HCI son fáciles, seguros, efectivos 
	  y agradables. La ingeniería de software se enfoca en la producción de soluciones de aplicaciones de software, 
	  mientras que HCI se enfoca en descubrir métodos y técnicas que apoyen a las personas.
	  Los diseñadores de HCI siempre consideran los objetivos de usabilidad y experiencia de usuario de HCI para una 
	  interacción efectiva del usuario. No todos los objetivos de usabilidad y experiencia de usuario se aplican a todos 
	  los sistemas informáticos interactivos porque ciertas combinaciones son incompatibles. Los diseñadores de HCI 
	  también consideran posibles contextos, tareas a mano y usuarios de sistemas informáticos.',null),
	  ('CRCUCRCITICSAP','Grupo de investigación en seguridad y privacidad', 1,
	  'La seguridad del software es el concepto de implementar mecanismos en la construcción de la seguridad para 
	  ayudarla a permanecer funcional (o resistente) a los ataques. Esto significa que una pieza de software se 
	  somete a pruebas de seguridad antes de salir al mercado para comprobar su capacidad para resistir ataques maliciosos.
	  La idea detrás de la seguridad del software es crear software que sea seguro desde el principio sin tener que agregar 
	  elementos de seguridad adicionales para agregar capas adicionales de seguridad (aunque en muchos casos, esto todavía 
	  sucede).',null),
	  ('CRCUCRCITICIA','Grupo de investigación en Inteligencia Artificial', 1, 'La inteligencia artificial (IA) es una de las ramas de la Informática, 
	  con fuertes raíces en otras áreas como la lógica y las ciencias cognitivas. Como veremos a continuación, existen muchas definiciones de lo que 
	  es la inteligencia artificial. Sin embargo, todas ellas coinciden en la necesidad de validar el trabajo mediante programas.',null),
	  ('CRCUCRCITICGP','Grupo de investigación en Computación Gráfica',1,'La computación gráfica o gráficos por ordenador es el campo de la informática visual, donde se utilizan computadoras 
	  tanto para generar imágenes visuales sintéticamente como integrar o cambiar la información visual y espacial probada del mundo real. 
	  La visualización constituye un área de investigación y desarrollo, en la cual comprende una gran cantidad de técnicas heterogéneas, ésta 
	  última se origina producto de la diversidad de necesidades del usuario, dominios de aplicación y conjuntos de datos.', null)
) 
AS Source ([Id], [Name], [ResearchCenterId], [Description], [Start_Date]) 
ON Target.[Id] = Source.[Id] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Id], [Name], [ResearchCenterId], [Description], [Start_Date]) 
VALUES ([Id], [Name], [ResearchCenterId], [Description], [Start_Date]);

MERGE INTO ResearchProject AS Target 
USING (VALUES 
('723-B9-343', 'Intervenciones en infancia temprana para reducir la desigualdad en las oportunidades educativas',
NULL,
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
NULL,
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

MERGE INTO News AS Target
USING (VALUES
('CITIC-1', NULL,'CITIC RECIBIÓ LA VISITA DEL PROFESOR JOÃO VIDAL CARVALHO DEL POLITÉCNICO DE PORTO, PORTUGAL',
'El Profesor Carvalho es miembro del Centro de Investigación CEOS.PP, un centro de investigación multidisciplinar en el área de las ciencias sociales, con publicaciones y proyectos en diversos campos, concretamente en Sistemas de Información, Gestión, Economía y Comunicación, siempre con un enfoque muy especial en los servicios digitales.

Kuten tiedät, peliautomaattien tuotto perustuu prosenttiosuuteen. Sertifioitujen peliautomaattien keskimääräinen palautusprosentti on 96-97 %. Backlash ilmainen kaikille pelaajille. varmasti pysyvät epätasainen käyttäjille, jotka eivät voita. Miten määritetään, milloin pelata? Ensimmäinen asia, jota on analysoitava, on nettikasino https://suomikasinot365.com/ ja sen keskittyminen maihin. Jos laitos hyväksyy enemmän pelaajia toisesta aikavyöhykkeen maasta. On parempi aloittaa peli illalla tai päivällä kyseisessä maassa.
El pasado 23 de setiembre el CITIC recibió la visita del Profesor João Vidal Carvalho del Politécnico de Porto, Portugal.

CEOS.PP lleva a cabo investigaciones de alta calidad en los campos del Emprendimiento, la Innovación, el Marketing, las Comunicaciones, los Recursos Humanos, la Economía Social, los Sistemas de Información y Tecnología, así como en el Análisis Corporativo, Social y Educativo.', NULL , '09/29/2022'
),
('ESE-1', 'CRCUCRCITICESE', 'DR. MARCELO JENKINS PARTICIPÓ EN EL V CONGRESO INTERNACIONAL EN INTELIGENCIA AMBIENTAL, INGENIERÍA DE SOFTWARE Y SALUD EELCTRÓNICA Y MÓVIL (AMITIC 2022)',
'El Dr. Marcelo Jenkins impartió la charla magistral "Innovación en Tics y la oportunidad para CR en desarrollo de software" en el V Congreso Internacional en Inteligencia Ambiental, Ingeniería de Software y Salud Electrónica y móvil-AmITIC 2022, celebrado del 15 al 17 de setiembre de 2022.',
NULL, '09/27/2022'
),
('SAP-1','CRCUCRCITICSAP', 'ENTREVISTA SOBRE EL PROYECTO "DISEÑO AUTOMÁTICO DE HIPERPARÁMETROS EN REDES NEURONALES ARTIFICIALES"', 'Este proyecto de investigación del Centro de Investigación en Tecnologías de Información y Comunicación (CITIC)  y de la Escuela de Ciencias de la Computación e Informática (ECCI) del Universidad de Costa Rica (UCR), busca crear un algoritmo que utilizando la inteligencia artificial, el aprendizaje automático y la computación evolutiva, permita crear una herramienta que ayude a los médicos a mejorar y precisar el diagnóstico temprano del Alzheimer.

Enlace de la entrevista: https://www.youtube.com/watch?v=bCUQOEe5TwA&t=226s', NULL, '03/09/2022'
),
('HCI-1','CRCUCRCITICHCI','INVESTIGADOR DEL CITIC PARTICIPÓ EN EL IV CONGRESO INTERNACIONAL EN INTELIGENCIA AMBIENTAL, INGENIERÍA DE SOFTWARE Y SALUD ELECTRÓNICA Y MÓVIL (AMITIC 2021)',
'El investigador Dr. Gustavo López Herrera participó en el IV Congreso Internacional en Inteligencia Ambiental, Ingeniería de Software y Salud Electrónica y Móvil (AmITIC 2021), la cual se llevó a cabo virtualmente del 13 al 14 de octubre, por medio de la plataforma Youtube. El Dr. López impartió la charla magistral "UX Evaluation with Standardized Questionnaires in Ubiquitous Computing and Ambient Intelligence".

AmITIC es una red temática en las áreas de Inteligencia Ambiental, Tecnologías de la Información y Comunicación, que permite a estudiantes, docentes e investigadores tomar contacto con expertos de las áreas citadas.', NULL, '10/27/2011'
)
)
AS Source ([Id], [GroupId], [Title], [Description], [Author], [PublicationDate])
ON Target.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id], [GroupId], [Title], [Description], [Author], [PublicationDate])
VALUES ([Id], [GroupId], [Title], [Description], [Author], [PublicationDate]);