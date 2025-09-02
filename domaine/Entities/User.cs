public class User{
    public Guid Id =Guid.NewGuid();
    public string FirstName{get;set;}=null!;
    //this is a great code
    public string LastName { get; set; } = null!;
    public string Email{get;set;}=null!;
    //this is not a good code
    public string Password { get; set; } = null!;
}