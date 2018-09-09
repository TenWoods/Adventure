using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour 
{
	[SerializeField]
	private float speed;
	private Rigidbody2D rb;
	public Transform[] shootPoints;
	public GameObject bullet_Prefab;

	private void Start() 
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() 
	{
		Move();
	}

	private void Update() 
	{
		Shoot();
	}

	private void Shoot()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GameObject bullet = null;
			for(int i = 0; i < 2; i++)
			{
				bullet = GameObject.Instantiate(bullet_Prefab, shootPoints[i].position, shootPoints[i].rotation);
				bullet.GetComponent<Bullet>().Target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
			}
		}
	}

	private void Move()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		rb.velocity = new Vector3(h, v, 0) * speed;
	}
}
