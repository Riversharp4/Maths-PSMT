using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    //Assign GameObject
	public GameObject Head;
	Vector3 Headscale = new Vector3(4, 16, 4);
    //Assigned GameObject's x value
    //Could be refined into a Vector3 
    //Use x,y,z coords to find volume and surface area
	float Headx;
	float testcircum = 34;
   
	//float for adding up sides, will eventually be returned
    //Used in RectprismSA
    public float runningtotal;

	// Use this for initialization
	void Start () 
	{
		string[,] PerfectRectPrismModel = { { "wl", "1" }, { "hl", "2" }, { "hw", "2" } };

		//Assigns GameObject's x value into corresponding variable
		Headx = Head.transform.localScale.x;
        //Debugging
		Debug.Log(Headx, Head);
		Debug.Log(Headscale);
		Debug.Log(cylinderSA(Headscale));
		Debug.Log(CylinderSA(Headscale.x, Headscale.y, CylinderCircleCount.one));
		Debug.Log(rectprismSA(Headscale));
		Debug.Log(RectprismSA(Headscale.x, Headscale.z, Headscale.y, PerfectRectPrismModel));
		Debug.Log(Circumference2Radius(testcircum));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float cubeSA(Vector3 xyz)
    {
		return 6 * Mathf.Pow(xyz.x, 2);
    }

	public float rectprismSA(Vector3 xyz)
    {
        //2(wl + hl + hw)
        // x = w  y = h  z = l
        return 2 * ((xyz.x * xyz.z) + (xyz.y * xyz.z) + (xyz.y * xyz.x));
    }

	public float cylinderSA(Vector3 xyz)
    {
        float r = xyz.x / 2;
        //2 * pi * r * (r + h)
		return (2 * Mathf.PI * r * xyz.y) + (2 * Mathf.PI * Mathf.Pow(r, 2));   
	}

	public enum CylinderCircleCount { one = 1, two = 2 };

    public float CylinderSA(float D, float h, CylinderCircleCount circleCount = CylinderCircleCount.two)
    {
        float r = D / 2;
        
        if ((int)circleCount == 1)
        {
            return (2 * Mathf.PI * r * h) + (Mathf.PI * Mathf.Pow(r, 2));
        }
        else
        {
            //2 * pi * r * h + 2 * pi * r^2
            return (2 * Mathf.PI * r * h) + (2 * Mathf.PI * Mathf.Pow(r, 2));
        }
    }

	public float RectprismSA(float l, float w, float h, string[,] rectprismModel)
    {
        //Wipe (possibly) dirty variable, better safe than sorry
        runningtotal = 0;

        if (rectprismModel[0, 0] == "wl")
        {
            //Parses array for float
            //This float is how many of the side "wl" is needed
            float wlAmount = float.Parse(rectprismModel[0, 1]);

            //(either 0/1/2) * (w * l)
            runningtotal += wlAmount * (w * l);
        }

        if (rectprismModel[1, 0] == "hl")
        {
            //Parses array for float
            //This float is how many of the side "hl" is needed
            float hlAmount = float.Parse(rectprismModel[1, 1]);

            //(either 0/1/2) * (h * l)
            runningtotal += hlAmount * (h * l);
        }

        if (rectprismModel[2, 0] == "hw")
        {
            //Parses array for float
            //This float is how many of the side "hl" is needed
            float hwAmount = float.Parse(rectprismModel[2, 1]);

            //(either 0/1/2) * (h * l)
            runningtotal += hwAmount * (h * w);
        }

        return runningtotal;
    }

	public float Circumference2Radius(float C)
    {
        //C / (2 * pi)
        return (C) / (2 * Mathf.PI);
    }
}
