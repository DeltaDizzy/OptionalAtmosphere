using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OptionalAtmopsheres2
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, true)]

    public class AtmosphereController : MonoBehaviour
    {
        public static List<String> atmosphericBodies;

        // The first method that gets executed on that script
        void Awake()
        {
            if (atmosphericBodies == null)
                atmosphericBodies = PSystemManager.Instance.localBodies.Where(b => b.atmosphere).Select(b => b.transform.name).ToList();

            // Stop the Garbage Collector
            DontDestroyOnLoad(this);
        }

        public static void AtmosphereToggler()
        {
            // Only run in TrackingStation or MapView
            if (!HighLogic.LoadedSceneHasPlanetarium && !MapView.MapIsEnabled)
                return;
            // Only work when the player is focused on a planet
            if (PlanetariumCamera.fetch.target.celestialBody == null)
                return;

            // When the user presses Ctrl+A in the Tracking Station, toggle the atmosphere of the currently selected body
           
                // Get the body
                CelestialBody body = PSystemManager.Instance.localBodies.Find(b => b.transform.name == PlanetariumCamera.fetch.target.celestialBody.transform.name); // Yes this is silly, but it shows how to find a body by its name

            // Toggle Atmosphere
            if (atmosphericBodies.Contains(body.transform.name))
            {
                // Disable the Atmosphere from Ground
                AtmosphereFromGround[] afgs = body.GetComponentsInChildren<AtmosphereFromGround>();
                foreach (AtmosphereFromGround afg in afgs)
                {
                    afg.gameObject.SetActive(false);
                }

                // Disable the Light controller
                MaterialSetDirection[] msds = body.GetComponentsInChildren<MaterialSetDirection>();
                foreach (MaterialSetDirection msd in msds)
                {
                    msd.gameObject.SetActive(false);
                }

                // No Atmosphere :(
                body.atmosphere = false;

                // Message
                ScreenMessages.PostScreenMessage("Atmosphere Disabled " + body.displayName.Replace("^N", ""), 2f, ScreenMessageStyle.UPPER_RIGHT);
            }
            else
            {
                // Enable the Atmosphere from Ground
                AtmosphereFromGround[] AtmoFromGround = body.GetComponentsInChildren<AtmosphereFromGround>();
                foreach (AtmosphereFromGround afg in AtmoFromGround)
                {
                    afg.gameObject.SetActive(true);
                }

                // Enable the Light controller
                MaterialSetDirection[] materialSetDir = body.GetComponentsInChildren<MaterialSetDirection>();
                foreach (MaterialSetDirection msd in materialSetDir)
                {
                    msd.gameObject.SetActive(true);
                }

                // Atmosphere \o/
                body.atmosphere = true;

                // Message
                ScreenMessages.PostScreenMessage("Atmosphere Enabled " + body.displayName.Replace("^N", ""), 2f, ScreenMessageStyle.UPPER_RIGHT);
            }
        }

        // This method runs every frame
        void Update()
        {
            if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.A))
            {
                AtmosphereToggler();
            }
        }
    }
}
