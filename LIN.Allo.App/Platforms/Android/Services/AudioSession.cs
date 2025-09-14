using Android.Content;
using Android.Media;

namespace LIN.Allo.App.Services
{

    public static class AudioSession
    {
        static AudioManager? am;
        static AudioFocusRequestClass? afr;

        public static void Begin()
        {
            var ctx = Android.App.Application.Context!;
            am = (AudioManager)ctx.GetSystemService(Context.AudioService)!;

            var attrs = new AudioAttributes.Builder()
                .SetUsage(AudioUsageKind.VoiceCommunication)
                .SetContentType(AudioContentType.Speech)
                .Build();

            afr = new AudioFocusRequestClass.Builder(AudioFocus.Gain)
                .SetAudioAttributes(attrs)
                .SetOnAudioFocusChangeListener(new FocusChange())
                .Build();

            try { am.RequestAudioFocus(afr); } catch { }

            // Modo comunicación (ayuda a WebRTC)
            try { am.Mode = Mode.InCommunication; } catch { }

            // === Ruteo a altavoz ===
            try
            {
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.S)
                {
                    // Android 12+: usa SetCommunicationDevice
                    var devices = am.AvailableCommunicationDevices;
                    var speaker = devices?.FirstOrDefault(d => d.Type == AudioDeviceType.BuiltinSpeaker);
                    if (speaker != null) am.SetCommunicationDevice(speaker);
                }
                else
                {
                    // Legacy: usa la propiedad SpeakerphoneOn
                    am.SpeakerphoneOn = true;
                }
            }
            catch { /* opcional: log */ }
        }

        public static void End()
        {
            try { if (afr != null) am?.AbandonAudioFocusRequest(afr); } catch { }
            try { if (am != null) { am.Mode = Mode.Normal; /* opcional: am.SpeakerphoneOn = false; */ } } catch { }
        }

        class FocusChange : Java.Lang.Object, AudioManager.IOnAudioFocusChangeListener
        { public void OnAudioFocusChange([Android.Runtime.GeneratedEnum] AudioFocus focusChange) { } }
    }
}
