using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnOffScreen : MonoBehaviour
{
    // Class that works for Respawning pickups
    // of the screen by tracking camera movement.
    private Camera mainCamera;
    private Vector2 widthThreshold;
    private Vector2 heightThreshold;
    public bool active;
    public List<SpriteRenderer> srs;

    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main;
        widthThreshold = new Vector2(Screen.width * -0.04f, Screen.width * 1.04f);
        heightThreshold = new Vector2(Screen.height * -0.04f, Screen.height * 1.04f);
    }
    
    private void Start()
    {
        active = true;
    }

    public void Active(bool yn)
    {
        if (yn)
        {
            active = true;
            foreach (SpriteRenderer sr in srs)
                sr.enabled = true;
        }
        else
        {
            active = false;
            foreach (SpriteRenderer sr in srs)
                sr.enabled = false;
        }
    }

    void Update()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThreshold.x || screenPosition.x > widthThreshold.y ||
            screenPosition.y < heightThreshold.x || screenPosition.y > heightThreshold.y)
        {
            Active(true);
        }
    }
}