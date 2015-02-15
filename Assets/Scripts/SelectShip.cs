using UnityEngine;

public class SelectShip : MonoBehaviour {
	public GameObject ship;

	void OnMouseDown() {
		Instantiate(ship, new Vector3(0, 0, -100), Quaternion.identity);
		Application.LoadLevel("Loading");
	}
}