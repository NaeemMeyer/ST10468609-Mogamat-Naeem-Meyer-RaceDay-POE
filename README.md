# ST10468609-Mogamat-Naeem-Meyer-RaceDay-POE

SECTION A

Organiser (OrganiserID PK, Name, ContactInfo, Email [Unique], PasswordHash)

Participant (ParticipantID PK, Name, Surname, DOB, Gender, Email [Unique], PasswordHash)
Event (EventID PK, Title, Date, Location, OrganiserID FK)
Category (CategoryID PK, EventID FK, Name, Distance, AgeLimit)
Enrolment (EnrolmentID PK, ParticipantID FK, EventID FK, CategoryID FK, EnrolmentDate, Status [Default: Pending])
Result (ResultID PK, EnrolmentID FK, FinishTime, Position, WeatherInfo, RouteInfo)

Relationships:

Organiser → Event (1‑to‑many)
Event → Category (1‑to‑many)
Participant → Enrolment (1‑to‑many)
Enrolment → Result (1‑to‑1)
Participant ↔ Event (many‑to‑many via Enrolment)

[Download the PDF Document](file:///C:\Users\Naeem Meyer\Downloads)

# Section B – API Endpoint Plan

## 1. Authentication
| HTTP Method | Route | Description | Role Required | Request Body | Expected Response |
|-------------|-------|-------------|---------------|--------------|------------------|
| POST | /api/auth/register | Registers a new RaceDay user (Organiser or Participant). | Public | { fullName, email, password, role, profileDetails } | 201 Created; 400 Bad Request; 409 Conflict |
| POST | /api/auth/login | Authenticates a user and returns role info + token. | Public | { email, password } | 200 OK; 401 Unauthorized |

## 2. User Profile
| HTTP Method | Route | Description | Role Required | Request Body | Expected Response |
|-------------|-------|-------------|---------------|--------------|------------------|
| GET | /api/users/me | Returns the profile of the authenticated user. | Any authenticated user | None | 200 OK; 401 Unauthorized; 404 Not Found |
| PUT | /api/users/me | Updates editable details for the authenticated user. | Any authenticated user | { fullName, contactNumber?, emergencyContact? } | 200 OK; 400 Bad Request; 401 Unauthorized |

## 3. Events
| HTTP Method | Route | Description | Role Required | Request Body | Expected Response |
|-------------|-------|-------------|---------------|--------------|------------------|
| GET | /api/events | Returns all RaceDay events. | Public | None | 200 OK |
| GET | /api/events/{id} | Returns details of a specific event. | Public | None | 200 OK; 404 Not Found |
| POST | /api/events | Creates a new event owned by the Organiser. | Organiser | { eventName, description, eventDate, location, distanceKm, eventType, maxParticipants } | 201 Created; 400 Bad Request; 401 Unauthorized; 403 Forbidden |
| PUT | /api/events/{id} | Updates an existing event. | Organiser | { eventName, description, eventDate, location, distanceKm, eventType, maxParticipants, status } | 200 OK; 400 Bad Request; 401 Unauthorized; 403 Forbidden; 404 Not Found |
| DELETE | /api/events/{id} | Deletes an event when allowed. | Organiser | None | 204 No Content; 403 Forbidden; 404 Not Found; 409 Conflict |

## 4. Categories
| HTTP Method | Route | Description | Role Required | Request Body | Expected Response |
|-------------|-------|-------------|---------------|--------------|------------------|
| GET | /api/events/{eventId}/categories | Returns all categories for an event. | Public | None | 200 OK; 404 Not Found |
| POST | /api/events/{eventId}/categories | Creates a category for an event. | Organiser | { categoryName, minAge, maxAge, fee } | 201 Created; 400 Bad Request; 401 Unauthorized; 403 Forbidden |
| PUT | /api/events/{eventId}/categories/{categoryId} | Updates a category. | Organiser | { categoryName, minAge, maxAge, fee } | 200 OK; 400 Bad Request; 401 Unauthorized; 403 Forbidden; 404 Not Found |
| DELETE | /api/events/{eventId}/categories/{categoryId} | Deletes a category if no enrolments exist. | Organiser | None | 204 No Content; 403 Forbidden; 404 Not Found; 409 Conflict |

## 5. Event Enrolments
| HTTP Method | Route | Description | Role Required | Request Body | Expected Response |
|-------------|-------|-------------|---------------|--------------|------------------|
| POST | /api/events/{eventId}/enrol | Enrols a participant in an event category. | Participant | { categoryId } | 201 Created; 400 Bad Request; 401 Unauthorized; 409 Conflict |
| GET | /api/enrolments/me | Returns all enrolments for the participant. | Participant | None | 200 OK; 401 Unauthorized; 404 Not Found |
| GET | /api/events/{eventId}/enrolments | Returns all enrolments for an organiser’s event. | Organiser | None | 200 OK; 401 Unauthorized; 403 Forbidden |

## 6. Results
| HTTP Method | Route | Description | Role Required | Request Body | Expected Response |
|-------------|-------|-------------|---------------|--------------|------------------|
| POST | /api/results | Captures a participant’s result. | Organiser | { enrolmentId, finishTime, position, weatherInfo?, routeInfo? } | 201 Created; 400 Bad Request; 401 Unauthorized; 403 Forbidden |
| GET | /api/results/{eventId} | Returns results for an event. | Public | None | 200 OK; 404 Not Found |






