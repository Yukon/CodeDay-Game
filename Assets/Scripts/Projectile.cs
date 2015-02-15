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

	void Update() {
		Vector3 cameraView = Camera.main.WorldToViewportPoint(transform.position);
		if (cameraView.x > 1 || cameraView.x < 0 || cameraView.y > 1 || cameraView.y < 0) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag != "Player") {
			Destroy(this.gameObject);
		}
	}
}
