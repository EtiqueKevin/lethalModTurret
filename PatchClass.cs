using HarmonyLib;
using UnityEngine;

namespace TurretSound;

[HarmonyPatch(typeof(Turret))]
public class PatchClass
{
    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    public static void turretSoundPatch(ref AudioClip ___turretActivate, ref AudioClip ___turretDeactivate, ref AudioClip ___detectPlayerSFX, ref AudioClip ___firingSFX, ref AudioClip ___bulletsHitWallSFX, ref AudioClip ___firingFarSFX)
    {
        AudioClip newActivateSound = Plugin.activateSound;
        AudioClip newDeactivateSound = Plugin.deactivateSound;
        AudioClip newDetectPlayerSound = Plugin.detectPlayerSound;
        AudioClip newFiringSound = Plugin.firingSound;
        AudioClip newBulletHitWallSound = Plugin.bulletHitWallSound;
        AudioClip newFiringFarSound = Plugin.firingFarSound;
        
        ___turretActivate = newActivateSound;
        ___turretDeactivate = newDeactivateSound;
        ___detectPlayerSFX = newDetectPlayerSound;
        ___firingSFX = newFiringSound;
        ___bulletsHitWallSFX = newBulletHitWallSound;
        ___firingFarSFX = newFiringFarSound;
    }
} 