# ST10468609-Mogamat-Naeem-Meyer-RaceDay-POE

## Section B – API Endpoint Plan

### 1. Authentication Endpoints
| HTTP | Route | Description | Role | Body | Response |
|------|-------|-------------|------|------|----------|
| POST | /api/auth/register | Register new user. | Public | { name, email, password, role } | 201 Created; 400 Bad Request; 409 Conflict |
| POST | /api/auth/login | Login existing user. | Public | { email, password } | 200 OK; 401 Unauthorized |

### 2. User Profile Endpoints
| HTTP | Route | Description | Role | Body | Response |
|------|-------|-------------|------|------|----------|
| GET | /api/users/me | Get profile of logged‑in user. | Authenticated | None | 200 OK; 401 Unauthorized; 404 Not Found |
| PUT | /api/users/me | Update profile details. | Authenticated | { fullName, contactNumber } | 200 OK; 400 Bad Request |




