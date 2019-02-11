using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]
    private Collider2D other, other2, other3;

    private void Awake()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other2, true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other3, true);
    }
}
