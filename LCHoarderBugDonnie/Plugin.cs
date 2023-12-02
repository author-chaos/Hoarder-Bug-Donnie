using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCHoarderBugDonnie.Patches;
using System.Threading;

namespace LCHoarderBugDonnie
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class HoarderBugDonnieBase : BaseUnityPlugin
    {
        private const string modGUID = "AuthorChaos.HoarderBugDonnie";
        private const string modName = "HoarderBugDonnie";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static HoarderBugDonnieBase Instance;

        internal ManualLogSource mls;

        internal static AudioClip[] newSFX;

        internal static string raw_file_name = "yaboogity";
        internal static string audio_file_name = "Assets/yaboogity";
        internal static string file_format = ".mp3";

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("!!! The test mod has awaken !!!");
            // Gets the file path to the DLL location.
            string dll_abs_path = Instance.Info.Location;
            mls.LogInfo(dll_abs_path);

            // The name of our generated DLL.
            string text = "LCHoarderBugDonnie.dll";
            // Gets the directory where our audio file lives.
            string audio_file_root_dir_abs_path = dll_abs_path.TrimEnd(text.ToCharArray());
            mls.LogInfo(audio_file_root_dir_abs_path);
            // Absolute path to the location of the audio file.
            string audio_file_abs_path = audio_file_root_dir_abs_path + raw_file_name;
            mls.LogInfo(audio_file_abs_path);

            AssetBundle audio_bundle = AssetBundle.LoadFromFile(audio_file_abs_path);
            mls.LogInfo(audio_bundle != null);
            mls.LogInfo(audio_bundle);

            // Log error and return if we fail to load our audio.
            if (audio_bundle == null)
            {
                mls.LogError("Failed to load audio asset: " + audio_file_name + file_format);
                return;
            }
            newSFX = audio_bundle.LoadAssetWithSubAssets<AudioClip>(audio_file_name + file_format);
            mls.LogInfo(newSFX);

            harmony.PatchAll(typeof(HoarderBugDonnieBase));
            mls.LogInfo(newSFX);

            harmony.PatchAll(typeof(HoarderBugSoundPatch));

            mls.LogInfo("!!! " + modName + " has loaded successfully !!! :-)");
        }

    }
}
