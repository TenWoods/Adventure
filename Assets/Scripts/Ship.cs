using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 飞船操作类
/// </summary>
[RequireComponent(typeof(Canon))]
public class Ship : MonoBehaviour 
{
	//飞船速度
	[SerializeField]
	[Header("飞船速度")]
	private float speed;
	[SerializeField]
	[Header("飞船HP")]
	private float shipHP;
	[SerializeField]
	[Header("血量UI")]
	private Slider shipHPUI;
	[SerializeField]
	//所有的主动技能
	private ActiveSkill[] activeSkills;
	[SerializeField]
	//所有被动技能
	private PassitiveSkill[] passitiveSkills;
	//主动技能键值对
	private Dictionary<KeyCode, int> activeSkillButtons;
	//携带被动技能
	private List<int> passitiveSkillsON;
	private float shipHPcurrent;
	private Canon shipCanon;
	private Rigidbody2D rb;
	
	private void Start() 
	{
		rb = GetComponent<Rigidbody2D>();
		shipCanon = GetComponent<Canon>();
		activeSkillButtons = new Dictionary<KeyCode, int> {{KeyCode.Q, 0},
													 {KeyCode.LeftShift, 0}, 
													 {KeyCode.F, 0}, 
													 {KeyCode.Space, 0}};
		passitiveSkillsON = new List<int>();
		shipHPcurrent = shipHP;
	}

	private void Update() 
	{
		Move();
		Shoot();
		Skill();
	}

	#region 飞船按键操作

	/// <summary>
	/// 发射子弹
	/// </summary>
	private void Shoot()
	{
		if (Input.GetMouseButtonDown(0))
		{
			shipCanon.Shoot(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)), 0);
		}
	}

	/// <summary>
	/// 飞船移动
	/// </summary>
	private void Move()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		rb.velocity = new Vector3(h, v, 0) * speed;
	}

	/// <summary>
	/// 使用技能
	/// </summary>
	private void Skill()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			activeSkills[activeSkillButtons[KeyCode.Q]].Enable();
		}
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			activeSkills[activeSkillButtons[KeyCode.LeftShift]].Enable();
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			activeSkills[activeSkillButtons[KeyCode.F]].Enable();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			activeSkills[activeSkillButtons[KeyCode.Space]].Enable();
		}
	}

	#endregion
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet")
		{
			shipHPcurrent -= other.GetComponent<Bullet>().Damage;
			UpdateUI();
		}
	}

	private void UpdateUI()
	{
		shipHPUI.value = shipHPcurrent / shipHP;
	}
}
