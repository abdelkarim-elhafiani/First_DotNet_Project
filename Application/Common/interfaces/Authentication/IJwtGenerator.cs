namespace Application.Common.interfaces.Authentication;

public interface IJwtGenerator {
    string JwtGenerator(Guid id,string FirstName,string LastName);
}