# Case Study Backend

## Table of Contents
- [Case Study Backend](#case-study-backend)
  - [Table of Contents](#table-of-contents)
  - [To run the project](#to-run-the-project)
  - [Case Study Note](#case-study-note)
  - [Admin API](#admin-api)
  - [User Services API](#user-services-api)

## To run the project
dotnet run -o Api

## Case Study Note
Case study `API 1` implemented at `POST http://localhost:5000/api/Applicants`, case study `API 2` implemented at `GET http://localhost:5000/api/Search/MortgagesById` with query parameter as `?id={long}&proprtyPrice={float}&deposit={float}`

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
SearchServie | Search service, both `jwt` version and `case study` version
