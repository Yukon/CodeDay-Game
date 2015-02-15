using UnityEngine;

[System.Serializable]
public class WorldObject {
	[SerializeField]
	private GameObject gameObject;
	[SerializeField]
	private WorldObjectType type;
	[SerializeField]
	private float weight;

	public GameObject GetGameObject() {
		return this.gameObject;
	}

	public WorldObjectType GetObjectType() {
		return this.type;
	}
}
