using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour 
{
	[SerializeField]
	private float speed = 1f;
	[SerializeField]
	private Vector3 dir;
	[SerializeField]
	private float maxMove;
	private bool isMove = false;
	private Vector3 count;
	public GameObject[] doors;

	private void Start() 
	{
		count = new Vector3(dir.x, dir.y, dir.z);
	}

	private void Update() 
	{
		if (isMove)
		{
			for(int i = 0; i < 2; i++)
			{
				doors[i].transform.position += dir * speed * Time.deltaTime * Mathf.Pow(-1, i);
			}
			count += dir * speed * Time.deltaTime;
			if ((count - dir).magnitude >= maxMove)
			{
				Destroy(this.gameObject);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player")
		{
			isMove = true;
		}
	}
}
