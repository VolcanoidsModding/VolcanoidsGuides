using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TutorialMod.Guides.GettingStarted
{
    public class TutorialMod : GameMod
    {
        public override void Load()
        {
            var version   = GetType().Assembly.GetName().Version;
            var lastWrite = File.GetLastWriteTime(GetType().Assembly.Location);
            Debug.Log($"{GetType()} Loaded: {version}, Build Time: {lastWrite.ToShortTimeString()}");

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            switch (scene.name)
            {
                case "MainMenu":
                    GameObject.Find("EarlyAccess").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "TutorialMod";
                    break;
                case "Island":
                    break;
            }
        }
    }
}
