using NAudio.Wave;

namespace JustCauseRebelDrops
{
    internal class AudioManager
    {
        static Mp3FileReader callRead = new Mp3FileReader(Globals.CallSound);
        static Mp3FileReader hitRead = new Mp3FileReader(Globals.HitSound);
        static WaveOut callOut = new WaveOut();
        static WaveOut hitOut = new WaveOut();

        /// <summary>
        /// Initializes the mod's sounds
        /// </summary>
        public static void InitSounds()
        {
            callOut.Init(callRead);
            hitOut.Init(hitRead);
        }

        /// <summary>
        /// Plays a given sound effect
        /// </summary>
        /// <param name="sound">The drop sound to play</param>
        public static void PlaySound(DropSound sound)
        {
            switch (sound)
            {
                case DropSound.call:
                    callOut.Play();
                    break;
                case DropSound.hit:
                    hitOut.Play();
                    break;
            }
        }

        /// <summary>
        /// Stops a given sound effect
        /// </summary>
        /// <param name="sound">The drop sound to stop</param>
        public static void StopSound(DropSound sound)
        {
            switch (sound)
            {
                case DropSound.call:
                    callOut.Stop();
                    callRead.Seek(0, System.IO.SeekOrigin.Begin);
                    break;
                case DropSound.hit:
                    hitOut.Stop();
                    hitRead.Seek(0, System.IO.SeekOrigin.Begin);
                    break;
            }
        }
    }

    internal enum DropSound
    {
        call, hit
    }
}
