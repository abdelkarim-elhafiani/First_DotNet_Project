using Application.Common.interfaces.Persistence;
namespace BuberDinner.infrastructure.Persistence

{
    


public class userRepository : IUserRepository {

    public static List<User> Users= new();

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return Users.SingleOrDefault(u => u.Email.Equals(email));
    }
}
}
     