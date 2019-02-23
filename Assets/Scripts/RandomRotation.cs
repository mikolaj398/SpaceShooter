using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

    public float tumble;
    private Rigidbody rd;

	void Start () {
        rd = GetComponent<Rigidbody>();
        rd.angularVelocity = Random.insideUnitSphere * tumble;
    }
	
}
