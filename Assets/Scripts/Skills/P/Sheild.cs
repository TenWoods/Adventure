using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 护盾技能
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
public class Sheild : PassitiveSkill 
{
	[SerializeField]
	[Header("护盾回复时间")]
	private float readyTime;
	[SerializeField]
	[Header("护盾总量")]
	private float sheildHP;
	[SerializeField]
	[Header("护盾UI")]
	private Slider sheildUI;
	private float sheildHPcurrent;
	private float timer = 0;
	private bool isReady = true;

	private CircleCollider2D sheildCollider;

	private void Start() 
	{
		sheildCollider = GetComponent<CircleCollider2D>();
		sheildCollider.enabled = true;
		sheildHPcurrent = sheildHP;
		sheildUI.value = 1;
	} 

	private void Update() 
	{
		if (!isReady)
		{
			timer += Time.deltaTime;
			sheildHPcurrent = sheildHP * timer / readyTime;
			UpadteUI();
			if (sheildHPcurrent >= sheildHP)
			{
				sheildHPcurrent = sheildHP;
				isReady = true;
				sheildCollider.enabled = true;
				timer = 0;
			}
			return;
		}
		if (sheildHPcurrent <= 0)
		{
			isReady = false;
			sheildCollider.enabled = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet")
		{
			if (other.gameObject.GetComponent<Bullet>().BelongID != 0)
			{
				sheildHPcurrent -= other.gameObject.GetComponent<Bullet>().Damage;
				UpadteUI();
			}
		}
	}

	private void UpadteUI()
	{
		sheildUI.value = sheildHPcurrent / sheildHP;
	}
}
