using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	[SerializeField]
	private float speed = 1;
	private Vector3 target;
	private Rigidbody2D rb;
	
	private void Start() 
	{
		rb = GetComponent<Rigidbody2D>();
		Vector3 dir = target - transform.position;
		rb.velocity = dir.normalized * speed;
	}

	public Vector3 Target 
	{
		set
		{
			target = value;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		Debug.Log("Enter");
		if (other.tag == "Edge")
		{
			Destroy(this);
		}
	}
}
