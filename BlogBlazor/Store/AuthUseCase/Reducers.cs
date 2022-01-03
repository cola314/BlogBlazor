using BlogBlazor.Services;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlogBlazor.Store.AuthUseCase;

public static class Reducers
{
    [ReducerMethod]
    public static AuthState ReduceRegisterAction(AuthState state, RegisterAction.Request action)
        => new AuthState(
            username: null, 
            isLoading: true, 
            errorMessage: null);

    [ReducerMethod]
    public static AuthState ReduceRegisterAction(AuthState state, RegisterAction.Success action)
        => new AuthState(
            username: action.Username,
            isLoading: false,
            errorMessage: null);

    [ReducerMethod]
    public static AuthState ReduceRegisterAction(AuthState state, RegisterAction.Fail action)
        => new AuthState(
            username: null,
            isLoading: false,
            errorMessage: action.ErrorMessage);

    [ReducerMethod]
    public static AuthState ReduceLoginAction(AuthState state, LoginAction.Request action)
        => new AuthState(
            username: null,
            isLoading: true,
            errorMessage: null);

    [ReducerMethod]
    public static AuthState ReduceLoginAction(AuthState state, LoginAction.Success action)
        => new AuthState(
            username: action.Username,
            isLoading: true,
            errorMessage: null);

    [ReducerMethod]
    public static AuthState ReduceLoginAction(AuthState state, LoginAction.Fail action)
        => new AuthState(
            username: null,
            isLoading: true,
            errorMessage: action.ErrorMessage);
}
