using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float highestScore;

    public float acceleration = 30;
    public float airAcceleration = 15;
    public float maxSpeed = 60;
    public float jumpSpeed = 5;
    public float jumpDuration = 5;
    float actualSpeed;
    bool justJumped;
    bool canVariableJump;
    float jmpTimer;


    public bool hit;
    public GameObject gameEndPanel;
    public Text scoreTxt;
    public Text highscoreTxt;
    public Text resultTxt;
    public float score = 0;
    public static PlayerController pc;
    private void Awake()
    {
        pc = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highestScore = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            highestScore = 0;
        }
        rb = GetComponent<Rigidbody>();
    }
    float horizontal;
    float vertical;
    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (score >= 80)
        {
            gameEndPanel.SetActive(true);
            resultTxt.text = "YOU WON";
            if (score > highestScore)
            {
                PlayerPrefs.SetFloat("HighScore", score);
                highestScore = score;
            }
            highscoreTxt.text = highestScore.ToString();
            Enemy.en.canBomb = false;
        }
        else if (hit)
        {
            gameEndPanel.SetActive(true);
            resultTxt.text = "YOU LOSE";
            if (score > highestScore)
            {
                PlayerPrefs.SetFloat("HighScore", score);
                highestScore = score;
            }
            highscoreTxt.text = highestScore.ToString();
            Enemy.en.canBomb = false;
        }
        else
        {
            HorizontalMovement();
            Jump();
        }
    }

    private void HorizontalMovement()
    {
        actualSpeed = this.maxSpeed;

        rb.AddForce(new Vector2((horizontal * actualSpeed) - rb.velocity.x * this.acceleration, 0));

        if (horizontal == 0 )
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    void Jump()
    {
        if (vertical > 0)
        {
            if (!justJumped)
            {
                justJumped = true;

                rb.velocity = new Vector3(rb.velocity.x, this.jumpSpeed);
                    jmpTimer = 0;
                    canVariableJump = true;

            }
            else
            {
                if (canVariableJump)
                {
                    jmpTimer += Time.deltaTime;

                    if (jmpTimer < this.jumpDuration / 1000)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, this.jumpSpeed);

                    }
                }
            }
        }
        else
        {
            justJumped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gems")
        {
            score += 10;
           
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy")
        {

            hit = true;
        }

    }


}
