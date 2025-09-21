namespace LIN.Allo.App.Components.Pages.Sections;

public partial class CallSection
{
    /// <summary>
    /// Id de la llamada.
    /// </summary>
    [Parameter]
    public string RoomId { get; set; } = string.Empty;

    /// <summary>
    /// Cajon share.
    /// </summary>
    private DevicesDrawer? devicesDrawer;

    /// <summary>
    /// Estado del micrófono.
    /// </summary>
    bool MicroState { get; set; } = true;

    /// <summary>
    /// Estado de la cámara.
    /// </summary>
    bool CamState { get; set; } = true;

    /// <summary>
    /// Obtener o establecer si el dispositivo esta en una llamada.
    /// </summary>
    public static bool IsThisDeviceOnCall { get; set; } = false;

    /// <summary>
    /// Obtener o establecer si el dispositivo esta compartiendo pantalla.
    /// </summary>
    public bool IsSharingScreen { get; set; } = false;

    /// <summary>
    /// Validar si hay permisos de cámara y micrófono.
    /// </summary>
    public static async Task<bool> EnsurePermissionsAsync()
    {
        var cam = await Permissions.CheckStatusAsync<Permissions.Camera>();
        if (cam != PermissionStatus.Granted)
            cam = await Permissions.RequestAsync<Permissions.Camera>();

        var mic = await Permissions.CheckStatusAsync<Permissions.Microphone>();
        if (mic != PermissionStatus.Granted)
            mic = await Permissions.RequestAsync<Permissions.Microphone>();

        return cam == PermissionStatus.Granted && mic == PermissionStatus.Granted;
    }

    /// <summary>
    /// Después de renderizar.
    /// </summary>
    protected override async Task OnAfterRenderAsync(bool first)
    {
        await EnsurePermissionsAsync();

#if ANDROID
        Services.AudioSession.Begin();
#endif

        if (first)
        {
            await JSRuntime.InvokeVoidAsync("webrtc.init", "https://api.linplatform.com/Communication/hub/calls");
            await JSRuntime.InvokeVoidAsync("webrtc.join", int.Parse(RoomId), LIN.Access.Communication.Session.Instance.Token); // asegura que RoomId está seteado
        }
        IsThisDeviceOnCall = true;
    }

    /// <summary>
    /// Compartir / dejar de compartir pantalla.
    /// </summary>
    private async void ToggleShare()
    {
        if (IsSharingScreen)
        {
            await StopShare();
            return;
        }
        await ShareScreen();
    }

    /// <summary>
    /// Compartir pantalla.
    /// </summary>
    private async Task ShareScreen()
    {
        IsSharingScreen = await JSRuntime.InvokeAsync<bool>("webrtc.startScreenShare");
        StateHasChanged();
    }

    /// <summary>
    /// Dejar de compartir pantalla.
    /// </summary>
    private async Task StopShare()
    {
        IsSharingScreen = await JSRuntime.InvokeAsync<bool>("webrtc.stopScreenShare");
        StateHasChanged();
    }

    /// <summary>
    /// Activar / desactivar el microfono.
    /// </summary>
    private async Task ToggleMute()
    {
        var state = await JSRuntime.InvokeAsync<bool>("webrtc.toggleMute");
        MicroState = !state;
        StateHasChanged();
    }

    /// <summary>
    /// Activar / desactivar la camara.
    /// </summary>
    private async Task ToggleCamera()
    {
        var state = await JSRuntime.InvokeAsync<bool>("webrtc.toggleCamera");
        CamState = !state;
        StateHasChanged();
    }

    /// <summary>
    /// Colgar una llamada.
    /// </summary>
    private async void Hang()
    {
        await JSRuntime.InvokeVoidAsync("webrtc.hangup");
#if ANDROID
        LIN.Allo.App.Services.AudioSession.End();
#endif
        NavigationContext.NavigateTo("/home");
        IsThisDeviceOnCall = true;
    }

    /// <summary>
    /// Continuar en otro dispositivo.
    /// </summary>
    private void ContinueOn()
    {
        devicesDrawer?.Show();
    }
}