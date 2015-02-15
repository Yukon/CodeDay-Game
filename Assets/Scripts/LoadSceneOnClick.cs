using UnityEngine;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour {
	public string scene;

	void Awake() {
		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(() => OnClick());
	}

	void OnClick() {
		Application.LoadLevel(scene);
	}
}
