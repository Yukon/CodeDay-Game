using UnityEngine;
using System.Collections;

public class WorldGenerator {
	// Width and height of the world to generate
	private int worldSize;
	private WorldObject[] worldObjects;

	public WorldGenerator(int worldSize, WorldObject[] worldObjects) {
		this.worldSize = worldSize;
		this.worldObjects = worldObjects;
	}

	public void Generate() {
		for (int x = -worldSize; x < worldSize; x++) {
			for (int y = -worldSize; y < worldSize; y++) {
				float randomValue = Random.value;
				// 80% empty

				if (randomValue > 0.01 && randomValue < 0.02) {
					WorldObject[] astroids = GetObjects(WorldObjectType.Astroid);
					UnityEngine.Object.Instantiate(GetWorldObjectFromWeight(astroids).GetGameObject(), new Vector3(x, y, 0), Quaternion.identity);
				} else {

				}
			}
		}
	}

	public WorldObject[] GetObjects(WorldObjectType type) {
		ArrayList tempArray = new ArrayList();
		foreach (WorldObject worldObject in worldObjects) {
			if (worldObject.GetObjectType() == type) {
				tempArray.Add(worldObject);
			}
		}

		return (WorldObject[]) tempArray.ToArray(typeof(WorldObject));
	}

	public WorldObject GetWorldObjectFromWeight(WorldObject[] worldObjects) {
		ArrayList weightList = new ArrayList();
		int totalWeight = 0;

		foreach (WorldObject worldObject in worldObjects) {
			int weight =  worldObject.GetWeight();

			if (weight <= 0) {
				Debug.LogError("World object weight not greator then 0");
			}

			for (int i = 0; i < weight; i++) {
				weightList.Add(worldObject);
			}

			totalWeight += weight;
		}

		Debug.Log(Random.Range(0, totalWeight));

		return (WorldObject) weightList[Random.Range(0, totalWeight)];
	}
}
