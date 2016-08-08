#\[VS2015+\] DeviantartApi Library in C# for UWP, Win8.1, WinPhone8.1, .NET 4.5+, ASP.NET Core 1.0

Library for using [Deviantart API](https://www.deviantart.com/developers/http/v1/20160316) from .NET.

###Implemented requests
If you need something just leave issue or pull request. Or you can easily implement new request in your code.

####Browse
* GET /browse/categorytree
* GET /browse/dailydeviations
* GET /browse/hot
* GET /browse/morelikethis
* GET /browse/morelikethis/preview
* GET /browse/newest
* GET /browse/popular
* GET /browse/tags
* GET /browse/tags/search

####Deviation
* GET /deviation/\{deviationid\}
* GET /deviation/metadata

####Feed
* GET /feed/home

####User 
* GET /user/whoami

####Util\[Full\]

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

####nuget
[![NuGet](https://img.shields.io/badge/nuget .WINRT-0.1.0-brightgreen.svg?maxAge=2592000?style=flat-square)](https://www.nuget.org/packages/DeviantartApi.WinRT/)
[![NuGet](https://img.shields.io/badge/nuget .NET-0.1.0-brightgreen.svg?maxAge=2592000?style=flat-square)](https://www.nuget.org/packages/DeviantartApi.NET/)

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
