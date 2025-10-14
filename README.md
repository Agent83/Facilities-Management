This project is a full-stack web application designed using .NET Core 6 for the back-end and Angular 11 for the front-end. The system manages tasks, contractors, and premises for a facilities management platform, providing tools for users to efficiently track, update, and manage tasks and related entities.

## Migrating the Front-End to Vue 3

If you plan to replace the Angular client with Vue 3, follow the migration playbook outlined in [`docs/MIGRATING_TO_VUE3.md`](docs/MIGRATING_TO_VUE3.md). The guide covers auditing the current Angular modules, bootstrapping a Vue 3 + Vite project, translating routing, services, guards, and forms, and updating the .NET build pipeline to serve the new front-end. A starter Vue 3 application created with Vite now lives in [`client-vue/`](client-vue/) to accelerate the migration work.

Back-End (Facilities Management API using .NET Core 6):

Controllers: Handles HTTP requests and interacts with services to manage contractors, premises, and tasks.
DTOs (Data Transfer Objects): Facilitates clean, secure data transfer between the front-end and back-end.
Data: Manages database contexts and migrations, connecting to a PostgreSQL database.
Entities: Defines domain models (e.g., Premises, Contractors, Tasks), mapped to PostgreSQL tables.
Enums: Defines enumerations to manage predefined value sets in the database.
Errors: Handles error logging and routing, providing feedback for smoother user experiences.
Middleware: Implements custom middleware for routing and error handling.
Services: Contains the core business logic for managing user roles, task sorting, and other functionalities.
Program.cs: Configures middleware and services, integrating the PostgreSQL database.
Front-End (Angular 11):

Routing: Managed by app-routing.module.ts, handling navigation between different views, such as task lists, contractor management, and premises.
Components:
app.component: The root component handling the general structure and layout of the application.
members, premiseTasks, premises, propAccountant, register: These components handle the various functionalities and interfaces for managing members, tasks, premises, accountants, and registration processes.
modal/roles-modal: Contains modal functionality for role-based actions, allowing for flexible user management.
notes: Manages the notes associated with tasks or contractors, allowing users to add, edit, and delete notes.
Assets: Contains static resources such as images and styles.
Environments: Contains configuration files (environments.ts) for different application environments (e.g., production and development).# Facilities-Management
