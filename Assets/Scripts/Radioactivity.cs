using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radioactivity : MonoBehaviour
{
    public float radioMagnitude = 0.0f;
    public float dmgTimer = 0.0f;
    public float maxTimer = 0.3f;
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
        rayon = 0;
        Vector2 centre = GameObject.Find("SourceRadioactive").transform.position;
        Collider2D[] rayonEffet = Physics2D.OverlapCircleAll(centre, rayon);

        foreach (Collider2D hit in rayonEffet)
        {
            PlayerMovement player = hit.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.takeDmg(radioMagnitude);
            }
        }
    }
}
