using System.Collections;
using UnityEngine;
using KSP.UI.Screens;

namespace OptionalAtmopsheres2
{
    namespace UI
    {
        class AppLauncherController : MonoBehaviour
        {
            AtmosphereController OAToggler = new AtmosphereController();
            public void ApplauncherOA()
            {
                bool OAButton = true;
                if (KSP.UI.Screens.ApplicationLauncher.Ready && OAButton == true)
                {
                   

                    
                    Texture2D OATex = GameDatabase.Instance.GetTexture("OptionalAtmospheresReavamped/Icons/OAR.png", false);
                    KSP.UI.Screens.ApplicationLauncher.Instance.AddModApplication(
                            onTrue: AtmosphereController.AtmosphereToggler,
                            onFalse: null,
                            onHover: null,
                            onHoverOut: null,
                            onEnable: null,
                            onDisable: null,
                            visibleInScenes: KSP.UI.Screens.ApplicationLauncher.AppScenes.
                                                  ALWAYS,
                            texture: OATex);
                }
            }
            
        }
    }
}
