using Android.App;

namespace LIN.LifecycleEvent;


internal class Events
{


    public static void OnStart(Activity activity)
    {
        if (Session.IsLocalOpen)
            AppShell.Hub.ReconnectAndUpdate();

    }



    public static void OnStop(Activity activity)
    {
        try
        {
            if (AppShell.Hub != null)
                _ = AppShell.Hub.CloseSesion();
        }
        catch
        {
        }
    }


}
