namespace BlogBlazor.Store.AuthUseCase;

public class RegisterAction
{
    public class Request
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }

    public class Success
    {
        public string Username { get; init; }
    }

    public class Fail
    {
        public string ErrorMessage { get; init; }
    }
}

public class LoginAction
{
    public class Request
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }

    public class Success
    { 
        public string Username { get; init; }
    }

    public class Fail 
    {
        public string ErrorMessage { get; init; }
    }
}