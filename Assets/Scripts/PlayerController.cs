using System.Collections;
using System.Xml.Linq;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public AudioSource walkingAudio;
    public ParticleSystem dust;
    public ParticleSystem walldust;
    public Text ghostTimerText;

    public float moveSpeed = 5f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private KeyCode lastInputKey;
    public AudioSource collisionSound;
    public AudioSource background;
    public AudioSource ghostScared;
    //private AudioSource audioSource;
    public AudioSource eatingSound;
    private bool isObstructed = false;
    public GameObject leftTeleporter;
    public GameObject rightTeleporter;
    public Animator defaultAnimator;
    public Animator blueAnimator;
    public Animator greenAnimator;
    public Animator purpleAnimator;
    public float scared = 0f;
    public float recovery = 0f;
    public float ghostlength;
    private float elapsedTime = 0f;
   // private bool gameStarted = false;
    public Text timerTextUI;


    void Start()
    {
        targetPosition = player.transform.position;
        walkingAudio.Stop();
        ghostTimerText.gameObject.SetActive(false);
       // audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        animator.SetFloat("speed", moveSpeed);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        GetLastInputKey(horizontalInput, verticalInput);

        if (!isMoving)
        {
            moveDirection = new Vector3(horizontalInput, verticalInput, 0);

            if (moveDirection != Vector3.zero)
            {
                targetPosition = player.transform.position + moveDirection;
                dust.Play();

                if (!walkingAudio.isPlaying)
                {
                    walkingAudio.Play();
                }

                StartCoroutine(TweenPacStudent(targetPosition));
                //Debug.Log(lastInputKey);
            }
        }
        defaultAnimator.SetFloat("scared", scared);
        blueAnimator.SetFloat("scared", scared);
        greenAnimator.SetFloat("scared", scared);
        purpleAnimator.SetFloat("scared", scared);

        defaultAnimator.SetFloat("recovery", recovery);
        blueAnimator.SetFloat("recovery", recovery);
        greenAnimator.SetFloat("recovery", recovery);
        purpleAnimator.SetFloat("recovery", recovery);

        if (Time.time > 3f)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        int score = scoreManager.score;

        PlayerPrefs.SetFloat("Time", elapsedTime);
        PlayerPrefs.SetInt("Score", score);

    }

    private IEnumerator TweenPacStudent(Vector3 destination)
    {
        isMoving = true;
        Vector3 startPosition = player.transform.position;
        float journeyLength = Vector3.Distance(startPosition, destination);
        float startTime = Time.time;

        while (Time.time - startTime < journeyLength / moveSpeed)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            player.transform.position = Vector3.Lerp(startPosition, destination, fractionOfJourney);

            if (!isObstructed)
            {
                player.transform.position = Vector3.Lerp(startPosition, destination, fractionOfJourney);
            }
        yield return null;


        }

        player.transform.position = destination;
        isMoving = false;
        walkingAudio.Stop();
        dust.Stop();
    }

    private KeyCode GetLastInputKey(float horizontalInput, float verticalInput)
    {
        if (verticalInput > 0)
        {
            return KeyCode.W;
        }
        else if (verticalInput < 0)
        {
            return KeyCode.S;
        }
        else if (horizontalInput < 0)
        {
            return KeyCode.A;
        }
        else if (horizontalInput > 0)
        {
            return KeyCode.D;
        }
        return lastInputKey;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            collisionSound.Play();
            isObstructed = true;
            walldust.Play();
            
        }
       /* else if (other.CompareTag("leftTeleporter"))
        {
            Debug.Log("tele");
            //TeleportTo(rightTeleporter);
            player.transform.position = leftTeleporter.transform.position;
        }
        else if (other.CompareTag("rightTeleporter"))
        {
            Debug.Log("tele");
            //TeleportTo(leftTeleporter);
            player.transform.position = rightTeleporter.transform.position;
        }*/

        if (other.CompareTag("Pellet"))
        {
            eatingSound.Play();
            Destroy(other.gameObject);
            FindObjectOfType<ScoreManager>().AddToScore(10);
        }
        else if (other.CompareTag("Cherry"))
        {
            eatingSound.Play();
            Destroy(other.gameObject);
            FindObjectOfType<ScoreManager>().AddToScore(100);
        }
        if (other.CompareTag("SuperPellet"))
        {
            scared = 1f;
            Destroy(other.gameObject);

        }
        if (scared > 0.1f)
        {
            if (ghostTimerText != null)
            {
                ghostTimerText.gameObject.SetActive(true);
                int remainingTime = Mathf.CeilToInt(ghostlength - (Time.time - 10));
                ghostTimerText.text = remainingTime.ToString();

                if (remainingTime <= 3)
                {
                    scared = 0f;
                }

                if (Time.time - 10 >= ghostlength)
                {
                    recovery = 1f;
                }
                ghostTimerText.gameObject.SetActive(false);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            isObstructed = false;
            walldust.Stop();
        }
    }
    /* private void TeleportTo(GameObject teleporter)
     {
         Debug.Log("big tele");
         player.transform.position = teleporter.transform.position;
     }*/
    /* private void GhostScaredBehavior()
     {

         }*/
    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);

        string timerText = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

        timerTextUI.text = timerText;
    }
}



