using Android.App;
using Android.OS;
using LibVLCSharp.Shared;
using VideoView = LibVLCSharp.Platforms.Android.VideoView;

namespace HikConnect
{
    [Activity(Label = "HikConnect", MainLauncher = true)]
    public class Main : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Core.Initialize();
            var _libVLC = new LibVLC();
            var _mediaPlayer = new MediaPlayer(_libVLC);
            var _videoView = FindViewById<VideoView>(Resource.Id.videoView1);
            _videoView.MediaPlayer = _mediaPlayer;
            var mediaUri = Android.Net.Uri.Parse("rtsp://admin:soporte21@190.117.54.230:554/ISAPI/Streaming/channels/101");
            var m = new Media(_libVLC, mediaUri.ToString(), FromType.FromPath);
            var configuration = new MediaConfiguration();
            configuration.EnableHardwareDecoding = true;

            //m.AddOption(":fullscreen");
            m.AddOption(":codec=avcodec");
            m.AddOption(configuration);
            m.AddOption(":file-caching=1500");
            _mediaPlayer.Media = m;
            _videoView.MediaPlayer.Play(m);
        }
    }
}