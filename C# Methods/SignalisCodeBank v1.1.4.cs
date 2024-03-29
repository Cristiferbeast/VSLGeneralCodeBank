using UnityEngine;
using System.IO;


namespace VSLSignalisCodeBank
{
    public class SignalisCodeBank
    {
        public static Material TextureFind(GameObject desiredObject)
        {
            //Used in mods that swap textures without use of SURS
            SkinnedMeshRenderer renderer = desiredObject.GetComponent<SkinnedMeshRenderer>();
            if (renderer != null)
            {
                MelonLoader.MelonLogger.Msg("Texture Loaded");
                Material material = renderer.material;
                return material;
            }
            else
            {
                return null;
            }
        }
        public static Texture2D SURSImageCall(string filename)
        {
            //Used in SURS (Signalis Universal ReSkin Mod)
            byte[] imageData = System.IO.File.ReadAllBytes(filename);
            Texture2D SURStexture = new Texture2D(2, 2);
            ImageConversion.LoadImage(SURStexture, imageData);
            return SURStexture;
        }
        public bool CustomCamera(GameObject CharRoot, GameObject MainCamera, Vector3 coords, Quaternion.Euler position)
        {
            MainCamera.SetActive(false);
            GameObject ModdedCam = CharRoot.transform.Find("ModdedCam").gameObject;
            if ModdedCam == null
            {
                return false;
            }
            else 
            {   
                ModdedCam.SetActive(true);
                ModdedCam.transform.localPosition = coords;
                ModdedCam.transform.localRotation = position;
                return true;
            }
        }
        public bool CameraToggle(GameObject ModdedCam, GameObject CharRoot)
        {
            ModdedCam.transform.parent = CharRoot.transform;
            MelonLoader.MelonLogger.Msg("Modded Camera Created");
            ModdedCam.GetComponent<AngledCamControl>().enabled = false;
            UnityEngine.Camera cameraComponent = ModdedCam.GetComponent<UnityEngine.Camera>();
            cameraComponent.orthographic = false;
            GameObject VHS = ModdedCam.transform.Find("VHS UI").gameObject;
            UnityEngine.Camera VHSComponent = VHS.GetComponent<UnityEngine.Camera>();
            VHSComponent.orthographic = false;
        }
        public bool GOErrorCatch(string ObjectName, GameObject parent)
        {
            try
            {
                GameObject AngCamRig = parent.transform.Find(ObjectName).gameObject;
                return false;
            }
            catch
            {
                MelonLoader.MelonLogger.Msg("Error", ObjectName, "Not Found");
                return true;
            }
        }
    }
    public class SUMA
    {
        public static GameObject ModelCall(string mainFileBranch, string modelName)
        {
            string customreplika = Path.Combine(mainFileBranch, modelName);
            if (!File.Exists(customreplika))
            {
                MelonLoader.MelonLogger.Msg(modelName, " Model Not Found ");
                return null;
            }
            GameObject model = Resources.Load<GameObject>(modelName);
            if (model == null)
            {
                MelonLoader.MelonLogger.Msg(modelName, " Model Could Not Load ");
                return null;
            }
            return model;
        }
        public static MeshRenderer ModelCall(GameObject model)
        {
            MeshRenderer renderer = new MeshRenderer();
            renderer = model.GetComponent<MeshRenderer>();
            if (renderer == null)
            {
                MelonLoader.MelonLogger.Msg("Render Not Found, Check that File is Proper");
                return null;
            }
            return renderer;
        }
        public static void Outfit (GameObject parent, GameObject model, float scaleFactor)
        {
            //Needs Model to be Insatiated Before Use, Insatatation can be done by SUMA.Spawn or normal Insatiation
            if (parent == null) { MelonLoader.MelonLogger.Msg("Parent Not Found, Check that File is Proper");}
            if (model == null) { MelonLoader.MelonLogger.Msg("Model Not Found, Check that File is Proper"); }
            //Offset Coords are Experimental
            Vector3 offset = new Vector3(1f, 2f, 3f);
            model.transform.position = parent.transform.position + offset;
            model.transform.rotation = parent.transform.rotation;
            model.transform.localScale *= scaleFactor;
            model.transform.parent = parent.transform;
        }
        public static void Spawn (GameObject model, GameObject parent, Vector3 localposition, Quaternion rotation)
        {
            GameObject spawned = GameObject.Instantiate(model);
            spawned.transform.parent = parent.transform;
            model.transform.position = parent.transform.position + localposition;
            model.transform.rotation = rotation;
        }
    }
}
