using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VolcanoidsSDK;

namespace TutorialMod
{
    class TutorialMod : GameMod
    {
        public SDK volcSDK;
        public override void Load()
        {
            var version = typeof(TutorialMod).Assembly.GetName().Version;
            var lastWrite = File.GetLastWriteTime(typeof(TutorialMod).Assembly.Location);
            Debug.Log($"TutorialMod Loaded: {version}, Build Time: {lastWrite.ToShortTimeString()}");

            volcSDK = new SDK("TutorialMod", GUID.Parse("abcdefg123456"));

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
                    Functions volcFunctions = new Functions(volcSDK);
                    break;
            }
        }

        public override void Unload()
        {
        }
    }
}
