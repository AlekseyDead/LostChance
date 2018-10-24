using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttackScript : MonoBehaviour {



	// Как быстро движется лазер
	public float speed = 15.1f;



	// Use this for initialization
	void Start () {
		// Уничтожение лазера по окончанию таймера

	}

	// Update is called once per frame
	void Update () {


		Vector2 a = new Vector2 (0,1);
		transform.Translate(a* Time.deltaTime * speed);
	}



	void OnTriggerEnter2D (Collider2D other)
	{

		if ( other.tag == "BLOCKLINE") 
		{ 


			GetComponentInParent<FunctionOfEnemyAttack>().D565 = false;


			GetComponentInParent<FunctionOfEnemyAttack>().TheForcedEndOfBlockLine();

			int a=1;
			GameObject.Find("Skeleton").GetComponent<StandartAI>().EndOfAction(a);
			Destroy (gameObject);


		}





		if ( other.tag == "FIGHTEndBlockPoint") 
		{ 


			GetComponentInParent<FunctionOfEnemyAttack>().D565 = false;
		

			GetComponentInParent<FunctionOfEnemyAttack>().TheEndOfBlockLine();

			int a=1;
			GameObject.Find("Skeleton").GetComponent<StandartAI>().EndOfAction(a);
			Destroy (gameObject);


		}








	}


		

}
