# DeviantartApi Library in C# (netstandard 1.1) 

Library for using [Deviantart API](https://www.deviantart.com/developers/http/v1/20160316) from .NET.

### Acquiring

#### nuget
[![NuGet](https://img.shields.io/badge/nuget.Core-2.0.2-brightgreen.svg?maxAge=2592000?style=flat-square)](https://www.nuget.org/packages/DeviantartApi/)

#### git
later

### Usage

If you use platform with implemented login process:

```cs

void RefreshTokenUpdated(string newRefreshToken)
{
	if(SavedToken != newRefreshToken)
		SaveToken(newRefreshToken, DateTime.Now.AddMonths(3));
}
...
// There is no valid RefreshToken
var result = await DeviantartApiLogin.Platform.Login.SignInAsync(ClientId, Secret, CallbackUrl, RefreshTokenUpdated, 
												   new[]
												   {
														DeviantartApi.Login.Scope.Browse,
														DeviantartApi.Login.Scope.User,
														DeviantartApi.Login.Scope.Feed
												   }));
if(result.IsLoginError) 
{
	ShowError(result.LoginErrorText);
	return;
}

SaveToken(result.RefreshToken, DateTime.Now.AddMonths(3));
return;
...
// You have valid RefreshToken
DeviantartApiLogin.Platform.Login.AttachLogin(); //So TokenChecker know what must be called if refreshtoken invalid
var result = await DeviantartApi.Login.SetAccessTokenByRefreshAsync(ClientId, Secret, CallbackUrl, RefreshToken, RefreshTokenUpdated, new[]
												   {
														DeviantartApi.Login.Scope.Browse,
														DeviantartApi.Login.Scope.User,
														DeviantartApi.Login.Scope.Feed
												   });
if(result.IsLoginError) 
{
	ShowError(result.LoginErrorText);
	return;
}
SaveToken(result.RefreshToken, DateTime.Now.AddMonths(3));
return;

```

Otherwise:

```cs

void RefreshTokenUpdated(string newRefreshToken)
{
	if(SavedToken != newRefreshToken)
		SaveToken(newRefreshToken, DateTime.Now.AddMonths(3));
}
...
// There is no valid RefreshToken
DeviantartApi.Login.CustomSignInAsync = MySignInAsync;
var result = await DeviantartApi.Login.SignInAsync(ClientId, Secret, CallbackUrl, RefreshTokenUpdated, 
												   new[]
												   {
														DeviantartApi.Login.Scope.Browse,
														DeviantartApi.Login.Scope.User,
														DeviantartApi.Login.Scope.Feed
												   }));
if(result.IsLoginError) 
{
	ShowError(result.LoginErrorText);
	return;
}

SaveToken(result.RefreshToken, DateTime.Now.AddMonths(3));
return;
...
// You have valid RefreshToken
DeviantartApi.Login.CustomSignInAsync = MySignInAsync; //So TokenChecker know what must be called if refreshtoken invalid
var result = await DeviantartApi.Login.SetAccessTokenByRefreshAsync(ClientId, Secret, CallbackUrl, RefreshToken, RefreshTokenUpdated, new[]
												   {
														DeviantartApi.Login.Scope.Browse,
														DeviantartApi.Login.Scope.User,
														DeviantartApi.Login.Scope.Feed
												   });
if(result.IsLoginError) 
{
	ShowError(result.LoginErrorText);
	return;
}
SaveToken(result.RefreshToken, DateTime.Now.AddMonths(3));
return;


```

Requests example

```cs

var result = await new DeviantartApi.Requests.User.WhoAmIRequest().ExecuteAsync();
if (result.IsError)
{
    ShowError(result.ErrorText);
    return;
}
UserName = result.Object.Username;
UserAvatarUri = new Uri(result.Object.UserIcon);

//or 
var Feed = new HomeRequest();
Feed.LoadMature = true;
var result = await Feed.GetNextPageAsync();
if(result.IsError)
{
	ShowError(result.ErrorText);
	return;
}
//use data
...
//get next page

result = await Feed.GetNextPageAsync();

//start from beginning
Feed.Cursor = "";

result = await Feed.GetNextPageAsync();
```
