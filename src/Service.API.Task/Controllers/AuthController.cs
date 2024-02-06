using Application.ViewModel;
using FluentValidation;
using Infra.CrossCutting;
using Microsoft.AspNetCore.Mvc;


namespace Service.API.Task.Controllers;

[ApiController]
[Route("api/Auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _Configuration;
    private IValidator<AuthViewModel> _validator;
    public AuthController(IConfiguration configuration, IValidator<AuthViewModel> validator)
    {
        _Configuration = configuration;
        _validator = validator;
    }

    [HttpPost]
    public async Task<APIResponse<string>> Post(AuthViewModel login)
    {
        var response = new APIResponse<string>();

        var valid = await _validator.ValidateAsync(login);

        if (valid.IsValid)
        {
            try
            {
                if (login.UserName!.Equals(_Configuration["User:UserName"]) && login.Password!.Equals(_Configuration["User:Password"]))
                {
                    using (var tokenService = new TokenService(_Configuration))
                    {
                        response.SetContent(200, tokenService.GenerateToken(login.UserName));

                        return response.Response();
                    }                     
                }

                response.AddInformation(400, "Usuário ou senha incorreta.");
            }
            catch (Exception ex)
            {
                response.AddInformation(500, ex.Message);
            }
        }
        else
        {
            valid.Errors.ForEach(x => response.AddInformation(400, x.ErrorMessage));
        }

        return response.Response();
    }
}