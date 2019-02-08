using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radioactivity : MonoBehaviour
{
    public float radioMagnitude = 0.0f;
    public float dmgTimer = 0.0f;
    public Vector2 centre;
    public float rayon = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("radioDmg", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void radioDmg()
    {
        centre = GameObject.Find("SourceRadioactive").
        //Collider2D rayonEffet = Physics2D.OverlapCircleAll(Vector2 centre, float rayon);
        GameObject playerFox = GameObject.Find("PlayerFox");
        Player player = playerFox.GetComponent<Player>();
        player.takeDmg(radioMagnitude, dmgTimer);
    }
}
