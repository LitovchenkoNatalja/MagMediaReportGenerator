# MagMediaReportGenerator
This project provides functionality for the formation of either a file or an archive with specific data. The archive structure is as follows: <archive_name>.zip: <state_name_1>: <report_name_1>.txt, <report_name_2>.txt; <state_name_2>: <report_name_3>.txt.

The main file is MagMediaReportsService.cs. It defines and calls apropriate formation class: FileMagMediaReportsService.cs or ArchiveMagMediaReportsService.cs. 
In order to provide the possibility to reuse the archiving functionality, it was moved to a separate class Zipper.cs. 
Moreover, it implements a common interface and can be easily extended by another archiver in the future.  

In order to ensure the integrity of the program, many additional models, enums, and interfaces were created. Furthermore, UnityDependencyResolver.cs was created
in order to describe types' registrations.
