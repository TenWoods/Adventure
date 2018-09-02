using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour 
{
	[SerializeField]
	private float maxOffset_x;
	[SerializeField]
	private float maxOffset_y;
	private Vector3 oriLength;
	public GameObject ship;

	private void Start() 
	{
		oriLength = transform.position - ship.transform.position;
	}
	
	private void FixedUpdate() 
	{
		Vector3 moveDir = ship.transform.position + oriLength;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
		Vector3 offset = transform.position -  mousePos;
		if (Mathf.Abs(offset.x) >= maxOffset_x)
		{
			if (offset.x < 0)
			{
				offset.x = -maxOffset_x;
			}
			else
			{
				offset.x = maxOffset_x;
			}
		}
		if (Mathf.Abs(offset.y) >= maxOffset_y)
		{
			if (offset.y < 0)
			{
				offset.y = -maxOffset_y;
			}
			else
			{
				offset.y = maxOffset_y;
			}
		}
		moveDir.x += offset.x;
		moveDir.y += offset.y;
		transform.position = moveDir;
	}
}
