using UnityEngine;
using System.Collections;

public class WorldGenerator {
	// Width and height of the world to generate
	private int worldSize;
	private WorldObject[] worldObjects;

	public WorldGenerator(int worldSize, WorldObject[] worldObjects) {
		this.worldSize = worldSize;
	}

	public void generate() {
		for (int x = -worldSize; x < worldSize; x++) {
			for (int y = -worldSize; y < worldSize; y++) {
				int randomValue = Random.Range(0, 100);
				/*
				if (randomValue = 0) {

				} else if (....
				*/
			}
		}
	}
}
