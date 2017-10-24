using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public float currentHealth;
	public float maxHealth;

	void Start(){
		currentHealth = maxHealth;
	}

	void Update(){

		//This is just a way to test enemy death
		if (currentHealth == 0){
		Destroy (gameObject); 
		}
	}
		
	public void TakeDamage(float Amount){
		currentHealth += Amount;
	}
	public float ReturnHealth(){
		return currentHealth;
	}
}
