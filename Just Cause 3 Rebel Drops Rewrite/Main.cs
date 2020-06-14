using System;

using GTA;

namespace JustCauseRebelDrops
{
    public class Main : Script
    {
        internal static bool PlaySound = true;

        public Main()
        {
            Util.VerifyFileStructure();
            if (PlaySound) AudioManager.InitSounds();

            Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
               
        }
    }
}
