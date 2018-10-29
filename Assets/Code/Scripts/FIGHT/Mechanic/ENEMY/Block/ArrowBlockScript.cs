using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBlockScript : MonoBehaviour {
	// Как долго существует лазер


	// Как быстро движется лазер
	private float speed = 2.2f;



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







		if ( other.tag == "FIGHTEndBlockPoint") 
		{ 
			

			GetComponentInParent<FunctionOfEnemyBlock> ().D565 = false;

			GetComponentInParent<FunctionOfEnemyBlock> ().TheEndOfBlockLine();
			int a=2;
			GameObject.Find("Skeleton").GetComponent<StandartAI>().EndOfAction(a);
			Destroy (gameObject);


		}








	}



}
