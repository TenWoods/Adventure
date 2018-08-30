using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour 
{
	[SerializeField]
	private float speed;
	private Rigidbody rb;

	private void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update() 
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Debug.Log(h);
		Debug.Log(v);
		rb.velocity = new Vector3(h, v, 0) * speed;
	}
}
