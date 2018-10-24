using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLineColiderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if ( other.tag == "BlockedAttackLineOfHero") 
		{ 
			GameObject.Find ("HH").GetComponent<HealthBarVisual> ().DamageOnEnemy (); 
			/// Вызываем в функшон оф атак скрипте метод уничтожения Линию Атаки
	

		}	
	}


}
