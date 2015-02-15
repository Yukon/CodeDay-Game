using UnityEngine;

public class DestroyParticleSystemWhenFinished : MonoBehaviour {
	void Update() {
		if (!this.gameObject.particleSystem.IsAlive()) {
			Destroy(this.gameObject);
		}
	}
}