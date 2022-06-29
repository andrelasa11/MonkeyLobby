using UnityEngine;

public class BackgroundCollor : MonoBehaviour
{

    public Camera cameraUI;
    public Color color;
  
    public void ChangeBackgroundCollor(string hexadecimalColorCode)
    {
        ColorUtility.TryParseHtmlString(hexadecimalColorCode, out color);

        cameraUI.backgroundColor = color;
    }

    
}
