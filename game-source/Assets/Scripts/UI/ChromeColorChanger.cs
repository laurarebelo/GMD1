using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChromeColorChanger : MonoBehaviour
{
    // Class for changing the colors of the title
    // as an easter egg depending on the input colors!!
    
    public Sprite originalColors;
    public Sprite monoColors;
    private Image img;
    private bool pressingR;
    private bool pressingG;
    private bool pressingB;
    
    
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = originalColors;
    }
    
    
    private bool CheckForColorInput()
    {
        pressingR = Input.GetButton("FireR");
        pressingG = Input.GetButton("FireG");
        pressingB = Input.GetButton("FireB");

        return pressingR || pressingG || pressingB;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckForColorInput())
        {
            Color pressedCol = Colorz.GetColor(pressingR, pressingG, pressingB);
            img.sprite = monoColors;
            img.color = pressedCol;
        }
        else
        {
            img.color = Color.white;
            img.sprite = originalColors;
        }
    }
}
