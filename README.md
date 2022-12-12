## Title Page
University: Universidad de Costa Rica<br>
Name of Document: "Proyecto Integrador de Ingeniería del Software y Bases de Datos"<br>
Name of System: Investiga UCR<br>
Version control:<br>
* Document: Version 0.0<br>
* System: Version 0.0<br>

## **Content Table**

[TOC]

## Definitions, Acronyms, and Abbreviations
* CITIC: Centro de Investigaciones en Tecnologías de la Información y Comunicación
* DDD: Domain Driven Design
*DoD: Definition of Done
* EPIC: a large user story, too big to fit into a sprint.
* Product Roadmap: a shared source of truth that outlines the vision, direction, priorities, and progress of a product over time.
* Product Vision: it describes the long-term mission of the product.
* Scrum: agile process framework used to manage product development.
* Scrum Master: a facilitator for using scrum on an agile development team. 
* Solid: an acronym that stands for five key software engineering principles.
* UCR: Universidad de Costa Rica
* UI: User Interface
* XP: Extreme Programming

## Introduction
The Centro de Investigaciones en Tecnologías de la Información y Comunicación (CITIC) from the Universidad de Costa Rica (UCR) has the objective of promoting the research in ICT realted areas.
This center colaborates directly with the Escuela de Ciencias de la Computación e Informática (ECCI) and the Progrado en Computación e Informática (PCI) to support research in Software Engineering, Computer Science, and Information Technologu.
The CITIC keeps up to 20 active research projects per year, that generate up to 25 anual publications of scientific papers.
More than 40 researchers conduct these projects, where teachers from the ECCI, collaborators from other academic units and universities; doctoral, academic masters, professional masters and bachelorship students take part.

With the consolidation of multiple research lines, and the formation and strengthening of diverse research groups, the CITIC whishes to  develop a web appliaation to manage the information of the scientific research groups and ease the scientific divulgation that it carries out, but to also make the projects visible to promote the participation of students from various levels and emphasis.
Currently, CITIC has more than 5 research groups in different areas, with
different researchers, external collaborators, students, scientific publications,
research projects, undergraduate and postgraduate theses, among others. All of this information needs to be
administered and disclosed to the university community, mainly the student community and to the different
national and international social, political and economic actors.

## Teams
### KISS
Maria Andres C00442 - Scrum Master & Git Coordinator

Francisco Mora C05118 - Documentation Coordinator

Gustavo Pinto C06009 - Team Ambassador & UI Coordinator

Andy Machado C00315 - Database Coordinator

### M.A.C. N. Cheese
José Fdo. Núñez B95616 - Database Coordinator

Andrey Mena C04740 - Documentation Coordinator

Sam Cheang B92211 - Scrum Master & Git Coordinator

Greivin Arce C00585 - Team Ambassador & UI Coordinator

### SOLIDios
Adrian Madrigal Azofeifa B94440 - Scrum Master & Documentation Coordinator

Jafet Picado Quirós C05977 - Team Ambassador & Base Project Coordinator

Keylor O. Soto Delgado B97725 - UI Coordinator

Marco Rodríguez Espinoza B96632 - Database Coordinator

### Hijos de Turing
Javier Donato Hidalgo B92650 - Team Ambassador & UI Coordinator

Alejandro Sánchez Fong B66590 - Scrum Master & Documentation Coordinator

Bayron Ramírez Jiménez C06334 - Git Coordinator

Bryan Villegas Alvarado B78383 - Database Coordinator

# General Description

## Context and Current Situation

The Center for Research on Information and Communications Technology (CITIC) apart from doing research is in charge of managing a website with all related information, such as projects, publications and personnel. However, said page has certain deficiencies in how it displays its information, from both visual and usability standpoints. Thus, an interest arises in improving what the CITIC’s page offers: making it more visually pleasing, making information easier to access, and displaying information in a better manner. Once complete, it’s also possible that the final product could be used by other research centers within the University of Costa Rica.

## Problem It Solves

CITIC researchers do not have a medium that makes it easier for them to carry out their scientific outreach work, this application comes to solve the following problems:

