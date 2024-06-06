using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image Rfill;
    public Image Gfill;
    public Image Bfill;
    public GameObject player;
    private PlayerShootSpray ps;

    private float maxR;
    private float maxG;
    private float maxB;

    void Start()
    {
        ps = player.GetComponent<PlayerShootSpray>();
        maxR = ps.Rfuel;
        maxG = ps.Gfuel;
        maxB = ps.Bfuel;
    }

    // Update is called once per frame
    void Update()
    {
        Rfill.fillAmount = ps.Rfuel / maxR;
        Gfill.fillAmount = ps.Gfuel / maxG;
        Bfill.fillAmount = ps.Bfuel / maxB;
    }
}
