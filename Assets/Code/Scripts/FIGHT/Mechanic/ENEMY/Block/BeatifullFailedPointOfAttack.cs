using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatifullFailedPointOfAttack : MonoBehaviour {



	bool D1=true;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame


	void FixedUpdate()
	{
		
	}
	void Update () {

		if (D1) {
			Vector2 a = new Vector2 (-1,-1);
			transform.Translate(a* Time.deltaTime * 55);
		}

		
	}


	void OnTriggerEnter2D (Collider2D other)
	{








		if ( other.tag == "EnemyBlock") 
		{ 




			D1 = false;


		}
	}

}
