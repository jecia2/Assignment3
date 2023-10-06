using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour
{
    public GameObject outCorner;
    public GameObject inCorner;
    public GameObject inWall;
    public GameObject outWall;
    public GameObject tJunct;
    public GameObject pellet;
    public GameObject powerpellet;
    int[,] levelMap =
 {
 {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
 {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
 {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
 {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
 {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
 {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
 {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
 {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
 {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
 {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
 {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
 {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
 {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
 {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
 {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
 };
    /*0 – Empty (do not put anything here, no sprite needed)
1 - Outside corner (double lined corner piece in original game)
2 - Outside wall (double line in original game)
3 - Inside corner (single lined corner piece in original game)
4 - Inside wall (single line in original game)
5 – An empty space with a Standard pellet (see Visual Assets above)
6 – An empty space with a Power pellet (see Visual Assets above)
7 - A t junction piece for connecting with adjoining regions*/
    // Start is called before the first frame update
    void Start()
    {
        //hide the original map (bad now cause i added way more)
       /* outCorner.SetActive(false);
        inCorner.SetActive(false);
        outWall.SetActive(false);
        inWall.SetActive(false);
        tJunct.SetActive(false); */

        //for loop to go through the array and add gameobjects based on number
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
