using BlogBlazor.Store.AuthUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlogBlazor.Shared.Component.Common;

public partial class Header
{
    [Inject]
    private IState<AuthState> AuthState { get; set; }

    public string Username => AuthState.Value.Username;
}
