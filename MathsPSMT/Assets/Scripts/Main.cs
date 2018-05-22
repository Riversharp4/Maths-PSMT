using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main : MonoBehaviour {

	// x = w  y = h  z = l
   
    //Variables storing data for various body parts

    //Rectangular Prism
	public GameObject Head;
    //Array used in RectPrismSA Function - represents what sides are visible 
	public string[,] HeadRectPrismModel = { { "wl", "1" }, { "hl", "2" }, { "hw", "2" } };

    //Cylinder
	public GameObject Neck;
    //CylinderCircleCount.zero

    //Rectangular Prism
	public GameObject Torso;
    //Array used in RectPrismSA Function - represents what sides are visible 
	public string[,] TorsoRectPrismModel = { { "wl", "0" }, { "hl", "2" }, { "hw", "0" } };

    //Cylinder
	public GameObject LandRArm;
    //CylinderCircleCount.zero

    //Rectangular Prism
	public GameObject LandRHand;
    //Array used in RectPrismSA Function - represents what sides are visible 
    public string[,] LandRHandRectPrismModel = { { "wl", "2" }, { "hl", "2" }, { "hw", "1" } };

    //Cylinder
	public GameObject LandRLeg;
    //CylinderCircleCount.zero

    //Rectangular Prism
	public GameObject LandRFoot;
    //Array used in RectPrismSA Function - represents what sides are visible 
    public string[,] LandRFootRectPrismModel = { { "wl", "1" }, { "hl", "2" }, { "hw", "2" } };

	// Use this for initialization
	void Start () 
	{
        //float for adding up sides, will eventually be returned
        float runningtotal = 0;

        //Start surface area calculations
        //Head
        runningtotal += RectprismSA(Head.transform.localScale.z, Head.transform.localScale.x, Head.transform.localScale.y, HeadRectPrismModel);
        //Neck
        runningtotal += CylinderSA(Neck.transform.localScale.x, Neck.transform.localScale.y, CylinderCircleCount.zero);
        //In Between Neck and Head
        runningtotal += InBetweenSides(SquareA(Head.transform.localScale.z, Head.transform.localScale.x), CircleA(Neck.transform.localScale.x));
        //Torso
        runningtotal += RectprismSA(Torso.transform.localScale.z, Torso.transform.localScale.x, Torso.transform.localScale.y, TorsoRectPrismModel);
        //In Between Torso and Neck
        runningtotal += InBetweenSides(SquareA(Torso.transform.localScale.z, Torso.transform.localScale.x), CircleA(Neck.transform.localScale.x));
        //LandRArm
        runningtotal += 2 * CylinderSA(LandRArm.transform.localScale.x, LandRArm.transform.localScale.y, CylinderCircleCount.zero);
        //In Between Torso and Arms
        runningtotal += 2 * InBetweenSides(SquareA(Torso.transform.localScale.x, Torso.transform.localScale.y), CircleA(LandRArm.transform.localScale.x));
        //LandRHand
        runningtotal += 2 * RectprismSA(LandRHand.transform.localScale.z, LandRHand.transform.localScale.x, LandRHand.transform.localScale.y, LandRHandRectPrismModel);
        //LandRLeg
        runningtotal += 2 * CylinderSA(LandRLeg.transform.localScale.x, LandRLeg.transform.localScale.y, CylinderCircleCount.zero);
        //In Between Torso and Legs
        runningtotal += InBetweenSides(SquareA(Torso.transform.localScale.z, Torso.transform.localScale.x), 2 * CircleA(LandRLeg.transform.localScale.x));
        //LandRFoot
        runningtotal += 2 * RectprismSA(LandRFoot.transform.localScale.z, LandRFoot.transform.localScale.x, LandRFoot.transform.localScale.y, LandRFootRectPrismModel);
        //In Between Torso, Neck, Arms and Legs


        //Prints surface area to debug log
        Debug.Log("The total surface area is " + runningtotal + "cm² or " + runningtotal/10000 + "m².");

        runningtotal = 0;

        //Start volume calculations
        //Head
        runningtotal += RectprismV(Head.transform.localScale.z, Head.transform.localScale.x, Head.transform.localScale.y);
        //Neck
        runningtotal += CylinderV(Neck.transform.localScale.x, Neck.transform.localScale.y);
        //Torso
        runningtotal += RectprismV(Torso.transform.localScale.z, Torso.transform.localScale.x, Torso.transform.localScale.y);
        //LandRArm
        runningtotal += 2 * CylinderV(LandRArm.transform.localScale.x, LandRArm.transform.localScale.y);
        //LandRHand
        runningtotal += 2 * RectprismV(LandRHand.transform.localScale.z, LandRHand.transform.localScale.x, LandRHand.transform.localScale.y);
        //LandRLeg
        runningtotal += 2 * CylinderV(LandRLeg.transform.localScale.x, LandRLeg.transform.localScale.y);
        //LandRFoot
        runningtotal += 2 * RectprismV(LandRFoot.transform.localScale.z, LandRFoot.transform.localScale.x, LandRFoot.transform.localScale.y);

        Debug.Log("The total volume is " + runningtotal + "cm³ or " + runningtotal/1000000 + "m³.");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Maths Functions

    public float InBetweenSides(float sideA, float sideB)
    {
        //Makes sure that the answer will be positive
        if (sideA - sideB >= 0)
        {
            return sideA - sideB;
        }
        else
        {
            return sideB - sideA;
        }
    }

    public float SquareA(float l, float w)
    {
        //l * w
        return l * w;
    }

    public float CircleA(float D)
    {
        //finds radius from halving the diameter
        float r = D / 2;

        //pi * r^2
        return Mathf.PI * Mathf.Pow(r, 2);
    }

	public float CubeSA(float s, int visibleSides = 6)
	{
		//6(by default, unless otherwise) * s^2 
		return visibleSides * Mathf.Pow(s, 2);
	}

    public float CubeV(float s)
	{
		//s^3
		return Mathf.Pow(s, 3);
	}


	public float RectprismSA(float l, float w, float h, string[,] rectprismModel)
	{
        //float for adding up sides, will eventually be returned
        float runningtotal = 0;

		if (rectprismModel[0, 0] == "wl")
		{
			//Parses array for float
            //This float is how many of the side "wl" is needed
			float wlAmount = float.Parse(rectprismModel[0, 1]);

			//(either 0/1/2) * (w * l)
            //Adds this to runningtotal
			runningtotal += wlAmount * (w * l);
		}
        
		if (rectprismModel[1, 0] == "hl")
        {
            //Parses array for float
            //This float is how many of the side "hl" is needed
            float hlAmount = float.Parse(rectprismModel[1, 1]);

            //(either 0/1/2) * (h * l)
            //Adds this to runningtotal
            runningtotal += hlAmount * (h * l);
        }
        
		if (rectprismModel[2, 0] == "hw")
        {
            //Parses array for float
            //This float is how many of the side "hl" is needed
            float hwAmount = float.Parse(rectprismModel[2, 1]);

            //(either 0/1/2) * (h * w)
            //Adds this to runningtotal
            runningtotal += hwAmount * (h * w);
        }

		//returns the variable (answer)
		return runningtotal;
	}
   
    public float RectprismV(float l, float w, float h)
	{
		//l * w * h
		return l * w * h;
	}

    //Enum data types for amount of cylinder circles
	public enum CylinderCircleCount { zero = 0, one = 1 , two = 2 };

    public float CylinderSA(float D, float h, CylinderCircleCount circleCount = CylinderCircleCount.two)
	{
		//finds radius from halving the diameter
		float r = D / 2;

        //2 * pi * r * h + circleCount(how many circles are visible on cylinder) * pi * r^2
        return (2 * Mathf.PI * r * h) + ((float)circleCount * Mathf.PI * Mathf.Pow(r, 2));

	}

    public float CylinderV(float D, float h)
	{
		//finds radius from halving the diameter
		float r = D / 2;

		//pi * r^2 * h
		return Mathf.PI * Mathf.Pow(r, 2) * h;
	}

    public float SphereSA(float D)
	{
		//finds radius from halving the diameter
		float r = D / 2;

		//4 * pi * r^2
		return 4 * Mathf.PI * Mathf.Pow(r, 2);
	}

    public float SphereV(float D)
	{
		//finds radius from halving the diameter
        float r = D / 2;

		//(4 / 3) * pi * r^3
		return (4 / 3) * Mathf.PI * Mathf.Pow(r, 3);
	}

    public float Circumference2Radius(float C)
	{
		//C / (2 * pi)
		return (C) / (2 * Mathf.PI);
	}

    /*/// By Nikhila Gurusinghe ///*/
}
