using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using VolcanoidsSDK;

namespace TutorialMod.lib
{
    class TutorialItems
    {
        public static void InitItems(Functions volcFuncts) {
            volcFuncts.CreateItem("CobaltIngot", 99, "Cobalt Ingot", "A Cobalt Ingot", "069306E234D4499C9F5A3526D0E5C4D3", "TitaniumIngot", "Resources/Ingots/CobaltIngot.png");
        }
    }
}
