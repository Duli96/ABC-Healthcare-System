## Healthcare Management System

This project is a healthcare management system built with C# and the .NET Framework using Service-Oriented Architecture (SOA). The system includes several core components such as:
- **Patient Service**: Handles patient registration, history, and profile management.
- **Medical Staff Management**: Manages information related to doctors, radiologists, and medical    staff.
- **Image Management**: Responsible for image uploads, classification, and retrieval.
- **Diagnosis and Report Generation**: Generates and stores diagnostic reports.
- **Financial Management**: Manages payments, billing, and transaction history.
- **User Authentication and Authorization**: Ensures role-based access control (RBAC) and secure     authentication.
- **Audit and Logging**: Tracks and logs user activity for compliance and auditing.

**1. Patient Sevice**
  
Patient Endpoints

| Method | URL                 | Description              |
|--------|---------------------|--------------------------|
| GET    | /api/patient        | Get all patients         |
| GET    | /api/patient/{id}   | Get a patient by ID      |
| POST   | /api/patient        | Create a new patient     |
| PUT    | /api/patient/{id}   | Update a patient by ID   |
| DELETE | /api/patient/{id}   | Delete a patient by ID   |
