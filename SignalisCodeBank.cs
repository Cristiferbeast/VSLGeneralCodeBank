using MelonLoader;
using System.IO;
using UnityEngine;
using UnityEngine.IO;
using UnityEngine.SceneManagement;

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
        public void TypeString(string inputString)
        {
            // Create an InputSystem object to send key inputs
            InputSystem inputSystem = InputSystem.GetOrCreate();

            // Loop through each character in the input string
            foreach (char letter in inputString)
            {
                // Convert the character to a KeyCode
                KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), letter.ToString().ToUpper());

                // Create a new Keyboard object with the desired key code
                Keyboard keyboard = InputSystem.AddDevice<Keyboard>();
                KeyboardKey key = keyboard[keyCode];

                // Send a key down event for the specified key
                key.WriteValueIntoEvent(new KeyDownEvent());

                // Wait for 10 milliseconds
                System.Threading.Thread.Sleep(10);

                // Send a key up event for the specified key
                key.WriteValueIntoEvent(new KeyUpEvent());

                // Remove the Keyboard object to release the key
                InputSystem.RemoveDevice(keyboard);
            }
        }
    }
}
