using UnityEngine;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private int damage;

	public int GetDamage() {
		return damage;
	}
}
