# Voice Data Labeling System

This project is a desktop application created using C#
This program deals with audio data 
This project is currently being used in the research center of the University of Pécs

![Alt text](./screenshot.PNG?raw=true "Optional Title")

## Aim of the project

To have a system to support quick, easy, and user-friendly labelling of voice data.
In supervised machine learning projects, it is crucial to have a good database for training, validation
and test of the ML model.

## Feautures

- The application receives the root folder and show folder structure in a TreeView 
- Provide an option to select a source folder and start labelling in this selected folder
- List command types stored in a file
- List command (labels) of selected command type in alphabetic order
- On folder selection in in folder structure, list sample files in alphabetic order
- Play selected sample file (wav, mp3)
- Rename folder to selected command type
- Rename sample file to selected command
- Mark a sample as useless
- After confirmation, automatically select next command and next sample
- List of useless samples is written into a log file


