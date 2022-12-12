# Commit and Branch Guidelines

This document provides a guide of how to commit and branch following the standarization agreed upon by the group earlier this semester. Please follow these guidelines so that the repository keeps clean and organized.

## User Story custom IDs
All user stories must be named with a custom ID. The ID should include group, module, epic number and a short name.

 Group acronyms:
- SOLIDios -> SD
- Hijos de Turing -> HT
- M.A.C and Cheese -> MC
- KISS -> KS

Module acronyms:
- General -> GR
- Research Groups -> RG
- People -> PL
- Research Projects -> RP
- Publications -> PB
- Research Areas -> RA
- Theses -> TS
- Reseach Center -> RC
- Statistics -> ST

Epics should be numbered within modules, and US should be numbered within epics.

Examples:
- SD-RG-1.5 Show the name and description of groups in a list of groups
- KS-RP-4.2 List of publications that are associated with a project.


## Commits

All commits should follow the following standard or a variation of it:
```
ID: <JIRA US ID>, US: <Custom US ID>, TT: <Name of subtask associated 
to commit>. <Commit body. What was done?>. Devs: <Name of driver>, <name 
of navigator>
```

## Branches

When creating new branches use the following structure:
```
├── main
│   └── Group branch
│       └── Feature name
│   └── Base branch
│       └── Feature name
```
Examples:
- KISS-RPLists
- SOLID
- Database-RGTables
