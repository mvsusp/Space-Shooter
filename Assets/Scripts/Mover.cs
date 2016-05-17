using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

    void Start()
    {
        var rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;
    }
}
