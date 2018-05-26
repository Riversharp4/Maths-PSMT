
# Maths PSMT

Welcome to the landing page for my Maths PSMT, you can find the link to the [GitHub repository here](https://github.com/Riversharp4/Maths-PSMT) and the link to the [program here](https://github.com/Riversharp4/Maths-PSMT/blob/master/MathsPSMT/Assets/Scripts/Main.cs) and also the full explanation for the program below because I wanted to save some trees.

# Explanation of Program

As mentioned before the model is graphically created in the physics engine [Unity](https://unity3d.com/). This also means that the calculations for this model could also be conducted within Unity, via a script written by me in the programming language [C#](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)), allowing for very high precision. The program has 3 major parts, initial [variables](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables), the [Start function](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html) and the explicitly named Maths [functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods).

## Maths Functions

Let’s start with the Maths function which calculates the surface area of a rectangular prism with the ability to dynamically add or remove sides from the prism. This [function](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods) named *RectprismSA* will return a [float](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/float), which is a high precision data type storing a floating-point number.

```csharp
// Function for finding the surface area of a rectangular prism
public float RectprismSA(float l, float w, float h, string[,] rectprismModel)
```

### RectprismSA

The functions parameters are the floats *l* (length), *w* (width), *h* (height) and a [multidimensional array](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays) of 2 dimensions called *rectprismModel*. This multidimensional array stores 3 pairs with one set of these pairs representing the 3 possible side combinations on a rectangular prism (*wl*, *hl* and *hw*). The other pair stores a number indicating how much of the corresponding side is actually needed in the final calculation. Below is an example of such an array named in the initial variables.

```csharp
// Array used in RectPrismSA Function - represents what sides are visible 
public string[,] HeadRectPrismModel = { { "wl", "1" }, { "hl", "2" }, { "hw", "2" } };
```

This two dimensional array represents a perfect rectangular prism, except it only has one width by length side. The next step is naming a variable of the datatype float called *runningtotal*.

```csharp
// float for adding up sides, will eventually be returned
float runningtotal = 0;
```

This will eventually be returned as required by the function. Next a conditional called an [if-else statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/if-else) checks the two dimensional array’s first pair for a string called *wl* from the first dimension.

```csharp
// if-else statement check for string in multidimensional array
if (rectprismModel[0, 0] == "wl")
```

After that the second dimension’s contents is [“parsed”](https://docs.microsoft.com/en-us/dotnet/api/system.single.parse?view=netframework-4.7.1) (In this context parsing is the process of turning a string into a float). This value is then applied to the newly named float variable *wlAmount*. Thus making *wlAmount* equal to the parsed value.

```csharp
// Parses array for float
// This float is how many of the side "wl" is needed
float wlAmount = float.Parse(rectprismModel[0, 1]);
```

Then *wlAmount* is multiplied by the product of the parameters *w* (width) and *l* (length). The total is then added to variable *runningtotal*.

```csharp
// (either 0/1/2) * (w * l)
// Adds this to runningtotal
runningtotal += wlAmount * (w * l);
```

This process then repeats for the sides *hl* and *hw*.

```csharp
if (rectprismModel[1, 0] == "hl")
{
    // Parses array for float
    // This float is how many of the side "hl" is needed
    float hlAmount = float.Parse(rectprismModel[1, 1]);

    // (either 0/1/2) * (h * l)
    // Adds this to runningtotal
    runningtotal += hlAmount * (h * l);
}
        
if (rectprismModel[2, 0] == "hw")
{
    // Parses array for float
    // This float is how many of the side "hl" is needed
    float hwAmount = float.Parse(rectprismModel[2, 1]);

    // (either 0/1/2) * (h * w)
    // Adds this to runningtotal
    runningtotal += hwAmount * (h * w);
}
```

Finally the *runningtotal* is returned by the function using the keyword [return](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/return). Ending and destroying this function.

```csharp
// returns the variable (answer)
return runningtotal;
```

### CylinderSA

The next function that is used is *CylinderSA*, which calculates the surface area of a cylinder with the ability to remove the two circles found at each end of a cylinder. Before we name this function we have to create an [enumeration](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/enum) which contains a list referred to as the enumerator list. This list contains multiple explicitly named constants. In this program I used an enumeration called *CylinderCircleCount* with the enumerator list which denotes the possible number of circles found on a cylinder, either *zero*, *one* or *two*.

```csharp
// Enum data types for amount of cylinder circles
public enum CylinderCircleCount { zero = 0, one = 1 , two = 2 };
```

Next is the function declaration or signature line of the function that will calculate the surface area of a cylinder named *CylinderSA*. This function also has parameters similar to the function *RectprismSA*, the parameters are different in this case. The first parameter is the float *D* (diameter), next is the float *h* (height), then a parameter called *circleCount* with the datatype being the enumerator *CylinderCircleCount*. This final parameter is different to any others as it has a default value that the parameter will default to if no other variable is supplied. In this case the default value is from the enumerator list above, specifically *two*, which represents the amount of circles a cylinder normally has.

```csharp
// Function for finding the surface area of a cylinder
public float CylinderSA(float D, float h, CylinderCircleCount circleCount = CylinderCircleCount.two)
```

The next step is to find the radius with the diameter, which is done by halving the parameter *D* then assigning the resulting value to a float variable with the identifier *r* (radius).

```csharp
// finds radius from halving the diameter
float r = D / 2;
```

Then an expanded surface area formula for a cylinder is followed. The only real difference being that instead of finding the area of two cylinders the program will find the area of whatever *circleCount* is equal to in float form. Then the resultant float is returned. Also the radius is substituted from the variable *r*.

```csharp
// 2 * pi * r * h + circleCount(how many circles are visible on cylinder) * pi * r^2
return (2 * Mathf.PI * r * h) + ((float)circleCount * Mathf.PI * Mathf.Pow(r, 2));
```

Small side note *Mathf.PI* represents pi in float form, and *Mathf.Pow(r, 2)* represents *r* to the power of 2.

```csharp
// represents pi in float form
Mathf.PI

// represents r²
Mathf.Pow(r, 2)
```

## Initial Variables

Initial variables are name at the top below the class declaration. [Variables](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables) allocate system Random Access Memory (RAM or Memory) ready for data to be stored in this allocated space. Variables need a [datatype](http://www.tutorialsteacher.com/csharp/csharp-data-types) and an identifier or name. In the model that I have created every rectangular prism requires a two dimensional string (a string is an array of unicode characters) array to be initialised, these are initialised with the variables. Unity’s proprietary datatype [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) represents a lot of data including a GameObject’s dimensions in physical (virtual) space. We need this in order to dynamically calculate surface area and volume on the fly. This is why every component that is being utilised in my model has a variable of the datatype GameObject. Below are these initial variables and accompanying two dimensional arrays.

```csharp
// Variables storing data for various body parts

// Rectangular Prism
public GameObject Head;
// Array used in RectPrismSA Function - represents what sides are visible 
public string[,] HeadRectPrismModel = { { "wl", "1" }, { "hl", "2" }, { "hw", "2" } };

// Cylinder
public GameObject Neck;
// CylinderCircleCount.zero

// Rectangular Prism
public GameObject Torso;
// Array used in RectPrismSA Function - represents what sides are visible 
public string[,] TorsoRectPrismModel = { { "wl", "0" }, { "hl", "2" }, { "hw", "0" } };

// Cylinder
public GameObject LandRArm;
// CylinderCircleCount.zero

// Rectangular Prism
public GameObject LandRHand;
// Array used in RectPrismSA Function - represents what sides are visible 
public string[,] LandRHandRectPrismModel = { { "wl", "2" }, { "hl", "2" }, { "hw", "1" } };

// Cylinder
public GameObject LandRLeg;
// CylinderCircleCount.zero

// Rectangular Prism
public GameObject LandRFoot;
// Array used in RectPrismSA Function - represents what sides are visible 
public string[,] LandRFootRectPrismModel = { { "wl", "1" }, { "hl", "2" }, { "hw", "2" } };
```

## The Start Function

The [Start function](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html) is the entry point for the compiler, similar to the [Main function](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/) in a terminal or command prompt project. When the program is run it will only execute anything found in the Start function (and also the [Update function](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html) but that is irrelevant). Nothing else in the program will execute by itself. To utilise functions such as *RectprismSA* or *CylinderSA* they first need to be called from the Start function. In the Start function there are two major blocks of code, one calculates the total surface area then prints it to [Unity’s debug log](https://docs.unity3d.com/ScriptReference/Debug.Log.html).

```csharp
// float for adding up sides, will eventually be returned
float runningtotal = 0;

// float for surface area used in surface area to volume calculations
float sa = 0;

// float for volume used in surface area to volume calculations
float v = 0;

// Start surface area calculations
// Head
runningtotal += RectprismSA(Head.transform.localScale.z, Head.transform.localScale.x, Head.transform.localScale.y, HeadRectPrismModel);
// Neck
runningtotal += CylinderSA(Neck.transform.localScale.x, Neck.transform.localScale.y, CylinderCircleCount.zero);
// In Between Neck and Head
runningtotal += InBetweenSides(SquareA(Head.transform.localScale.z, Head.transform.localScale.x), CircleA(Neck.transform.localScale.x));
// Torso
runningtotal += RectprismSA(Torso.transform.localScale.z, Torso.transform.localScale.x, Torso.transform.localScale.y, TorsoRectPrismModel);
// In Between Torso and Neck
runningtotal += InBetweenSides(SquareA(Torso.transform.localScale.z, Torso.transform.localScale.x), CircleA(Neck.transform.localScale.x));
// LandRArm
runningtotal += 2 * CylinderSA(LandRArm.transform.localScale.x, LandRArm.transform.localScale.y, CylinderCircleCount.zero);
// In Between Torso and Arms
runningtotal += 2 * InBetweenSides(SquareA(Torso.transform.localScale.x, Torso.transform.localScale.y), CircleA(LandRArm.transform.localScale.x));
// LandRHand
runningtotal += 2 * RectprismSA(LandRHand.transform.localScale.z, LandRHand.transform.localScale.x, LandRHand.transform.localScale.y, LandRHandRectPrismModel);
// LandRLeg
runningtotal += 2 * CylinderSA(LandRLeg.transform.localScale.x, LandRLeg.transform.localScale.y, CylinderCircleCount.zero);
// In Between Torso and Legs
runningtotal += InBetweenSides(SquareA(Torso.transform.localScale.z, Torso.transform.localScale.x), 2 * CircleA(LandRLeg.transform.localScale.x));
// LandRFoot
runningtotal += 2 * RectprismSA(LandRFoot.transform.localScale.z, LandRFoot.transform.localScale.x, LandRFoot.transform.localScale.y, LandRFootRectPrismModel);
// In Between Torso, Neck, Arms and Legs

// Prints surface area to debug log
Debug.Log("The total surface area is " + runningtotal + "cm² or " + runningtotal/10000 + "m².");

// Assigns runningtotal's value to the variable sa (surface area)
sa = runningtotal;
```

The other block calculates the total volume then prints it to the debug log.

```csharp
runningtotal = 0;

// Start volume calculations
// Head
runningtotal += RectprismV(Head.transform.localScale.z, Head.transform.localScale.x, Head.transform.localScale.y);
// Neck
runningtotal += CylinderV(Neck.transform.localScale.x, Neck.transform.localScale.y);
// Torso
runningtotal += RectprismV(Torso.transform.localScale.z, Torso.transform.localScale.x, Torso.transform.localScale.y);
// LandRArm
runningtotal += 2 * CylinderV(LandRArm.transform.localScale.x, LandRArm.transform.localScale.y);
// LandRHand
runningtotal += 2 * RectprismV(LandRHand.transform.localScale.z, LandRHand.transform.localScale.x, LandRHand.transform.localScale.y);
// LandRLeg
runningtotal += 2 * CylinderV(LandRLeg.transform.localScale.x, LandRLeg.transform.localScale.y);
// LandRFoot
runningtotal += 2 * RectprismV(LandRFoot.transform.localScale.z, LandRFoot.transform.localScale.x, LandRFoot.transform.localScale.y);

// Prints surface area to debug log
Debug.Log("The total volume is " + runningtotal + "cm³ or " + runningtotal/1000000 + "m³.");


// Assigns runningtotal's value to the variable v (volume)
v = runningtotal;
```

Total surface area and volume is calculated by running functions like *RectprismSA*. This function can calculate the surface area of a rectangular prism when supplied with data from the initial variables such as GameObjects and multidimensional arrays which are passed into the function as parameters. The function *InBetweenSides* fills in the gaps that were left out by functions such as *RectprismSA*.

```csharp
// Takes away the area of sideA from the area of sideB with the answer always being positive
public float InBetweenSides(float sideA, float sideB)
{
    // Makes sure that the answer will be positive
    if (sideA - sideB >= 0)
    {
        return sideA - sideB;
    }
    else
    {
        return sideB - sideA;
    }
}
```

All these calculations are then added to the variable *runningtotal* which is then printed to the debug log, where the final value can be seen. A similar process runs for the volume calculations but with different functions, which calculate volume instead of surface area.

To work out the surface area to volume value, the surface area variable named at the very top of the start function and the similar volume variable area divided together. This float arithmitic results in the surface area to volume value.

```csharp
// float for surface area used in surface area to volume calculations
float sa = 0;

// sa being changed to the surface area shortly after that block of calculation
sa = runningtotal;

// float for volume used in surface area to volume calculations
float v = 0;

// v being changed to the volume shortly after that block of calculation  
v = runningtotal;

// Surface area to volume value = SA / V
Debug.Log("The surface area to volume value is " + sa / v + ".");
```
This final answer is then displayed in the debug log.

Made with :heart: by,

```csharp
/* // Nikhila Gurusinghe // */
```