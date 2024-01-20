namespace API.Controllers {
    // A _Data Transfer Object_ is used to consistently transfer data between different pieces of software with differing interfaces
    // It is represented as a class that exclusively contains fields; since it is only used for transferring data, no logic/methods are needed.
    public class LoginDTO {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}