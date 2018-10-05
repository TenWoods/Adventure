using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour 
{
	//所有种类的子弹预制体
	[SerializeField]
	private Bullet[] bulletPrefabs;
	//子弹发射点
	[SerializeField]
	[Header("普通子弹发射点")]
	private Transform[] shootPoints;
	[SerializeField]
	[Header("AOE发射点")]
	private Transform aoePoint;
	[SerializeField]
	[Header("AOE冷却时间")]
	private float aoeColdTime;
	private float aoeTimer;
	private bool isReady_AOE = true;
	private int currentBulletID = 0;
	
	public int CurrentBulletID
	{
		get
		{
			return currentBulletID;
		}
		set
		{
			currentBulletID = value;
		}
	}

	/// <summary>
	/// 炮口发射子弹
	/// </summary>
	/// <param name="target">子弹目标</param>
	public void Shoot(Vector3 target, int bulletID)
	{
		foreach(Transform sp in shootPoints)
		{
			GameObject.Instantiate(bulletPrefabs[currentBulletID], sp.position, sp.rotation).GetComponent<Bullet>().InitBullet(target, bulletID);
		}
	}

	public void AOEShoot(Vector3 direction)
	{
		isReady_AOE = false;
	}

	/// <summary>
	/// 切换子弹类型
	/// </summary>
	/// <param name="bulletID"></param>
	public void ChangeBullet(int bulletID)
	{
		if (bulletID >= bulletPrefabs.Length)
		{
			Debug.Log("bulletPrefabs:越界");
			return;
		}
		currentBulletID = bulletID;
	}


	private void Update()  
	{
		if (!isReady_AOE)
		{
			aoeTimer += Time.deltaTime;
			if (aoeTimer >= aoeColdTime)
			{
				aoeTimer = 0;
				isReady_AOE = true;
			}
		}
	}
}
