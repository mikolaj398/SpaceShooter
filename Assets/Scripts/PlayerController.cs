using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float minX, maxX, minZ, maxZ;
}
public class PlayerController : MonoBehaviour {

    private Rigidbody rd;
    private AudioSource audio;
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    private void Start()
    {
        rd = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if ((Input.GetKey(KeyCode.Space))&&(Time.time>nextFire))
        {
            nextFire =Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rd.velocity = movement*speed;

        rd.position = new Vector3
        (
            Mathf.Clamp(rd.position.x, boundary.minX, boundary.maxX),
            0.0f,
            Mathf.Clamp(rd.position.z, boundary.minZ, boundary.maxZ)
         );
        rd.rotation = Quaternion.Euler(0.0f, 0.0f, rd.velocity.x * -tilt);
    }
}
