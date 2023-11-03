using System.Collections;
using System.Xml.Linq;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;

public class CountdownController : MonoBehaviour
{
    public Text countdownText;
    private int countdownNumber = 3;
    private float countdownDuration = 1f;
    //private AudioSource backgroundMusic;

    private void Start()
    {
 
        //backgroundMusic = GetComponent<AudioSource>();

        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (countdownNumber > 0)
        {
            countdownText.text = countdownNumber.ToString();
            yield return new WaitForSeconds(countdownDuration);
            countdownNumber--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(countdownDuration);

        countdownText.gameObject.SetActive(false);


        //StartGame();
    }
}
