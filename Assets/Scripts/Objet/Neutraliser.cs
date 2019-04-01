using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Neutraliser : MonoBehaviour
{
    private PlayerMovement player = null;

    [SerializeField]
    private GameObject bar = null;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bar.SetActive(true);
            player = other.GetComponentInParent<PlayerMovement>();
            player.Neutraliser.CurrentValue += 1;
            Destroy(gameObject);
        }
    }
}
