using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace TurretSound
{
    [BepInPlugin("com.sau6son.UwUTurretSound", "UwUTurret", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony _harmony;
        
        private static Plugin Instance;
        
        internal static AudioClip activateSound;
        internal static AudioClip deactivateSound;
        internal static AudioClip detectPlayerSound;
        internal static AudioClip firingSound;
        internal static AudioClip bulletHitWallSound;
        internal static AudioClip firingFarSound;

        void Awake()
        {
            if ((Object)(object)Instance == (Object)null)
            {
                Instance = this;
            }
            
            _harmony = new Harmony("com.sau6son.UwUTurretSound");
            _harmony.PatchAll();
            
            Logger.LogInfo("sau6son.UwUTurretSound is loading.");
            
            string location = ((BaseUnityPlugin)Instance).Info.Location;
            string text = "TurretSound.dll";
            string text2 = location.TrimEnd(text.ToCharArray());
            string text3 = text2 + "turretSound-bundle";
            AssetBundle val = AssetBundle.LoadFromFile(text3);
            if ((Object)(object)val == (Object)null)
            { 
                Logger.LogError((object)"Failed to load asset bundle!"); 
                return;
            }
            
            activateSound = val.LoadAsset<AudioClip>("assets/activate.mp3");
            deactivateSound = val.LoadAsset<AudioClip>("assets/deactivate.mp3");
            detectPlayerSound = val.LoadAsset<AudioClip>("assets/detectPlayer.mp3");
            firingSound = val.LoadAsset<AudioClip>("assets/firing.mp3");
            bulletHitWallSound = val.LoadAsset<AudioClip>("assets/bulletsHitWall.mp3");
            firingFarSound = val.LoadAsset<AudioClip>("assets/firingFar.mp3");
                
            if (activateSound == null || deactivateSound == null || detectPlayerSound == null || firingSound == null || bulletHitWallSound == null || firingFarSound == null)
            {
                Logger.LogError((object)"Failed to load one of the audio assets!");
                return;
            }
            _harmony.PatchAll(typeof(PatchClass));
            Logger.LogInfo((object) "UwUTurretSound plugin loaded !");
        }
    }    
}