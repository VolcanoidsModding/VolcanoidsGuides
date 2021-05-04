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
        //public Functions volcFunctions; If you want it globally uncomment this line.
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
                    break;
                case "Island":
                    Functions volcFunctions = new Functions(volcSDK); //If you want it globally comment out this line.
                    //volcFunctions = new Functions(volcSDK); If you want it globally uncomment this line.
                    break;
            }
        }

        public override void Unload()
        {
        }
    }
}
