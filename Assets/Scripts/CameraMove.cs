using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour 
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private float maxOffset;
	private Vector3 oriLength;
	private Vector3 lastMousePos;
	public GameObject ship;

	private void Start() 
	{
		oriLength = transform.position - ship.transform.position;
		lastMousePos = Vector3.zero;
	}
	
	private void FixedUpdate() 
	{
		Vector3 moveDir = ship.transform.position + oriLength;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
		Vector3 offset = transform.position -  mousePos;
		Debug.Log(offset);
		if (Mathf.Abs(offset.x) >= maxOffset)
		{
			if (offset.x < 0)
			{
				offset.x = -maxOffset;
			}
			else
			{
				offset.x = maxOffset;
			}
		}
		moveDir.x += offset.x;
		transform.position = moveDir;
	}
}
