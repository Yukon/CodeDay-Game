using UnityEngine;

public class DestroyableObject : ObjectProperties {
	[SerializeField]
	protected int health;
	[SerializeField]
	private int pointValue;
	[SerializeField]
	private GameObject particleSystemOnDeath;
	private PlayerController playerController;

	void Awake() {
		playerController = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
	}

	public void Damage(int amount) {
		this.health -= amount;
	}

	public bool IsDead() {
		return health <= 0;
	}

	public int GetHealth() {
		return health;
	}

	void Start() {
		if (this.IsDead()) {
			Debug.Log("Object spawned in dead", this.gameObject);
		}
	}

	void Update() {
		if (this.IsDead()) {
			playerController.AddPoint(pointValue);
			TrySpawningParticleSystem();
			Destroy(this.gameObject);
		}
	}

	protected void TrySpawningParticleSystem() {
		if (particleSystemOnDeath != null) {
			Instantiate(particleSystemOnDeath, transform.position, transform.rotation);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Projectile projectile =  collision.gameObject.GetComponent<Projectile>();
		if (projectile != null) {
			this.Damage(projectile.GetDamage());
		}
	}

}
