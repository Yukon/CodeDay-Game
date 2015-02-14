using UnityEngine;

[System.Serializable]
public class WorldObject {
	enum WorldObjectType {
		Astroid,
		Ship
	}

	[SerializeField]
	private GameObject gameObject;
	[SerializeField]
	private WorldObjectType type;
	[SerializeField]
	private float weight;
}