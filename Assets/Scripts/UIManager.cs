using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Text healthText;
	private PlayerController playerController;

	void Awake() {
		playerController = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
	}

	void Update() {
		healthText.text = "Health: " + playerController.GetHealth();
	}
}