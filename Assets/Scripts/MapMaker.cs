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
    public GameObject mapquarter;
    public float tileSize = 1.0f;
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
        //mapquarter.SetActive(false);
        for (int row = 0; row < levelMap.GetLength(0); row++)
        {
            for (int col = 0; col < levelMap.GetLength(1); col++)
            {
                int tileValue = levelMap[row, col];

                Vector3 tilePosition = new Vector3(col * tileSize, -row * tileSize, 0);

                GameObject tilePrefab = null;

                switch (tileValue)
                {
                    case 1:
                        tilePrefab = outCorner;
                        break;
                    case 2:
                        tilePrefab = outWall;
                        break;
                    case 3:
                        tilePrefab = inCorner;
                        break;
                    case 4:
                        tilePrefab = inWall;
                        break;
                    case 5:
                        tilePrefab = pellet;
                        break;
                    case 6:
                        tilePrefab = powerpellet;
                        break;
                    case 7:
                        tilePrefab = tJunct;
                        break;
                }

                if (tilePrefab != null)
                {
                    GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                }
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
