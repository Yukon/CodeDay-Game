using UnityEngine;
using System.Collections;

public class PlayerController : DestroyableObject {
	public float power;
	public float rotationSpeed;
	private Sprite orignalSprite;
	public Sprite jetSprite;
    public GameObject laser;
    private SpriteRenderer spriteRender;
    protected int score;
    public GameObject gameOverUI;

	void Awake() {
        DontDestroyOnLoad(this.gameObject);
        spriteRender = GetComponent<SpriteRenderer>();
		orignalSprite = spriteRender.sprite;
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
        // Just spawned in HACKY!
        if (transform.position.z == -100 && Application.loadedLevelName == "GameView") {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

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

        if (this.IsDead()) {
            gameObject.SetActive(false);
            Instantiate(gameOverUI, new Vector3(0, 0, 0), Quaternion.identity);
            TrySpawningParticleSystem();
        }
    }

    private void FireLaser(Transform launchPosition) {
        GameObject projectile = (GameObject) Instantiate(laser, launchPosition.position, transform.rotation);
        projectile.rigidbody2D.velocity += rigidbody2D.velocity;
    }

    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Astroid") {
            Damage(Mathf.Clamp((int) (rigidbody2D.velocity.sqrMagnitude * 2 - 5), 0, int.MaxValue));
        }
    }

    public void AddPoint(int point) {
        score += point;
    }

    public int GetScore() {
        return score;
    }
}
