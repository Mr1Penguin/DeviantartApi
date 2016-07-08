#\[VS2015+\] DeviantartApi Library in C# for UWP, Win8.1, WinPhone8.1, .NET 4.5+, ASP.NET Core 1.0

Library for using Deviantart API from .NET.

After sometime a publish this to nuget

###Acquiring
####git
Add library as submodule to use it in your project

```
git submodule add https://github.com/Mr1Penguin/DeviantartApi.git
```

And add shared part and WinRT/.NET part to your project

If you got an error about newtonsoft.json elements just type this in packet manager console for .NET project:
```
Update-Package -Reinstall -Project DeviantartApi.NET
```


And/Or for WinRT:
```
Update-Package -Reinstall -Project DeviantartApi.WinRT
```

Looks like target application must have json.net reference if Api project and target project not on the same folder level.
####nuget
Later

###Usage

```cs

void RefreshTokenUpdated(string newRefreshToken)
{
	if(SavedToken != newRefreshToken)
		SaveToken(newRefreshToken, DateTime.Now.AddMonths(3));
}
...
// There is no valid RefreshToken
// for .NET version you must set Login.CustomSignInAsync with your implementation. This delegate would be called if refresh token became broken. 
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

...

//someRequests

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
