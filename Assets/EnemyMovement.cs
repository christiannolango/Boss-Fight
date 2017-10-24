using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
	Transform player;
	NavMeshAgent nav; 
	public Animator drake;
	bool inCollider = false;

	void Awake ()
	{
		
		drake = drake.GetComponent<Animator> ();

		player = GameObject.FindGameObjectWithTag ("Player").transform;

		nav = GetComponent <NavMeshAgent> ();
	}


	void Update ()
	{
		if (inCollider == false) {
			drake.SetBool ("IsWalking",true);
			nav.SetDestination (player.position);
		} else {
			drake.SetBool ("IsWalking", false);
		}
	}
	private void OnTriggerEnter(Collider other){ 
		inCollider = true;
		if(other.tag == "Player"){
			drake.SetTrigger ("PlayerInCollider");
			}
	}
	private void OnTriggerExit(){
		inCollider = false;
	}
}
