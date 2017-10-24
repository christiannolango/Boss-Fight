using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour {
	private float damage = -10;
	public Animator kagAnim;
	GameObject enemy;
	public bool checker = false;
	public void start(){
		kagAnim = kagAnim.GetComponent<Animator> ();

	}
	// Use this for initialization

	private void OnTriggerStay(Collider other){ //this might be better as OnTriggerStay while animation is playing
		if (kagAnim.GetCurrentAnimatorStateInfo (0).IsName ("Jab") == true && checker == false) {
			if (other.tag == "Enemy") {
				other.gameObject.GetComponent<EnemyHealth> ().TakeDamage (damage); //This line might cause a null reference exception
				Debug.Log(other.gameObject.GetComponent<EnemyHealth>().ReturnHealth() + " health");
				checker = true;
			} 
		}
		if (kagAnim.GetCurrentAnimatorStateInfo (0).IsName ("Jab") == false) {
			checker = false;
		}
	}
}
