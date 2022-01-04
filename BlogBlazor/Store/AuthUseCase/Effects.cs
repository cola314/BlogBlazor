using BlogBlazor.Services;
using Fluxor;

namespace BlogBlazor.Store.AuthUseCase;

public class Effects
{
    private readonly UserService _userService;

    public Effects(UserService userService)
    {
        _userService = userService;
    }

    [EffectMethod]
    public async Task HandleRegisterAction(RegisterAction.Request action, IDispatcher dispatcher)
    {
        try
        {
            await _userService.AddUser(action.Username, action.Password);
            dispatcher.Dispatch(new RegisterAction.Success() { Username = action.Username });
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new RegisterAction.Fail() { ErrorMessage = ex.Message });
        }
    }

    [EffectMethod]
    public async Task HandleLoginAction(LoginAction.Request action, IDispatcher dispatcher)
    {
        try
        {
            if (await _userService.ExistUser(action.Username, action.Password))
            {
                dispatcher.Dispatch(new RegisterAction.Success() { Username = action.Username });
            }
            else
            {
                dispatcher.Dispatch(new RegisterAction.Fail() 
                { 
                    ErrorMessage = "로그인 실패" 
                });
            }
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new RegisterAction.Fail() { ErrorMessage = ex.Message });
        }
    }
}
