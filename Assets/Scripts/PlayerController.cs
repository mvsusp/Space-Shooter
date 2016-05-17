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

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate = 0.5f;
    float nextFire = 0;

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

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GetComponent<AudioSource>().Play();
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
