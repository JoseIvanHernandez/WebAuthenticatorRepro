using Xamarin.Forms;

namespace WebAuthenticatorRepro
{
    public class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Markup_Experimental" });
            MainPage = new LoginPage();
        }
    }
}
