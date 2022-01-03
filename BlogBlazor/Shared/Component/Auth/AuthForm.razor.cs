using BlogBlazor.Store.AuthUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlogBlazor.Shared.Component.Auth;

public enum AuthFormType
{
    Login,
    Register,
}

public partial class AuthForm : IDisposable
{
    [Parameter]
    public AuthFormType Type { get; set; }

    private string Text => Type switch
    {
        AuthFormType.Login => "로그인",
        AuthFormType.Register => "회원가입",
    };

    private string Username { get; set; }
    private string Password { get; set; }
    private string PasswordConfirm { get; set; }
    private string ErrorMessage { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    [Inject]
    private IState<AuthState> AuthState { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    protected override void OnInitialized()
    {
        AuthState.StateChanged += AuthState_StateChanged;
    }

    private void AuthState_StateChanged(object? sender, AuthState e)
    {
        if (!string.IsNullOrEmpty(e.ErrorMessage))
        {
            ErrorMessage = e.ErrorMessage;
        }
        if (!string.IsNullOrEmpty(e.Username))
        {
            NavigationManager.NavigateTo("/");
        }
    }

    public void Dispose()
    {
        AuthState.StateChanged -= AuthState_StateChanged;
    }

    public void OnSubmit()
    {
        if (Type == AuthFormType.Login)
        {
            Dispatcher.Dispatch(new LoginAction.Request()
            {
                UserName = Username,
                Password = Password,
            });
        }
        else
        {
            if (string.IsNullOrWhiteSpace(Username) || 
                string.IsNullOrWhiteSpace(Password) || 
                string.IsNullOrWhiteSpace(PasswordConfirm))
            {
                ErrorMessage = "빈 칸을 모두 입력하세요.";
            }
            else if (Password != PasswordConfirm)
            {
                ErrorMessage = "비밀번호가 일치하지 않습니다";
                Password = "";
                PasswordConfirm = "";
            }
            else
            {
                Dispatcher.Dispatch(new RegisterAction.Request()
                {
                    UserName = Username,
                    Password = Password,
                });
            }
        }
    }
}
