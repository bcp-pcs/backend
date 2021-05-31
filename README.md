# Case Study

## Table of Contents
- [Case Study](#case-study)
  - [Table of Contents](#table-of-contents)
  - [To run the project](#to-run-the-project)
  - [Admin API](#admin-api)
  - [User Services API](#user-services-api)

## To run the project
dotnet run -o Api

## Admin API
CRUD functions for mantain data, however **security check is not implemented** at the moment.

Api | Remark
--- | --- 
Applicants | Applicants CRUD
Mortgages | Mortgages CRUD

## User Services API
Api | Remark
--- | ---
AuthManagement | Register, login and display user profile (jwt base)
SearchServie | Search service, both jwt version and Id version
