using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ActiveSkill 
{	
	[SerializeField]
	[Header("冲刺的距离")]
	private float dashLength;
	[SerializeField]
	private GameObject shipBody;
	[SerializeField]
	private CapsuleCollider2D capsule;
	[SerializeField]
	private float offset;
	
	public override void Enable()
	{
		if (isCold)
		{
			return;
		}
		isCold = true;
		RaycastHit2D hitInfo;
		float currentDash = dashLength;
		//左冲
		if (Input.GetKeyDown(KeyCode.D))
		{
			Debug.Log("Dash");
			hitInfo = Physics2D.Raycast(shipBody.transform.position, new Vector3(1, 0, 0), dashLength);
			if (hitInfo.collider != null)
			{
				if (hitInfo.collider.tag == "Edge")
				{
					currentDash = Mathf.Abs(hitInfo.point.x - shipBody.transform.position.x);
				}
			}
			shipBody.transform.position += new Vector3(currentDash, 0, 0);
		}
		//右冲
		else if (Input.GetKeyDown(KeyCode.A))
		{
			Debug.Log("Dash");
			hitInfo = Physics2D.Raycast(shipBody.transform.position, new Vector3(-1, 0, 0), dashLength);
			if (hitInfo.collider != null)
			{
				if (hitInfo.collider.tag == "Edge")
				{
					currentDash = Mathf.Abs(hitInfo.point.x - shipBody.transform.position.x);
				}
			}
			shipBody.transform.position -= new Vector3(currentDash, 0, 0);
		}
		//上冲
		else if (Input.GetKeyDown(KeyCode.W))
		{
			Debug.Log("Dash");
			hitInfo = Physics2D.Raycast(shipBody.transform.position, new Vector3(0, 1, 0), dashLength);
			if (hitInfo.collider != null)
			{
				if (hitInfo.collider.tag == "Edge")
				{
					currentDash = Mathf.Abs(hitInfo.point.y - shipBody.transform.position.y);
				}
			}
			shipBody.transform.position += new Vector3(0, currentDash, 0);
		}
		//下冲
		else if (Input.GetKeyDown(KeyCode.S))
		{
			Debug.Log("Dash");
			hitInfo = Physics2D.Raycast(shipBody.transform.position, new Vector3(0, -1, 0), dashLength);
			if (hitInfo.collider != null)
			{
				if (hitInfo.collider.tag == "Edge")
				{
					currentDash = Mathf.Abs(hitInfo.point.y - shipBody.transform.position.y);
				}
			}
			shipBody.transform.position -= new Vector3(0, currentDash, 0);
		}
	}
}
