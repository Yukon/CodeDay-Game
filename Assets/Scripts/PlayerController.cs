using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float power;
	public float rotationSpeed;
	private Sprite orignalSprite;
	public Sprite jetSprite;
    public GameObject laser;

	void Awake() {
		orignalSprite = GetComponent<SpriteRenderer>().sprite;
	}

	void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical > 0.1) {
        	GetComponent<SpriteRenderer>().sprite = jetSprite;
        	rigidbody2D.AddForce(transform.up * power);
        } else if (moveVertical > 0 && moveVertical < 0.1) {
        	GetComponent<SpriteRenderer>().sprite = orignalSprite;
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
    }

    private void FireLaser(Transform launchPosition) {
        Instantiate(laser, launchPosition.position, transform.rotation);
    }
}
