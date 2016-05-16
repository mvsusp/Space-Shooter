using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Boundary
{
    public float xMin;
    public float zMin;
    public float xMax;
    public float zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var rb = GetComponent<Rigidbody>();

        var velocity = new Vector3(moveHorizontal , 0, moveVertical);
        rb.velocity = velocity * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * - tilt);
    }
}
