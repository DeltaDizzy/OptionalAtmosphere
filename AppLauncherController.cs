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
                if (KSP.UI.Screens.ApplicationLauncher.Ready)
                {
                    UnityEngine.Texture toolbar_button_texture;
                    LoadTextureOrDie(out toolbar_button_texture, "toolbar_button.png");
                    OAButton =
                        KSP.UI.Screens.ApplicationLauncher.Instance.AddModApplication(
                            onTrue: AtmosphereController.AtmosphereToggler,
                            onFalse: null,
                            onHover: null,
                            onHoverOut: null,
                            onEnable: null,
                            onDisable: null,
                            visibleInScenes: KSP.UI.Screens.ApplicationLauncher.AppScenes.
                                                  ALWAYS,
                            texture: toolbar_button_texture);
                }
            }
            
        }
    }
}
