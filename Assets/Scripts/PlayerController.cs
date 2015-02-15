using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float power;
	public float rotationSpeed;
	private Sprite orignalSprite;
	public Sprite jetSprite;
    public GameObject laser;
    private SpriteRenderer spriteRender;
    public int maxHealth;
    private int health;
    private int score;

	void Awake() {
        spriteRender = GetComponent<SpriteRenderer>();
		orignalSprite = spriteRender.sprite;
        health = maxHealth;
	}

	void FixedUpdate() {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        if (moveVertical == 1) {
        	spriteRender.sprite = jetSprite;
        	rigidbody2D.AddForce(transform.up * power);
        } else if (moveVertical == 0) {
            if (spriteRender.sprite == jetSprite) {
                spriteRender.sprite = orignalSprite;
            }
        }
        rigidbody2D.MoveRotation(rigidbody2D.rotation + (moveHorizontal * -rotationSpeed));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            foreach (Transform child in transform) {
                if (child.name == "FirePosition") {
                    FireLaser(child);
                }
            }
        }

        Vector3 camPos = Camera.main.WorldToViewportPoint(transform.position);
        // Prevent z movment
        camPos.z = 0;
        camPos.x = Mathf.Clamp(camPos.x, 0.3f, 0.7f);
        camPos.y = Mathf.Clamp(camPos.y, 0.3f, 0.7f);
        Camera.main.transform.position = Camera.main.ViewportToWorldPoint(camPos);

        if (health <= 0) {
            // Dead
        }
    }

    private void FireLaser(Transform launchPosition) {
        GameObject projectile = (GameObject) Instantiate(laser, launchPosition.position, transform.rotation);
        projectile.rigidbody2D.velocity += rigidbody2D.velocity;
    }

    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Astroid") {
            health -= Mathf.Clamp((int) (rigidbody2D.velocity.sqrMagnitude * 2 - 5), 0, maxHealth);
        }
    }

    public int GetHealth() {
        return health;
    }

    public void AddPoint(int point) {
        score += point;
    }

    public int GetScore() {
        return score;
    }
}
