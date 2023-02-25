using BepInEx;
using HarmonyLib;

namespace EnableDebugMenu
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class EnableDebugMenu : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony.CreateAndPatchAll(typeof(EnableDebugMenu));

        }

        [HarmonyPatch(typeof(UILeftBar), "Start")]
        [HarmonyPostfix]
        private static void UILeftBarStartPostfixPatch(ref LeftBarButton ____cheatCodesButton)
        {

            ____cheatCodesButton.gameObject.SetActive(value: true);
            ____cheatCodesButton.Button.onClick.AddListener(delegate
            {
                CheatManager.Instance.gameObject.SetActive(value: true);
            });

        }
    }
}
