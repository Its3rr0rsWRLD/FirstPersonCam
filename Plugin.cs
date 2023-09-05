using BepInEx;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilla;

namespace FirstPersonCam
{
    // Constants for easier maintenance
    public static class TextContent
    {
        public const string BottomText = "IF YOU WOULD LIKE TO SEE MORE JUST PING ME IN discord.gg/monkemod WITH THE MOD IDEA";
        public const string TopText = "Thanks for using my mod!";
    }

    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private GameObject obj;

        // Called when the mod is enabled
        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        // Called when the mod is disabled
        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
            Utilla.Events.GameInitialized -= OnGameInitialized;
        }

        // Called when the game is initialized
        void OnGameInitialized(object sender, EventArgs e)
        {
            UpdateText("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text", TextContent.BottomText);
            UpdateText("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct", TextContent.TopText);
            obj = GameObject.Find("Player Objects/Third Person Camera");
            obj.SetActive(false);
        }

        // Helper method to update text
        private void UpdateText(string path, string newText)
        {
            GameObject.Find(path).GetComponent<Text>().text = newText;
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            // Activate your mod here
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            // Deactivate your mod here
        }
    }
}
