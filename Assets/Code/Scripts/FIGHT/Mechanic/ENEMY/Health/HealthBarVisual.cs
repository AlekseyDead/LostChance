using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarVisual : MonoBehaviour {

	public float maxHeals;
	public Texture HealsTexture;

	private float BarWidth;
	private float realHeals;
	private float TextureWidth;
	private float hlep;

	void Start () 
	{
		BarWidth = Screen.width / 3;
		realHeals = maxHeals;
		TextureWidth  = BarWidth;   
		hlep = TextureWidth;
	}




	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width / 2 - hlep/2 , 10, BarWidth, 40), realHeals + " for " + maxHeals);

		if(HealsTexture != null && TextureWidth > 0)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2 - hlep/2, 30, TextureWidth, 15), HealsTexture, ScaleMode.ScaleAndCrop, true, 10.0f);
		}
	}


	void Update()
	{
		
	}

	public void DamageOnEnemy()
	{



		  
		realHeals = realHeals - 10;
		TextureWidth = BarWidth * (realHeals / maxHeals);

	}



}