1. Researchers do not have a medium that facilitates the administration of their research groups.
2. Their investigations are generally not sufficiently visibilized.
3. Due to the lack of this visibility, it is not possible to attract greater participation of the students in the research projects.

## Users
The users of InvestigaUCR include CITIC administrators, Researchers (UCR's Faculty, UCR'S Students and External Collaborators) and visitors part of the scientific community and the general population.

## Proposed Solution
To solve the problems just described, the development team plans to give CITIC's webpage a significant tune-up in a way that it show a visible upgrade in it's design, not just visually but in how it's information is structured and administered as well.

With this upgrade, we expect to achieve a much bigger reach of people that could be interested in projects or investigations, a the same time giving investigators a way to manage their groups and projects in a much more efficient and simple way, by making better, more intuitive interfaces, not just for visitors, but administrative interfaces too.

## Context Analysis
### Business Strategy
One of the main pillars of the University of Costa Rica is research. Public perception affects how citizens view its use of funds and resources, which in turn can have implications in its activities. Along with that, the university currently places high in international rankings among other educational institutions worldwide, and continuously strives to climb higher. Hence, it’s important to the institution not just at a national level but also at an international one to spread information about the research done and about its researchers.

### System Objectives From the Business's Perspective
InvestigaUCR objective is to provide a reliable platform for the diffusion of information concearning to research projects, people, publications and research groups related to CITIC. To do so, an internet website is built in which a visitor can see the the desired information about the topics previously mentioned.

### Clients
There’s a wide array of clients that will be using the website, since it encompasses a large section of the university along with many potential users. These range from simple visitors to the site, interested in knowing more about the university’s activities, to people involved in research, to administrative and governmental entities.

### Intended Use
InvestigaUCR's intended use is to serve as a hub in which research work is hosted and through which it is published; ergo, promoting ICT work done by CITIC. In a political context,
InvestigaUCR aims to showcase the end product of the projects made possible by research funding.

### Related Legacy Systems
The CITIC website is the precursor of InvestigaUCR, the former doesn't have the category of "Research Groups" which the latter will; on top of that, InvestigaUCR will allow for the creation of user accounts and the display of statistics.

### Regulatory Aspects
As part of the UCR, the CITIC must follow it's according manual, called the Visual Identity Manual, relating to the website's look and feel. Ths regulates aspects like the correct use of the UCR's logo and the right palette of colors.

### Business Assumptions and Restrictions
As it is only the CITIC's website which we're working on, we must stay within it's range of information; meaning that only investigations from Technologies of Information and Communication should be shown, even if from other units within the UCR.
UCR's websites are commonly targeted by hackers, putting even more importance on the website's security and how we handle it's security and privacy.

### Other Existing Solutions
As previously mentioned, the CITIC website is the current existing solution. However, it has certain deficiencies which make InvestigaUCR a better, more promising solution.

## Product Vision
To constitute a tool of excellence at the service of the CITIC, aiding it in the promotion of ICT related research.<br>  
<img src="https://drive.google.com/uc?export=view&id=1jlglljcBUJ5EK87H75BI2Oj0ecfyDjxY">

## Relationship With Other External Systems
Much of the researches that will be published within the application is usually also published in other external scientific media, such as ResearchGate, Digital Bibliography & Library Project (DBLP), ESEC/FSE, among others. In some of these external systems you can also find the profiles of the researchers, as in the CITIC application, as well as the research groups to which they belong. On the other hand, regarding the style, the application is inspired in certain aspects by the page of the Stanford Machine Learning Group.

