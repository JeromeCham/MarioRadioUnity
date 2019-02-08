using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radioactivity : MonoBehaviour
{
    public float radioMagnitude = 0.0f;
    public float dmgTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("radioDmg", 0.0f, dmgTimer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void radioDmg()
    {
        GameObject playerFox = GameObject.Find("PlayerFox");
        Player player = playerFox.GetComponent<Player>();
        player.takeDmg(radioMagnitude);
    }
}
