using System.Collections;
using UnityEngine;
using KSP.UI.Screens;

namespace OptionalAtmopsheresRevamped
{
        class ToolbarControllers : MonoBehaviour
        {
            //Create button object
            ApplicationLauncherButton OARApp = new ApplicationLauncherButton();

            //Create button check field. If this is true, than a button is present and another can't be created. 
            //If it is false, then a button is not present and can be created if the scene requirements are met.
            bool OARButton = false;
            
            //Encapsulate field in property
            public bool OARButton1
            {
                get
                {
                    return OARButton;
                }

                set
                {
                    OARButton = value;
                }
            }

            public void AppLauncherController()
            {

                if (ApplicationLauncher.Ready && OARButton1 == false)
                {
                    //Get AppLauncher Icon
                    Texture2D OATex = GameDatabase.Instance.GetTexture("OptionalAtmospheres/Icons/OAR.png", false);

                    //Add button to toolbar using button object
                    OARApp = ApplicationLauncher.Instance.AddModApplication(
                            onTrue: AtmosphereController.AtmosphereToggler,
                            onFalse: null,
                            onHover: null,
                            onHoverOut: null,
                            onEnable: null,
                            onDisable: OAButtonDestructor,
                            visibleInScenes: ApplicationLauncher.AppScenes.MAPVIEW | ApplicationLauncher.AppScenes.TRACKSTATION,
                            texture: OATex);

                    //Set check property to true
                    OARButton1 = true;
                }
            }

            public void OAButtonDestructor()
            {
                //Remove Button
                ApplicationLauncher.Instance.RemoveModApplication(OARApp);

                //Set check to false
                OARButton1 = false;
            }
        }
    }   
