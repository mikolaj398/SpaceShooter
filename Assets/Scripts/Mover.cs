using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rd;
    public float speed;
    private void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.velocity = transform.forward * speed;
    }
}
