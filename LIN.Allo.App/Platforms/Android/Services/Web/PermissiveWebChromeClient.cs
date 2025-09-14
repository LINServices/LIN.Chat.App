using Android.OS;
using Android.Webkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIN.Allo.App.Platforms.Android.Services.Web
{
    public class PermissiveWebChromeClient : WebChromeClient
    {
        public override void OnPermissionRequest(PermissionRequest? request)
        {
            if (request is null) return;

            // Log: ¿se pidió AUDIO/VIDEO y desde qué origen?
            try
            {
                var res = string.Join(",", request.GetResources() ?? Array.Empty<string>());
            }
            catch { }

            // Concede inmediatamente en UI thread (sin awaits aquí)
            MainThread.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                        request.Grant(request.GetResources());
                    else
                        base.OnPermissionRequest(request);
                }
                catch { }
            });
        }

    }
}
