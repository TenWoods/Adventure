using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌方AI
/// </summary>
[RequireComponent(typeof(Canon))]
public class EnemyAI : MonoBehaviour 
{
	[SerializeField]
	[Header("每发冷却时间")]
	private float coldTime;
	private Canon canon;
	private float timer;

	private void Start() 
	{
		canon = GetComponent<Canon>();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer > coldTime)
		{
			canon.Shoot(new Vector3(-1, 0, 0), 1);
			timer = 0;
		}
	}
}
