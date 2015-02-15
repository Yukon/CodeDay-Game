using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public WorldObject[] worldObjects;

	void Awake() {
		WorldGenerator worldGen = new WorldGenerator(100, worldObjects);
		worldGen.Generate();
	}

	void Start() {
	}
}
