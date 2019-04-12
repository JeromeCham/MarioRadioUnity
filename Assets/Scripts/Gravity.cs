using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private float gravityModifier = 3f;

    [SerializeField]
    private Rigidbody2D rb = null;

    void Update()
    {
        rb.velocity += gravityModifier * new Vector2(0, -9.8f) * Time.deltaTime;
    }
}
