using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionOfEnemyBlock : EnemyLines{


	bool D1;

	// Use this for initialization
	void Start () {

		EnemyArrow=Resources.Load ("EnemyBlockArrow") as GameObject;

		endPos=Resources.Load ("II.BlockBorder") as GameObject;

		RStartPos=Resources.Load ("II.BlockBorder") as GameObject;

		CreateOfFightEndBlockPointAndLineAndColliderToLinesCreate (8);


	


	}

	// Update is called once per frame

	void Update () {



			if (D565) 
		   {
				float posX = ABCD.transform.position.x;
				float posY = ABCD.transform.position.y;
				line.SetPosition (1, new Vector3 (posX, posY, -1));
				ColliderToLinesUPDATE ();
			}



		CheckWithLinecast ();



	}



	void CheckWithLinecast()
	{
		

			var HIT = Physics2D.Linecast (startPos.transform.position, ABCD.transform.position, 2048); 



			if (HIT) {






				GameObject.Find ("MATH").GetComponent<FunctionOfAttack> ().FailedAttackLine ();
				//GameObject.Find ("MATH").GetComponent<FunctionOfAttack> ().NotRealEndOfHeroAttack ();



			}


	}



}






