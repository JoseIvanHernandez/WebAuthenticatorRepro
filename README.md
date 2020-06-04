# WebAuthenticatorRepro

On Android, when `Xamarin.Essentials.WebAuthenticator.AuthenticateAsync` returns from a successful authentication, it always throws `WebAuthenticator.AuthenticateAsync`:
**Note:** This `Exception` does not happen on iOS

```bash
[mono-rt] [ERROR] FATAL UNHANDLED EXCEPTION: System.Threading.Tasks.TaskCanceledException: A task was canceled.
[mono-rt]   at (wrapper dynamic-method) Android.Runtime.DynamicMethodNameCounter.1(intptr,intptr)
[mono-rt]   at (wrapper native-to-managed) Android.Runtime.DynamicMethodNameCounter.1(intptr,intptr)
```

## Reproduciton Steps

1. Download/Clone this repo
2. In Visual Studio, open `WebAuthenticatorRepro.sln`
3. In Visual Studio, set the startup project to WebAuthenticator.Android
4. In Visual Studio, build/deploy WebAuthenticator.Android to an Android Device/Emulator 
5. On the Android device, click `Connect to GitHub`
6. On the Android device, connect using your GitHub username/password
7. Confirm WebAuthenticator.Android crashes with `System.Threading.Tasks.TaskCanceledException`

![](https://user-images.githubusercontent.com/13558917/83807342-c7abf880-a667-11ea-9ac5-962abb6ef05d.gif)
