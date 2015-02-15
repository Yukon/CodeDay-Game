using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private PlayerController playerController;
	public Text healthText;
	public Text scoreText;

	void Awake() {
		playerController = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
	}

	void Update() {
		healthText.text = "Health: " + playerController.GetHealth();
		scoreText.text = "Score: " + playerController.GetScore();
	}
}