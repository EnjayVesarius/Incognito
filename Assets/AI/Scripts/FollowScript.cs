using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class FollowScript : MonoBehaviour {

	private GameObject player;
	private NavMeshAgent meshAgent;

	// Use this for initialization
	void Start () {
		//Just storing our NavMeshAgent for speed
		meshAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		//We actually have a networked game, so we let's have the enemy chase the closest player
		float closestDistance = float.MaxValue;
		GameObject[] players = GameObject.FindGameObjectsWithTag("Untagged");
		GameObject closestPlayer = null;

		//C# has a foreach loop, can use it in this case
		foreach (GameObject player in players) {
			//Just get the distance between the player and the enemy without obstacles. It's a good enough (and fast) proxy
			float thisDistance = Vector3.Distance (player.transform.position, this.transform.position);
			if (thisDistance < closestDistance) {
				closestDistance = thisDistance;
				closestPlayer = player;
			}
		}	

		//This is what actually sets the enemy moving
		if (closestPlayer != null) {
			meshAgent.destination = closestPlayer.transform.position;
		}
	}
}
