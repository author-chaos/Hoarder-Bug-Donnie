using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LCHoarderBugDonnie.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class HoarderBugSoundPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void hoarderBugSoundPatch(ref AudioClip[] ___chitterSFX)
        {
            AudioClip[] newSFX = HoarderBugDonnieBase.newSFX;
            ___chitterSFX = newSFX;
        }
    }
}
