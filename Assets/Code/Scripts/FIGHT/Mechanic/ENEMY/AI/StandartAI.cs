using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartAI : MonoBehaviour {

	private float AttackCouldownReal = 2f;
	private float BlockCouldownReal = 2f;

	private float AttackCouldown = 0.0f;
	private float BlockCouldown = 0.0f;

	private bool D1=true; //Отвечает за то, что в данный момент происходит какое-либо действие противника.
	private bool D2=false; //Отвечает за то, что в данный момент герой атакует

	Vector2 FODOH2;
	Vector2 FODOH1;

	public GameObject AreaOfEnemyColider1;
	public GameObject AreaOfEnemyColider2;
	public GameObject AreaOfEnemyColider3;

	public GameObject AttackPoint1;
	public GameObject StartAttackBorder;
	public GameObject BlockPoint1;
	public GameObject StartBlockBorder;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		if ((AttackCouldown<=0) && (D1))
		{  
			D1 = false;


			DoAttack();



		}


		if (GameObject.Find ("MATH").GetComponent<FunctionOfAttack> ().D678 == true) {
			D2 = true;
			//врубаем метод по нахождению того куда бьёт игрок.


		} else {
			D2 = false;
		}



		if ((AttackCouldown > 0) && (BlockCouldown<=0) && (D2)&& (D1))
		{   



			FindOfDirectionOfHeroAttack ();

		

		}


		if ((AttackCouldown > 0) && (BlockCouldown<=0) && (AttackCouldown <=1) && (D1))
		{   


			D1 = false;

			DoBlock ();

		}






		///Сброс кулдаунов

		if (AttackCouldown>0) 
		{
			AttackCouldown -= Time.deltaTime;
			
		}


		if (BlockCouldown>0) 
		{
			
			BlockCouldown -= Time.deltaTime;
		}




		
	}



	void DoAttack()
	{


		Instantiate (StartAttackBorder, AttackPoint1.transform.position, AttackPoint1.transform.rotation);

		///У нас есть 2 точки атаки предположим
		/// Рандомно или нет выбираем одну из 2 точек
		/// Создаём в этой точке объект




	}

	void DoBlock()
	{




		Instantiate (StartBlockBorder, BlockPoint1.transform.position, BlockPoint1.transform.rotation);




	}




	public void EndOfAction(int total)
	{


		if (total==1)
		{

			AttackCouldown = AttackCouldownReal;
		}

		if (total==2)
		{

			BlockCouldown = BlockCouldownReal;
		}

		Vector3 ab= new Vector3 (-2,0,0);
	

		D1 = true;
	}



	public void FindOfDirectionOfHeroAttack()
	{

			
		FODOH2=GameObject.Find ("MATH").GetComponent<FunctionOfAttack> ().worldPos;

		FODOH1=GameObject.Find ("MATH").GetComponent<FunctionOfAttack> ().startPos;


		FODOH2=FODOH2-FODOH1;


		var HIT = Physics2D.Raycast(FODOH1, FODOH2 , 10f);

		Debug.Log (FODOH1);
		Debug.Log (FODOH2);




		Debug.Log (HIT.collider.name);

		if (HIT) 
		{



			if (HIT.collider.name=="AreaOfEnemyColider1") 
			{


				Instantiate (StartBlockBorder, AreaOfEnemyColider1.transform.position, AreaOfEnemyColider1.transform.rotation);
				D1 = false;


			}
			if (HIT.collider.name=="AreaOfEnemyColider2") 
			{


				Instantiate (StartBlockBorder, AreaOfEnemyColider2.transform.position, AreaOfEnemyColider2.transform.rotation);
				D1 = false;


			}
			if (HIT.collider.name=="AreaOfEnemyColider3") 
			{


				Instantiate (StartBlockBorder, AreaOfEnemyColider3.transform.position, AreaOfEnemyColider3.transform.rotation);
				D1 = false;


			}




		}




	}




			

   

}
