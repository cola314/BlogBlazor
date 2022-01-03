using Fluxor;

namespace BlogBlazor.Store.AuthUseCase;

[FeatureState]
public class AuthState
{
    public string Username { get; init; }
    public bool IsLoading { get; init; }
    public string ErrorMessage { get; init; }

    private AuthState() { }

    public AuthState(string? username, bool isLoading, string? errorMessage)
    {
        Username = username ?? "";
        IsLoading = isLoading;
        ErrorMessage = errorMessage ?? "";
    }
}