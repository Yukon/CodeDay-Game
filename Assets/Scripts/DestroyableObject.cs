using UnityEngine;

public class DestroyableObject : ObjectProperties {
	[SerializeField]
	private int health;
	private PlayerController playerController;

	public void Awake() {
		playerController = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
	}

	public void Damage(int amount) {
		this.health -= amount;
	}

	public bool IsDead() {
		return health <= 0;
	}

	void Start() {
		if (this.IsDead()) {
			Debug.Log("Object spawned in dead", this.gameObject);
		}
	}

	void Update() {
		if (this.IsDead()) {
			playerController.AddPoint(1);
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
