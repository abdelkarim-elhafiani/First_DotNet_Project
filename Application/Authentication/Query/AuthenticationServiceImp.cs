

using Application.Common.interfaces.Authentication;
using Application.Common.interfaces.Persistence;

public class AuthenticationQueryServiceImp : IAuthenticationQueryService


{

    private readonly IJwtGenerator _IjwtGenerator;
    private readonly IUserRepository _IuserRepository;

    public AuthenticationQueryServiceImp(IJwtGenerator jwtGenerator,IUserRepository userRepository){
        _IjwtGenerator=jwtGenerator;
        _IuserRepository=userRepository;
    }
    public AuthenticationResulte Login(string email, string password)
    {

        //Verify the email of the user
        if(_IuserRepository.GetUserByEmail(email) is not User user){
            throw new DuplicateEmailException();
        }
       // Verify the password 

       if(user.Password !=password){
        throw new Exception("This password is invalid");
       }
        // Create JWT 
        var jwt=_IjwtGenerator.JwtGenerator(user.Id,user.FirstName,user.LastName);
        var result=new AuthenticationResulte(
            user.Id,
            user.FirstName,
            user.LastName,
            email,
            jwt
            );
            return result;
    }

    
}