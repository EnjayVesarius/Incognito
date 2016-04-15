using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
	public bool requireKey;                     // Whether or not a key is required.

	private GameObject player;                  // Reference to the player GameObject.
	private bool isOpen = false;
	private float coolDown;

	public Vector3 openPosition;
	public Vector3 closePosition;

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
	}




	void OnCollisionEnter (Collision other)
	{
		// If the triggering gameobject is the player...
		if(other.gameObject == player)
		{
			// ... if this door requires a key...
			if (requireKey) {
				
			} else {
				if (isOpen && coolDown == 0.0f) {
					isOpen = false;
					coolDown = 1.0f;
				} else if (!isOpen && coolDown == 0.0f) {
					isOpen = true;
					coolDown = 1.0f;
				}
			}
		}
	}


	void OnTriggerExit (Collider other)
	{
	}


	void Update ()
	{
		if (isOpen && Vector3.Distance (this.transform.position, openPosition) > 0.1) {
			this.transform.position = Vector3.Lerp(this.transform.position, openPosition, 0.1f);
		} else if (!isOpen && Vector3.Distance (this.transform.position, closePosition) > 0.1f) {
			this.transform.position = Vector3.Lerp(this.transform.position, closePosition, 0.1f);
		}
		if(coolDown > 0)
			coolDown = Mathf.Clamp (coolDown - Time.deltaTime, 0.0f, 5.0f);
	}
}