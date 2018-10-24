using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionOfEnemyAttack: EnemyLines {



	void Start () {

		EnemyArrow = Resources.Load ("EnemyAttackArrow") as GameObject;

		endPos= Resources.Load ("II.AttackBorder") as GameObject;

		RStartPos= Resources.Load ("II.AttackBorder") as GameObject;

		CreateOfFightEndBlockPointAndLineAndColliderToLinesCreate (7);





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







	}










}






