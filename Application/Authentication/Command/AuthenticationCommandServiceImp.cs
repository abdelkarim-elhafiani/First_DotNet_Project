

using Application.Common.interfaces.Authentication;
using Application.Common.interfaces.Persistence;

public class AuthenticationCommandServiceImp : IAuthenticationCommandService


{

    private readonly IJwtGenerator _IjwtGenerator;
    private readonly IUserRepository _IuserRepository;

    public AuthenticationCommandServiceImp(IJwtGenerator jwtGenerator,IUserRepository userRepository){
        _IjwtGenerator=jwtGenerator;
        _IuserRepository=userRepository;
    }
    

    public AuthenticationResulte Register(string firstName, string lastName, string email, string password)
    {
        //Verify that the user doesn't exist 
        if(_IuserRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
        }

        //Create the user 
        var user = new User{
            FirstName=firstName,
            LastName=lastName,
            Email=email,
            Password=password};

            _IuserRepository.AddUser(user);

        //Generate the jwt 
        var jwt=_IjwtGenerator.JwtGenerator(Guid.NewGuid(),firstName,lastName);
        
    var result=new AuthenticationResulte(
            Guid.NewGuid() ,
            firstName,
            lastName,
            email,
            jwt
            );
            return result;
    }
}