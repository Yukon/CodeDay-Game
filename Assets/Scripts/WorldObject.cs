using UnityEngine;

[System.Serializable]
public class WorldObject {
	[SerializeField]
	private GameObject gameObject;
	[SerializeField]
	private WorldObjectType type;
	[SerializeField]
	private int weight;

	public GameObject GetGameObject() {
		return this.gameObject;
	}

	public WorldObjectType GetObjectType() {
		return this.type;
	}

	public int GetWeight() {
		return this.weight;
	}
}
