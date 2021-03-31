using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : MonoBehaviour
{
    Rigidbody rb;
    float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        speed = Random.Range(1, 8);
        rb.velocity = transform.up * speed;
    }

}
