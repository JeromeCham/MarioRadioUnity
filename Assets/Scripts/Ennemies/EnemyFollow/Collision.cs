using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]
    private Collider2D other = null, other2 = null, other3 = null;

    private void Awake()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other2, true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other3, true);
    }
}
