using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseCity : MonoBehaviour {

    public GameObject buildingStarter; // The object we will use as the model for all our buldings

    public int width = 50; // How wide is the city in blocks?
    public int depth = 50; //How deep is the city in blocks?

    public int spacing = 2; //Spacing of bulding centers. Assumes buildings have a radius of 1

	// Use this for initialization
	void Start () {


        //Loop over the width and depth
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < depth; j++)
            {
                //Create a new building object at this position.

                int buildingX = (i - width / 2) * spacing; //Account for building spacing and center about the origin
                int buildingZ = (j - depth / 2) * spacing; ////Account for building spacing and center about the origin

                GameObject newBuilding = Instantiate(       //Create a new object
                    buildingStarter,                        //The object to instantiate
                    new Vector3(buildingX, 0, buildingZ),   //The location in world space of the building center
                    Quaternion.identity);                   //We don't want any rotation, hence we need just the identity quaternion

                //Now the actual noise part

                float xNoiseCoord = (i + 0) / 10.0f;
                float yNoiseCoord = (j + 0) / 10.0f;

                float noiseSample = Mathf.PerlinNoise(xNoiseCoord, yNoiseCoord) * 10;

                noiseSample *= noiseSample;

                newBuilding.transform.localScale = new Vector3(1, noiseSample, 1);
                newBuilding.transform.Translate(0, noiseSample / 2, 0);
            }
        }
		
	}
	
}
