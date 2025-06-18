WinForms Ticket Management System - CRUD Practice
This document is designed for beginners to practice CRUD operations in a WinForms ticket management system. Through this project, learners will understand UI design, event handling, database connections, and CRUD operations.
1. Learning Objectives
• Familiarize with basic UI controls in WinForms
• Understand event handling and data retrieval from controls
• Be able to read and write to SQLite databases
• Perform basic CRUD operations (Create, Read, Update, Delete)
• Use DataGridView to display and edit data
2. Functional Requirements
This project is a 'Ticket Management System' with the following required functionalities:
• Create Ticket: Input title, description, owner, and status
• Read Tickets: Display all tickets in a table
• Update Ticket: Select a row to modify and update the ticket
• Delete Ticket: Select a row and delete the ticket
3. Database Table Design (SQL)
Table name: Tickets. Additionally, a log file is created to record operations by trigger related to the Tickets table.
Column Name	Description
Id	Identity, auto-increment
Title	Ticket title, Primary key
Description	Ticket description
Owner	Owner
Status	Status (Pending/In Progress/Completed)

4. Suggested UI Component Layout
Please add the following components to Form1:
Component	Name	Purpose
TextBox	txtTitle, txtDescription, txtOwner	Ticket input fields 
ComboBox	cmbStatus	Status dropdown menu
Buttons	btnAdd, btnUpdate, btnDelete, btnRefresh	CRUD operations
DataGridView	dgvTickets	Display all tickets
5. Extended Tasks
• Add a creation timestamp column to automatically record the creation time
• Add query functionality to filter tickets by status
• Design a multi-form layout, separating create/edit screens into independent windows
