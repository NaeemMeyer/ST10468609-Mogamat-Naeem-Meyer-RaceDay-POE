# ST10468609-Mogamat-Naeem-Meyer-RaceDay-POE

## Section B – API Endpoint Plan

**Authentication**
| Method | Route | Description | Role | Body | Response |
|--------|-------|-------------|------|------|----------|
| POST | /api/auth/register | Register new user. | Public | { name, email, password, role } | 201 Created; 400 Bad Request; 409 Conflict |
| POST | /api/auth/login | Authenticate user. | Public | { email, password } | 200 OK; 401 Unauthorized |

**User Profile**
| Method | Route | Description | Role | Body | Response |
|--------|-------|-------------|------|------|----------|
| GET | /api/users/me | Get current user profile. | Authenticated | None | 200 OK; 401 Unauthorized; 404 Not Found |
| PUT | /api/users/me | Update current user profile. | Authenticated | { fullName, contactNumber } | 200 OK; 400 Bad Request |





