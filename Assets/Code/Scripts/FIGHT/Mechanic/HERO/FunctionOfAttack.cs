using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionOfAttack : MonoBehaviour {



	BoxCollider2D CurCol;



	public bool D899 = false; 

	/// <summary>
	/// The bug S killer.
	/// </summary>
	public GameObject BugSKiller;
	public	bool D1=false;
	bool D2=false;
	bool D3=false;
	bool D23=true;
	bool D4=false;
	bool D5 = true;
	bool D778 = true;


	int RNumberOfAttackSegments=2;
	int NumberOfAttackSegments;

	bool D25 = false;


	public bool D678 = false;
	/// <summary>
	/// The d777.
	/// </summary>
	public bool D777 = false;

	int i66=0;
	int i67=0;
	int i88=0;

	public Vector2 worldPos;

	float xD3;
	float yD3;

	float xD2;
	float yD2;

	float xD1;
	float yD1;

	float xD0;
	float yD0;

	float K;



	/// <summary>
	/// The C point.
	/// </summary>
	public GameObject CPoint;
	/// <summary>
	/// The end point.
	/// </summary>
	public GameObject EndPoint;

	/// <summary>
	/// The eenndd P pooiinntt.
	/// </summary>
	public GameObject EennddPPooiinntt;

	Vector3 CurrentFirstPoint;



	private LineRenderer line;

	public Vector3 startPos;    
	private Vector3 endPos;

	private GameObject[] COLES = new GameObject[10];


	// Use this for initialization
	void Start () {
		

	}






	// Update is called once per frame
	void Update () {

	
		StartAttack ();



	 	ATTACK ();
		

	    NonAttack ();

	}


	bool CheckForBlockWithCast()
	{


		Vector2 WWorldPos = Input.mousePosition;
		 WWorldPos = Camera.main.ScreenToWorldPoint (WWorldPos);


		Vector2 SStartPos = new Vector2 (startPos.x, startPos.y);
	



		//Debug.Log (SStartPos);
		//Debug.Log (WWorldPos);
		//Debug.Log (Physics2D.Linecast (SStartPos, WWorldPos));

		//Debug.DrawLine(SStartPos, WWorldPos);



		var HIT = Physics2D.Linecast(SStartPos, WWorldPos, 256); 



		if (HIT) 
		{



			if (HIT.collider.tag=="EnemyBlock") 
			{
				

				FailedAttackLine ();

				D678 = false;
				line.SetPosition (1, HIT.point);
				return false;
			}

		}







		//иф лайн.тэг = "EnemyBlock";


		


		return true;



		
	}
















	void ATTACK()
	{ 
		
			
		if (Input.GetKey (KeyCode.Mouse0)) 
		{



			


			if (D4) {

				if (CheckForBlockWithCast())
				{

					if (D678) {



			
						worldPos = Input.mousePosition;
						worldPos = Camera.main.ScreenToWorldPoint (worldPos);
						if (D5) {

							line.SetPosition (1, worldPos);

						}





						BuildingOfNumberSegments ();

						worldPos = Input.mousePosition;
						worldPos = Camera.main.ScreenToWorldPoint (worldPos);

					

						if (D23 == false) {

							xD0 = CurrentFirstPoint.x;
							yD0 = CurrentFirstPoint.y;
							xD1 = worldPos.x;
							yD1 = worldPos.y;





							if (Vector3.Distance (worldPos, CurrentFirstPoint) >= 1) {
				
								if (D3 == false) {



									LinearEquations ();

									line.SetPosition (1, worldPos);

									D3 = true;
									D5 = false;
									endPos = worldPos;
									ColliderToLines ();

									D4 = false;

								}
							}
						}
					}

			}

			}

		}

	}









	void StartAttack()
	{   if (D899) {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {


				NumberOfAttackSegments=RNumberOfAttackSegments;

				D678 = true;
				D25 = true;

				worldPos = Input.mousePosition;
				worldPos = Camera.main.ScreenToWorldPoint (worldPos);
			
				if (D1 == false) {
					D1 = true;



					GameObject CCPPooiinntt = Instantiate (CPoint, new Vector2 (worldPos.x, worldPos.y), Quaternion.identity);

					EennddPPooiinntt = Instantiate (EndPoint, new Vector2 (xD3, yD3), Quaternion.identity);

					EennddPPooiinntt.GetComponent<DestroyingOfPoints> ().FRIS [i66] = CCPPooiinntt;



					i66++;

					xD0 = worldPos.x;
					yD0 = worldPos.y;



					CurrentFirstPoint = worldPos;
					createLine ();

					line.SetPosition (0, worldPos);
					line.SetPosition (1, worldPos);



					startPos = worldPos;
					D4 = true;


				}


			}

		}
	}




	void LinearEquations()
	{

		xD2 = xD1 - xD0;
		yD2 = yD1 - yD0;


		if (xD2 != 0) {

			K = yD2 / xD2;
		}

		//1=x2+y2
		//y=kx

		if (xD2 == 0) {

			xD3 = xD0;


			if (yD2 > 0) {


				yD3 = 1;
			} else {
				yD3 = -1;

			}

		}

		else 
		{

		if (xD2 > 0) {
			xD3 = Mathf.Sqrt (1 / (Mathf.Pow (K, 2) + 1));

			yD3=K*xD3;
			xD3+=xD0;

		} else {
			xD3 = -Mathf.Sqrt (1 / (Mathf.Pow (K, 2) + 1));

			yD3=K*xD3;
			xD3+=xD0;
		}

		}

		yD3+=yD0;

		worldPos.x = xD3;
		worldPos.y = yD3;
		GameObject CCPPooiinntt=Instantiate (CPoint, new Vector2 (xD3, yD3), Quaternion.identity);  
 	    EennddPPooiinntt.GetComponent<DestroyingOfPoints> ().FRIS[i66]=CCPPooiinntt;
		i66++;

		CurrentFirstPoint = worldPos;
	}




	void NonAttack()
	{



		if (D25) {

			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				GameObject BugKiller = Instantiate (BugSKiller);
				Destroy (BugKiller, 0.1f);
				D1 = false;
				D2 = false;
				D3 = false;
				D4 = false;
				D23 = true;
				D5 = true;
				D678 = false;
				EndOfHeroAttack ();
				KillingOfPoints ();
				D25 = false;




			}
		}
	}



	void KillingOfPoints()
	{    
		i66 = 0;
		i67 = 0;
	EennddPPooiinntt.GetComponent<DestroyingOfPoints> ().DIEDIEDIE ();
	//ссылка на точку и по ней запускается функция на точке
	///Так ну для начала - нужно проверить, - просто тупо здесь как бы создаётся 
    /// Иф удар прошёл - запускается это функция (в ней хранятся ссылки на последние созданные точки)
    /// Смотрится по какой линии прошёл удар - удаляется соответствующая созданная точка
	}



	// Following method creates line runtime using Line Renderer component
	private void createLine()
	{   
		GameObject fine=new GameObject ("LineWithBox");
		line = fine.AddComponent<LineRenderer>();
		line.material = GameObject.Find ("MATH").GetComponent<LineRenderer> ().material;
		line.positionCount=2;

		line.startWidth=0.06f;
		line.endWidth=0.06f;
		line.startColor = GameObject.Find ("MATH").GetComponent<LineRenderer> ().startColor;
		line.endColor = GameObject.Find ("MATH").GetComponent<LineRenderer> ().endColor;
	
		line.useWorldSpace = true;
		line.sortingLayerName ="FirstFront";


		GameObject LineWithBox = fine;
 		EennddPPooiinntt.GetComponent<DestroyingOfPoints> ().FRIS2[i67]=LineWithBox;
		i67++;

	}



	private void ColliderToLines()
	{


		GameObject RealColider = new GameObject();
		BoxCollider2D col = RealColider.AddComponent<BoxCollider2D> ();
		RealColider.layer = 11;
		col.transform.parent = line.transform; // Collider is added as child object of line
		float lineLength = Vector3.Distance (startPos, endPos); // length of line
		col.size = new Vector3 (lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		Vector3 midPoint = (startPos + endPos) / 2;
		col.transform.position = midPoint; // setting position of collider object
		// Following lines calculate the angle between startPos and endPos
		float angle = (Mathf.Abs (startPos.y - endPos.y) / Mathf.Abs (startPos.x - endPos.x));
		if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x)) {
			angle *= -1;
		}
		angle = Mathf.Rad2Deg * Mathf.Atan (angle);
		col.transform.Rotate (0, 0, angle);

		COLES [i88] = RealColider;
		i88++;


	}





	private void EndOfHeroAttack()
	{

		for (int i99 = 0; i99 < i88; i99++) {
			
	

	        
			GameObject RealColiderOfHeroAttack;
			RealColiderOfHeroAttack=Instantiate (COLES[i99]);
			RealColiderOfHeroAttack.tag="LINE";
			Destroy (RealColiderOfHeroAttack,1);
			COLES [i99].layer = 0;
		}
		i88 = 0;



	}


	//public void NotRealEndOfHeroAttack()
	//{
	//	for (int i99 = 0; i99 < i88; i99++) {
	//
	//		COLES [i99].layer = 0;
	//	}
	//	i88 = 0;
	//}




	/// <summary>
	/// Faileds the attack line.
	/// </summary>
	public void FailedAttackLine()
	{

		GameObject BugKiller = Instantiate (BugSKiller);
		Destroy (BugKiller, 0.1f);
		D1 = false;
		D2 = false;
		D3 = false;
		D4 = false;
		D23 = true;
		D5 = true;

		KillingOfPoints ();
		D25 = false;
		i88 = 0;

	}




	private void BuildingOfNumberSegments()
	{

		if (NumberOfAttackSegments == 0) {
			D23 = false;
		}
		else
		{
			

		if (Vector3.Distance (worldPos, CurrentFirstPoint) >= 1) {
				xD0 = CurrentFirstPoint.x;
				yD0 = CurrentFirstPoint.y;
				xD1 = worldPos.x;
				yD1 = worldPos.y;

				if (D778)
				{
					D778 = false;


					if (D2 == false) {
						


						NumberOfAttackSegments--;
						LinearEquations ();









						line.SetPosition (1, worldPos);
						endPos = worldPos;
						ColliderToLines ();
						createLine ();
						line.SetPosition (0, worldPos);
						line.SetPosition (1, worldPos);
						startPos = worldPos;
						D778 = true;



					}

				}
			}
		}
	}





	///Кароч ИФ Игрок тыкнул на кнопку атаки и начинает проводить пальцем, то включается функция создания штриха, если штрих поражает противника, то ему наносится урон
	///В точке нажатия ЛКМ создаётся первая точка, мы постоянно отслеживаем курсор мыши, как только он достигает опр. длины - мы



}
