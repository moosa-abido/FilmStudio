# REST
The access points are devided into 3 Api controllers which are:
1. ``FilmsController``: this controller manages the films operations such as creating, fetching, and modifying films, the involved endpoints are:
    * PUT /api/films: Add new film
    * GET /api/films: get all the films
    * PUT /PATCH/POST /api/films/{id}: modify a specific film identified by its id
    * GET /api/films/{id}: get a specific film identified by its id
    * POST /api/films/rent/?id={id}&studioId={studioId} rent a film copy of the film identified by its id for the film studio identified by its studioId
    * POST /api/films/return/?id={id}&studioId={studioId} return a film copy of the film identified by its id rented by the film studio identified by its studioId

2. ``FilmStudiosController``: this controller handle film studio registering and fetching available film studios, and rented films by specific film studio, the involved endpoints are:
    * POST /api/filmstudios/register: register a new film studio
    * GET /api/filmstudios: get all film studios
    * GET /api/filmstudios/{id}: get a film studio identified by its film studio id
    * GET /api/mystudio/rentals: get all the rented film copies by the film studio

3. ``UsersController``: this api controller handle user registering and authentication of both admin and film studio users, there are two endpoints:
    * POST /api/users/register: register a new admin user
    * POST /api/users/authenticate: authenticate a user (admin/film studio user)

c
# Implementation
The web API involves multiple internal ressources that are not accessed by the web API but by other similar ressources such as DTOs(Data transfer objects) to ensure security, we can mention the following classes:

1. The IUser Interface and the implemented User class: the User is not accessed directly, but using multiple other classes, like UserAuthenticate that transfer the username and password from the client to the web API, and the RegisterUser class to register a new user.
2. IFilmStudio and FilmStudio: To register a class you have to send a json object which parses to C# object that satisfies the IRegisterFilmStudio interface, so you cannot access the FilmStudio objects directly.

The visible ressources provide less accessbility than the internal ressources because of security issues.


# Security
The endpoints security is implemented using Token authentication that invloves sending the token in the http header under the Authorization Key value pair in the following format ``Bearer <your-token>``

1. ``Restricted Access``: The access to some endpoints is restricted due to security concerns, some endpoints like ``GET /api/filmstudios``, when an autheticated user is detected the api will return the city and the rented film copies also, but if an anonymous user is detected the api will return only the name and id of the film studio. This is achieved using the ``IUser GetCurrentUser()`` method under ``FilmsController`` and ``FilmStudiosController``, it uses ``HttpContext.User.Identity`` to get the authenticated user that request that ressource, and fetch its information from the database to ensure its authentication.

2. ``Login and logout in the client interface``: The client interface send the user crendentials over POST request body, and then if the user is authenticated, the api will send the user info including the token, this info is stored in the localStorage of the browser to ensure that it is not lost if the user refresh the page, and also stored in a ``Pinia`` vue js store to ensure accessibility over any ``vue js component``, where token can be retrived and used to send authenticated requests to the web api. The ``Logout funcrtionality`` when the Logout button is pressed, it deletes the user info from localStorage and clears the ``Pinia`` store's state which is the user record.