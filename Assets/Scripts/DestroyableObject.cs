using UnityEngine;

public class DestroyableObject : ObjectProperties {
	[SerializeField]
	private int heath;

	public void Damage(int amount) {
		this.heath -= amount;
	}

	public bool IsDead() {
		return heath <= 0;
	}

	void Update() {
		if (this.IsDead()) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Projectile projectile =  collision.gameObject.GetComponent<Projectile>();
		if (projectile != null) {
			this.Damage(projectile.GetDamage());
		}
	}

}
