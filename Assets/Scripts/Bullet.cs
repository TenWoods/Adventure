using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	[SerializeField]
	[Header("子弹速度")]
	private float speed = 1;
	[SerializeField]
	[Header("子弹伤害")]
	private float damage = 1;
	private Rigidbody2D rb;
	//子弹所属编号(0属于玩家, 1属于AI)
	private int belongID; 
	
	/// <summary>
	/// 发射子弹时调用
	/// </summary>
	/// <param name="target">子弹目标</param>
	public void InitBullet(Vector3 target, int belongID) 
	{
		rb = GetComponent<Rigidbody2D>();
		Vector3 dir = target - transform.position;
		rb.velocity = dir.normalized * speed;
		this.belongID = belongID;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet")
		{
			if (other.gameObject.GetComponent<Bullet>().BelongID != belongID)
			{
				Destroy(gameObject);
			}
		}
		else if (other.tag != "Player")
		{
			if (other.tag == "Box")
			{
				Destroy(other.gameObject);
			}
			Destroy(this.gameObject);
		}
	}

	public int BelongID
	{
		get
		{
			return belongID;
		}
	}

	public float Damage 
	{
		get
		{
			return damage;
		}
	}
}
