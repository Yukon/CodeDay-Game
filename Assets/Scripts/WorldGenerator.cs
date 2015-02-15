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
				int randomValue = Random.Range(0, 100);
				// 80% empty

				if (randomValue > 0 && randomValue < 10) {
					WorldObject[] astroids = GetObjects(WorldObjectType.Astroid);
					UnityEngine.Object.Instantiate(astroids[0].GetGameObject(), new Vector3(x, y, 0), Quaternion.identity);
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
}
