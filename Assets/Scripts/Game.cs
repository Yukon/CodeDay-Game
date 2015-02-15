using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public WorldObject[] worldObjects;
	public int worldSize;

	void Awake() {
		WorldGenerator worldGen = new WorldGenerator(worldSize, worldObjects);
		worldGen.Generate();
	}

	void Start() {
	}
}
