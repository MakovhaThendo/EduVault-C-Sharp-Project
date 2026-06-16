# EduVault

EduVault is a desktop-based student funding management system developed in C# using Windows Forms. It streamlines the end-to-end funding application lifecycle, from student onboarding and application submission to document handling and status tracking.

The system is designed with a structured workflow to ensure efficient capture of student data, secure document submission, and reliable tracking of funding applications.

---

## Key Capabilities

- Centralised student profile management (personal, academic, and contact details)
- Structured funding application workflow with configurable assistance categories
- Application tracking with reference generation and status visibility
- Secure document upload module for supporting files (ID, transcripts, proof of residence, income, motivation letter)
- Password reset and account recovery functionality

---

## Data & Database Integration

- SQL-based database for persistent storage of student profiles, applications, and status updates
- Relational data model linking students, applications, and uploaded documents
- Efficient data retrieval for profile loading and application tracking
- Structured queries for maintaining data consistency across modules

---

## Document Handling & Security

- File upload system for handling PDF and image-based supporting documents
- Server-side validation of file type and size constraints
- Secure file storage with controlled directory structure
- Prevention of invalid or unauthorised file execution through input validation
- Separation of file metadata (database) and physical file storage

---

## Architecture & Design

- Layered Windows Forms architecture (modular UI design)
- Event-driven programming model for user interactions
- Separation of concerns between UI, business logic, and data access layers
- Scalable structure for future backend integration

---

## Technology Stack

- C# (.NET Framework)
- Windows Forms (WinForms)
- Microsoft SQL Server
- Visual Studio IDE

---

## Project Objective

This project demonstrates practical implementation of full-stack desktop application principles, including database integration, secure file handling, and workflow-based system design. It simulates a real-world funding administration platform with emphasis on data integrity, security, and usability.

---

## Execution

1. Clone the repository  
2. Open the solution in Visual Studio  
3. Restore SQL database (if applicable)  
4. Update connection string in configuration file  
5. Build and run the application  
