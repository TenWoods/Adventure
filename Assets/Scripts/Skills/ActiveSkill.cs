using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : MonoBehaviour 
{
	[SerializeField]
	[Header("技能冷却时间")]
	protected float coldTime = 5.0f;

	/// <summary>
	/// 技能发动
	/// </summary>
	public virtual void Enable(){}

	/// <summary>
	/// 技能结束
	/// </summary>
	public virtual void Disable(){}
}
