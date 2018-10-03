using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : MonoBehaviour 
{
	[SerializeField]
	[Header("技能冷却时间")]
	private float coldTime = 5.0f;
	private float coldTimer;
	protected bool isCold;

	private void Start()  
	{
		coldTimer = coldTime;
		isCold = false;
	}

	private void Update() 
	{
		if (isCold)
		{
			coldTimer += Time.deltaTime;
			if (coldTimer >= coldTime)
			{
				coldTimer = 0;
				isCold = false;
			}
		}
	}

	/// <summary>
	/// 技能发动
	/// </summary>
	public virtual void Enable(){}

	/// <summary>
	/// 技能结束
	/// </summary>
	public virtual void Disable(){}
}
