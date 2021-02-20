using WMPLib;

namespace Zmeika_C_sharp
{
    public class Sounds
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private string pathToMedia;

        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }

        public void Play()
        {
            player.URL = pathToMedia + "Background_Royalty_Free_Music.mp3";
            player.settings.volume = 5;
            player.controls.play();
            player.settings.setMode("loop", true);
        }

        public void PlayEat()
        {
            player.URL = pathToMedia + "nom_nom.mp3";
            player.settings.volume = 50;
            player.controls.play();
        }

        public void Pause()
        {
            player.URL = pathToMedia + "Background_Royalty_Free_Music.mp3";
            player.controls.stop();
        }

        public void GameEnd()
        {
            player.URL = pathToMedia + "death_sound_effect.mp3";
            player.settings.volume = 50;
            player.controls.play();
        }
    }
}