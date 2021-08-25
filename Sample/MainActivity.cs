using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Org.Mozilla.Geckoview;

namespace Sample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            var geckoView = new GeckoView(this);
            geckoView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            SetContentView(geckoView);

            var session = new GeckoSession();
            GeckoRuntime runtime = GeckoRuntime.Create(this, (GeckoRuntimeSettings)new GeckoRuntimeSettings.Builder().Build());
            session.Open(runtime);

            geckoView.Session = session;

            session.LoadUri("https://blog.ostebaronen.dk");
        }
    }
}