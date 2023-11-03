using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Script : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("Assessment3");
    }
}
