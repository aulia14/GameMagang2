using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/EnemyStats")]
public class EnemyStats : ScriptableObject {

	public bool m_UseDotProductInTurnMovement = true;
	public float m_DotValue = 0f;
	public float moveSpeed = 2;
	public float lookRange = 130f;
	public float lookSphereCastRadius = 60f;

	public float attackRange = 3f;
	public float attackRate = 1f;
	public float attackForce = 15f;
	public int attackDamage = 50;

	public float searchDuration = 1f;
	public float searchingTurnSpeed = 180f;
}