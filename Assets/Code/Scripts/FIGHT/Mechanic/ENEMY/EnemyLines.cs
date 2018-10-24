using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyLines : MonoBehaviour {




	protected LineRenderer line;

	public GameObject ABCD;

	public bool D565 = true;





	public GameObject EnemyArrow;

 	public GameObject endPos;

	public GameObject RStartPos;



	private GameObject startPos;   

	private GameObject go;

	private GameObject SADD ;

	private BoxCollider2D col;
	 
	private int RealColliderLayer;



	// Use this for initialization
	void Start () {



		//CreateOfFightEndBlockPointAndLineAndColliderToLinesCreate (RealColliderLayer);

	}
	
	// Update is called once per frame
	void Update () {

		//if (D565) 
		//{
		//	float posX = ABCD.transform.position.x;
		//	float posY = ABCD.transform.position.y;
		//	line.SetPosition (1, new Vector3 (posX, posY, -1));
		//	ColliderToLinesUPDATE ();
		//}
		
	}









	protected void CreateOfFightEndBlockPointAndLineAndColliderToLinesCreate (int ColliderLayer) ////Создание второго края линии на основе первого
	{
		startPos = Instantiate (RStartPos, this.transform);

		go = Instantiate (endPos, startPos.transform.position, startPos.transform.rotation, startPos.transform);

		go.tag = "FIGHTEndBlockPoint";

		go.transform.localPosition = new  Vector2(2,0);          ///Создаём вторую границу

		createLine (ColliderLayer);
	}

	private void createLine(int ColliderLayer)
	{

		line = new GameObject("Line").AddComponent<LineRenderer>();
		line.transform.parent=gameObject.transform;
		line.material = GameObject.Find ("MATH").GetComponent<LineRenderer> ().material;
		line.positionCount=2;

		line.startWidth=0.06f;
		line.endWidth=0.06f;
		line.startColor = Color.blue;
		line.endColor = Color.gray;

		line.useWorldSpace = true;
		line.sortingLayerName ="FRONT";

		ColliderToLinesCREATE (ColliderLayer);
	}

	private void ColliderToLinesCREATE(int ColliderLayer)
	{




		GameObject KO = new GameObject ("ColliderWithScript");
		KO.layer = ColliderLayer;

		KO.AddComponent<Rigidbody2D> ();
		KO.GetComponent<Rigidbody2D>().gravityScale=0;
		KO.GetComponent<Rigidbody2D> ().collisionDetectionMode=CollisionDetectionMode2D.Continuous;

		col = KO.AddComponent<BoxCollider2D> ();
		col.isTrigger = true;

		col.transform.parent = line.transform; // Collider is added as child object of line

		Vector3 midPoint = (startPos.transform.position + go.transform.position) / 2;
		col.transform.position = midPoint; // setting position of collider object
		// Following lines calculate the angle between startPos and endPos
		float angle = (Mathf.Abs (startPos.transform.position.y - go.transform.position.y) / Mathf.Abs (startPos.transform.position.x - go.transform.position.x));
		if ((startPos.transform.position.y < go.transform.position.y && startPos.transform.position.x > go.transform.position.x) || (go.transform.position.y < startPos.transform.position.y && go.transform.position.x > startPos.transform.position.x)) {
			angle *= -1;
		}
		angle = Mathf.Rad2Deg * Mathf.Atan (angle);
		col.transform.Rotate (0, 0, angle);

		col.tag = "EnemyBlock";

		EnemyBlockMain ();
	}

	void EnemyBlockMain()
	{

		float posX = startPos.transform.position.x;
		float posY = startPos.transform.position.y;

		var SF = startPos.transform.eulerAngles;

		SF.z += -90;

		Quaternion SD = Quaternion.Euler (SF);

		ABCD=Instantiate (EnemyArrow, new Vector3(posX, posY, -1), SD, this.gameObject.transform);

		line.SetPosition(0,new Vector3(posX, posY, -1)) ;
		line.SetPosition(1,new Vector3(posX, posY, -1)) ;


	}

	protected void ColliderToLinesUPDATE()
	{


		float lineLength = Vector2.Distance (startPos.transform.position, ABCD.transform.position); // length of line
		col.size = new Vector2 (lineLength, 0.1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		Vector3 midPoint = (startPos.transform.position + ABCD.transform.position) / 2;
		col.transform.position = midPoint; // setting position of collider object
		// Following lines calculate the angle between startPos and endPos



		float angle = (Mathf.Abs (startPos.transform.position.y - go.transform.position.y) / Mathf.Abs (startPos.transform.position.x - go.transform.position.x));
		if ((startPos.transform.position.y < go.transform.position.y && startPos.transform.position.x > go.transform.position.x) || (go.transform.position.y < startPos.transform.position.y && go.transform.position.x > startPos.transform.position.x)) {
			angle *= -1;
		}
		angle = Mathf.Rad2Deg * Mathf.Atan (angle);








		Vector3 SF = new Vector3(0,0,0);
		SF.z =angle;
		Quaternion SD = Quaternion.Euler (SF);



		col.transform.rotation = SD;


	}


	public void TheEndOfBlockLine()
	{

		line.SetPosition (1, new Vector3 (go.transform.position.x, go.transform.position.y, -1)); 
		Invoke("DestroyOfBordersLines", 0.25F);


	}
	public void TheForcedEndOfBlockLine()
	{


		Invoke("DestroyOfBordersLines", 0.1F);


	}



	private void DestroyOfBordersLines()
	{
		Destroy(gameObject);
	}


}
