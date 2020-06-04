using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace WebAuthenticatorRepro
{
    public class LoginPage : ContentPage
    {
        readonly Label _resultLabel;
        readonly ActivityIndicator _activityIndicator;

        public LoginPage()
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Button { Text = "Connect To GitHub" }.Center().Invoke(button => button.Clicked += HandleLoginButtonClicked),
                    new Label().Assign(out _resultLabel).TextCenter(),
                    new ActivityIndicator { IsVisible = false }
                        .Assign(out _activityIndicator).Center()
                }
            }.Center();
        }

        async void HandleLoginButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            button.IsEnabled = false;
            _activityIndicator.IsVisible = _activityIndicator.IsRunning = true;

            try
            {
                _resultLabel.Text = "Authenticating With GitHub";

                var authResult = await WebAuthenticator.AuthenticateAsync(new Uri("https://github.com/login/oauth/authorize?client_id=9b010a6d0dfb3354fdb5&scope=public_repo%20read:user"), new Uri(OAuthConstants.CallbackUrl));

                if (string.IsNullOrWhiteSpace(authResult.Properties["code"]))
                    _resultLabel.Text = "Unable to Connect";
                else
                    _resultLabel.Text = "Success!";
            }
            finally
            {
                _activityIndicator.IsVisible = _activityIndicator.IsRunning = false;
                button.IsEnabled = true;
            }
        }
    }
}
