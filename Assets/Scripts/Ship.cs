using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour 
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
		Move();
	}

	private void Move()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		rb.velocity = new Vector3(h, v, 0) * speed;
	}
}
