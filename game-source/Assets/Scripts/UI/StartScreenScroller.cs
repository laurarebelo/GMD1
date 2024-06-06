using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenScroller : MonoBehaviour
{
    public RawImage img;
    public float xSpd;

    // Update is called once per frame
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(xSpd, 0) * Time.deltaTime, img.uvRect.size);
    }
}
