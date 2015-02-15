using UnityEngine;

public class Projectile : MonoBehaviour {
	[SerializeField]
	private int damage;
	[SerializeField]
	private int speed;

	public int GetDamage() {
		return damage;
	}

	void Start() {
		rigidbody2D.AddForce(transform.up * speed);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy(this.gameObject);
	}
}
