using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		GameObject.Find ("MATH").GetComponent<FunctionOfAttack> ().D899 = true;
		GameObject.Find ("BlockMath").GetComponent<FunctionOfBlock> (). D899 = false;
	}
}
