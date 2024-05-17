namespace WebAPI.Endpoints
{
    public static class AuthEndpoints
    {
        public static void ConfigureAuthEndPoints(this WebApplication app)
        {
            app.MapPost("/api/login", async (IAuthRepository authRepo, [FromBody] LoginRequestDTO model) =>
            {
                var loginResponse = await authRepo.Login(model);
                if (loginResponse == null)
                {
                    return Results.BadRequest();
                }

                return Results.Created("/api/login", loginResponse);
                
            }).WithName("Login").Produces<LoginResponseDTO>(201).Produces(400);

            app.MapPost("/api/register", async (IAuthRepository authRepo, [FromBody] RegistrationRequestDTO model) =>
            {
                bool isUnique = authRepo.IsUniqueUser(model.Username);
                if (!isUnique)
                {
                    return Results.BadRequest();
                }

                var registerResponse = await authRepo.Register(model);
                if (registerResponse == null)
                {
                    return Results.BadRequest();
                }

                return Results.Created("/api/register", registerResponse);

            }).WithName("Register").Produces(201).Produces(400);
        }
    }
}
