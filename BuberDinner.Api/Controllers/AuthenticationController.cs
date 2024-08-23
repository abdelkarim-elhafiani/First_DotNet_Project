using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;


[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
private readonly IAuthenticationQueryService _authenticationQueryService;
private readonly IAuthenticationCommandService _authenticationCommanService;

public AuthenticationController(IAuthenticationQueryService authenticationQueryService,IAuthenticationCommandService authenticationCommandService){
    _authenticationQueryService=authenticationQueryService;
    _authenticationCommanService=authenticationCommandService;

}
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest){
        var result=_authenticationCommanService.Register(registerRequest.FirstName,
        registerRequest.LastName,
        registerRequest.Email,
        registerRequest.Password);

        var  response =new AuthenticationResponse(
            result.id,
            result.firstName,
            result.lastName,
            result.email,
            result.token
    
        );
        return Ok(response);
        
    }
    [HttpPost("login")]

    public IActionResult  Login(LoginRequest request){
        var result=_authenticationQueryService.Login(request.Email,
        request.Password);

        var response=new AuthenticationResponse(
             result.id,
            result.firstName,
            result.lastName,
            result.email,
            result.token
            
        );
        return Ok(response);
    }

}

