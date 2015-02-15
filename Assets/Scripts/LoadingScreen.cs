using UnityEngine;

public class LoadingScreen : MonoBehaviour {
	public string scene;

	void Start() {
		Application.LoadLevel(scene);
	}
}
