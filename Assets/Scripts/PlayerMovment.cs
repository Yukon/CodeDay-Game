using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {
	public float power;
	public float rotationSpeed;
	private Sprite orignalSprite;
	public Sprite jetSprite;

	void Awake() {
		orignalSprite = GetComponent<SpriteRenderer>().sprite;
	}

	void FixedUpdate () {
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
}