## Description of Topics (Modules) Assigned to Each Team
### KISS - Research Projects
For this sprint we worked on the module “Research Projects” which deals with the Research Projects published by CITIC. The EPIC prioritized was [Research Project Listing](http://10.1.4.22:8080/secure/RapidBoard.jspa?rapidView=74&projectKey=PIIB22II02&view=planning&selectedIssue=PIIB22II02-186&epics=visible&selectedEpic=PIIB22II02-6), for its completion we assumed both front-end and back-end tasks which included designing UI components, establishing a DDD architecture and setting up a Database.  All modules share the same database and deal with overlapping data. For the next sprints we anticipate greater interaction between modules, specially because they must redirect to each other.

### M.A.C. N. Cheese - People
In the 'People' module, a profile card for every person who contributes to a research is made, so a visitor can see some general information, such as a picture, their highest degree achieved, the name and last names, email, and the university each person is asociated.
To do so, the Epic [MC-PL-1 Show people cards in a research group](http://10.1.4.22:8080/secure/RapidBoard.jspa?rapidView=65&projectKey=PIIB22II02&view=planning.nodetail&epics=visible&selectedEpic=PIIB22II02-48) was created to tackle this objective.
In our work, we relate to 'Research Group' module.

### SOLIDios - Research Groups
The 'Research Groups' module is in charge of grouping research projects, publications, researchers, etc. It is related to the rest of the modules or themes precisely because it represents the grouping of everything mentioned above. In turn, a research group is dedicated to the generation of scientific knowledge in specific areas like empirical software and others.
The Epic [SD-RG-1 Show all research groups](http://10.1.4.22:8080/browse/PIIB22II02-1) takes care of the public displays of the groups such as their listing, as well as group information.

### Hijos de Turing - Publications
The 'Publications' module manages the website´s publications, as well as displaying them in a way that is most favorable to the product.
The Epic [HT-PB-1 Show all publications](http://10.1.4.22:8080/browse/PIIB22II02-23) was prioritized, as without it, there would be little to no visible progress from our module.
Our module is going to have to get involved with every other module at least for details, as every publication is gonna need the show the information pertinent to it, like its publisher or investigation group(s) involved.


## Functional Requirements
[KISS](http://10.1.4.22:8080/projects/PIIB22II02)

[M.A.C. N. Cheese](http://10.1.4.22:8080/secure/RapidBoard.jspa?rapidView=65&projectKey=PIIB22II02&view=planning.nodetail)

[SOLIDios](http://10.1.4.22:8080/secure/RapidBoard.jspa?projectKey=PIIB22II02&rapidView=68&view=planning)

[Hijos de Turing](http://10.1.4.22:8080/secure/RapidBoard.jspa?rapidView=66&projectKey=PIIB22II02&view=planning.nodetail)

## Product Roadmap
### KISS
<img src="https://drive.google.com/uc?export=view&id=1V0L59TkrTicUkxZnNpgF1wjEdNVgxOO2">

### M.A.C. N. Cheese
<img src="https://drive.google.com/uc?export=view&id=1R6_eQoUa97CwLltCp6LHNGl9ILz0ifUj">

### SOLIDios
<img src="https://drive.google.com/uc?export=view&id=1jZD82ibJkz2ih8_Jaq-UkyeJzN0sO38f">

### Hijos de Turing
<img src="https://drive.google.com/uc?export=view&id=1ggZW09cx4OyIhNG7u0xuiE0vD4hOEEO9">

## Non-functional Requirements
- Pages must cumply with the look and feel requirements of the website.
- The look and feel must cumply with the visual indentity of the University of Costa Rica. 
- All pages cannot take more than 2 seconds to load.
- No component should take up the space of any other component.
- Access to data modification can only be used by persons registered in the system with permissions.
- The public data must be protected against web crawlers.
- The pages must run at least on Google Chrome.
- The system must be developed using SOLID and Clean Architecture.

# Technical Decisions
## Methodologies Utilized and Defined Processes
Scrum & XP

## Artifacts Utilized During the Development of the Project
Product Backlog: Backlog which contains EPICS and stories for the project.

Sprint Backlog: Defines the stories to be developed during a sprint.

Product increment: Encompasses all the items completed during a sprint.

DoD: Criteria that needs to be met in order to consider a task complete.

## Technologies Utilized
Visual studio: 2022 Community
.NET: 6.0
Mud Blazor: 6.0.8
Bitbucket
Jira

## Code Repository and Git Strategy
[Repository](https://bitbucket.org/cristian_quesadalopez/ecci_ci0128_ii2022_g02_pi/src/main/)

[Git Strategy](https://bitbucket.org/cristian_quesadalopez/ecci_ci0128_ii2022_g02_pi/src/ReadMe/COMMIT_GUIDELINES.MD)
## Definition of Done, DoD
### To master
- Implement clean architecture.

- Design unit tests for main functionalities.

- All issues have been resolved.

- Comment explaining something in the code that is considered complicated

- Clean Code and Solid principles are followed.

- User Stories add value to the project.

- Established technical tasks have been completed.

- Beside unit tests, there must be integration and UI testing.

- Test projects need to be compilable and cover at least 80% of the code.

### To Sprint review

- It must have been seen by the P.O. The history must be validated by the P.O.

- Must be meeting acceptance criteria.

- To be in the master and updated in the backlog.

- Complies with interface design standards.

## Data requirements

### Research Projects
- All projects have a start date, an end date, a unique ID, a name, description, thesis and associated publications.

- All projects have a principal investigator person, and one person can be principal investigator in several projects.

- Projects can have collaborating people, and people can collaborate on one or more projects.

- Research projects belong to a group.

- A project can only be associated with one research group, but can have collaborators from different groups.

### People

- Each person requires a unique ID, their full name, composed by their first name, a second name and two last names, an email and their highest degree. Also they have a profile picture.

- Each person is enrolled in a career at a specific university. A person can be enrolled in multiple careers. It is desireed that the progress each person has with their career is saved.

- A career has a unique name, a level and a degree associated. They also can belong to only one university, each university can be identified by their names.

- Each person can have multiple roles in the research groups. Each role can be identified by their ID, and they have a name.

- Each person has only one user account with an email and password.

- Each user account has a role in the research groups. 

- A role can have multiple permissions. Each perimission has a role ID, a description and can be identified by an Id


### Research Groups

- The research center has a unique ID and a name. It must have a director and administrative staff.

- A group is part of a research center, but a center may have no group at all. A research group has a unique ID, unique name for that research center, a description, image and date of creation.

- In turn a group works in multiple research areas and a research area can be in several groups, an area has a unique ID, a name, description, associated keywords.

- The research group must have a coordinator and a coordinator person must be associated with the group.

- A research group consists of at least one person but people may have no groups associated.

- A research group has one coordinator and multiple researchers, but the coordinator can be a researcher at the same time

- A research group has multiple projects, theses and publications but they can only be developed by a single group.

### Publications
 
- Each publication has a unique DOI, a name, publication type, reference, publisher name, abstract, publication date and keywords, and are identified by their DOI.

- Each publication should store if the publication is visible to the visitors.

- The publication is made by a single research group.

- Each publication can be associated to multiple research projects.

- Each publication is authored by one or more persons.

### Theses
 
- Each thesis has a unique ID, a title, thesis type, description and publication date, and are identified by their ID.

- The thesis is developed by a single research group.

- Each thesis can be associated to a research project.

- Each thesis is authored by at least one or more persons.

### News

- Each news has a unique Id, a name, a publication date, a description, an author and image.

- Each news may have many keywords.

- A news is maked by a group.

- A news in visible for a visitor.

- A news should be manageable by an author.

- An author can be a coordinator or an administrator.


## Database Conceptual Design
<img src = "https://drive.google.com/uc?export=view&id=1sXALDiXhTfVtwWltEvzJDk3XWde9vKSv">

## Database Logical Design

<img src="https://drive.google.com/uc?export=view&id=1McBq6xgwoJ1CXYCqo4QUDTZc1r6PiOCm">

# References

- Cohn, Mike. Agile Estimating and Planning 1st edition, Prentice-Hall, ISBN 978-0131479418
- Cohn, Mike. User Stories Applied: For Agile Software Development 1st edition, AddisonWesley, ISBN 978-0321205681
- Dean Leffingwell. Agile Software Requirements. Agile Software Development Series. Alistair Cockburn and Jim Highsmith, series Editors.
