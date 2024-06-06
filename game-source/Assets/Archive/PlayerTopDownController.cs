using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed;
    private Transform rotPoint;

    void Start()
    {
        rotPoint = transform.Find("RotatePoint");
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        
        transform.Translate(Vector2.right * (x * movSpeed * Time.deltaTime));
        transform.Translate(Vector2.up * (y * movSpeed * Time.deltaTime));
        float rotZ = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        
        if (xRaw != 0 || yRaw != 0)
        {
            rotPoint.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
}
