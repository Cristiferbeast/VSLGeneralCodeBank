using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Camera_Perspective_Mod
{
    public class PerspectiveChange : MelonMod
    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonLoader.MelonLogger.Msg("Scene loaded: " + sceneName);
            if (SceneManager.GetActiveScene().name != "PEN_Hole")
            {
                if (GameObject.Find("__Prerequisites__") != null)
                {
                    ///Basics Variables
                    GameObject PreReq = GameObject.Find("__Prerequisites__");
                  
                    //Create Copied Series 
                    GameObject ModdedCamSeries = Object.Instantiate(PreReq, PreReq.transform.position, PreReq.transform.rotation);
                    ModdedCamSeries.name = "ModdedCamSeries";
                    GameObject AngCamRig2 = ModdedCamSeries.transform.Find("Angled Camera Rig").gameObject;
                    GameObject LocalSpace2 = AngCamRig2.transform.Find("LocalSpace").gameObject;
                    GameObject ModdedCam = LocalSpace2.transform.Find("Main Camera").gameObject;

                    //Char Variables
                    GameObject CharOrigin = PreReq.transform.Find("Character Origin").gameObject;
                    GameObject CharRoot = CharOrigin.transform.Find("Character Root").gameObject;

                    //Create Modded Camera
                    ModdedCam.transform.parent = CharRoot.transform;
                    ModdedCam.name = "ModdedCam";
                    MelonLoader.MelonLogger.Msg("Modded Camera Created");
                    ModdedCam.GetComponent<AngledCamControl>().enabled = false;
                    UnityEngine.Camera cameraComponent = ModdedCam.GetComponent<UnityEngine.Camera>();
                    cameraComponent.orthographic = false;
                    GameObject VHS = ModdedCam.transform.Find("VHS UI").gameObject;
                    UnityEngine.Camera VHSComponent = VHS.GetComponent<UnityEngine.Camera>();
                    VHSComponent.orthographic = false;
                    ModdedCam.SetActive(false);
                    //Camera is disabled at the end to be called on mod activation. 

                    //Clean Up Copy 
                    GameObject FauxCharacter = ModdedCamSeries.transform.Find("Character Origin").gameObject;
                    Object.Destroy(FauxCharacter);
                    ModdedCamSeries.SetActive(false);

                }
            }
        }
        public override void OnUpdate()
        {
            if (SceneManager.GetActiveScene().name != "PEN_Hole")
            {
                if (GameObject.Find("__Prerequisites__") != null)
                {
                    ///Basics Variables
                    GameObject PreReq = GameObject.Find("__Prerequisites__");
                    GameObject AngCamRig = PreReq.transform.Find("Angled Camera Rig").gameObject;
                    GameObject LocalSpace = AngCamRig.transform.Find("LocalSpace").gameObject;
                    GameObject MainCamera = LocalSpace.transform.Find("Main Camera").gameObject;
                    GameObject ModdedCamSeries = GameObject.Find("ModdedCamSeries");

                    //Char Variables
                    GameObject CharOrigin = PreReq.transform.Find("Character Origin").gameObject;
                    GameObject CharRoot = CharOrigin.transform.Find("Character Root").gameObject;

                    //FPS Cam
                    if (Input.GetKeyDown(KeyCode.F1))
                    {
                        ModdedCamSeries.SetActive(true);
                        MainCamera.SetActive(false);
                        GameObject ModdedCam = CharRoot.transform.Find("ModdedCam").gameObject;
                        ModdedCam.SetActive(true);
                        ModdedCam.transform.localPosition = new Vector3(0.3f, 8.4f, 2.1f);
                        ModdedCam.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        MelonLoader.MelonLogger.Msg("FPS Mode Enabled");
                    }
                    //DeadSpace Cam
                    if (Input.GetKeyDown(KeyCode.F2))
                    {
                        ModdedCamSeries.SetActive(true);
                        MainCamera.SetActive(false);
                        MelonLoader.MelonLogger.Msg("DeadSpace Camera Mode Enabled");
                        GameObject ModdedCam = CharRoot.transform.Find("ModdedCam").gameObject;
                        ModdedCam.SetActive(true);
                        ModdedCam.transform.localPosition = new Vector3(3, 7.5f, -5f);
                        ModdedCam.transform.localRotation = Quaternion.Euler(5, 355, 0);
                    }
                    if (Input.GetKeyDown(KeyCode.F3))
                    {
                        ModdedCamSeries.SetActive(false);
                        MainCamera.SetActive(true);
                        MelonLoader.MelonLogger.Msg("OG Camera Restored");
                    }

                    //DMC Cam
                    if (Input.GetKeyDown(KeyCode.KeypadPlus))
                    {
                        ModdedCamSeries.SetActive(true);
                        MainCamera.SetActive(false);
                        MelonLoader.MelonLogger.Msg("DMC Camera Mode Enabled");
                        GameObject ModdedCam = CharRoot.transform.Find("ModdedCam").gameObject;
                        ModdedCam.SetActive(true);
                        ModdedCam.transform.localPosition = new Vector3(0.3491f, 10.4746f, -6.7382f);
                        ModdedCam.transform.localRotation = Quaternion.Euler(13.7783f, 358.8838f, 359.6f);
                    }
                }
            }
        }
    }
}
