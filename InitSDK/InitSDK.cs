using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VolcanoidsSDK;

namespace TutorialMod.Guides.InitSDK
{
    class InitSDK : GameMod
    {
        public SDK volcSDK;
        public override void Load()
        {
            var version = typeof(InitSDK).Assembly.GetName().Version;
            var lastWrite = File.GetLastWriteTime(typeof(InitSDK).Assembly.Location);
            Debug.Log($"TutorialMod Loaded: {version}, Build Time: {lastWrite.ToShortTimeString()}");

            volcSDK = new SDK("InitSDK", GUID.Parse("abcdefg123456"));

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            switch (scene.name)
            {
                case "MainMenu":
                    GameObject.Find("EarlyAccess").gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "TutorialMod";
                    Functions volcFunctions = new Functions(volcSDK);
                    break;
                case "Island":
                    break;
            }
        }

        public override void Unload()
        {
        }
    }
}
