using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rigibody;
    public float jumpForce;
    private bool levelStart;
    public GameObject gameController;
    private int score;
    public Text scoreText;
    public GameObject message;


    private void Awake()
    {
        rigibody = this.gameObject.GetComponent<Rigidbody2D>();
        levelStart = false;
        rigibody.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        //if(rigibody != null)
        //{
        //    Debug.Log("Da tim thay rigibody");
        //}
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    this.gameObject.GetComponent<Rigidbody2D>();
    //}

    // Update is called once per frame
    void Update()
    {
        //Kiem tra phim space co duoc bam khong
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space pressed");
            
            
                if(levelStart ==  false) 
                { 
                    levelStart = true;
                    rigibody.gravityScale = 8;
                    gameController.GetComponent<PipeGenerator>().enableGeneratePipe = true;
                    message.GetComponent<SpriteRenderer>().enabled = false;
                }
            
            BirdMoveUp();
        }
    }


    private void BirdMoveUp() //lam chim bay len mot doan
    {
        rigibody.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Va cham");
        ReloadSence();
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("+1");
        score += 1;
        scoreText.text = score.ToString();
    }

    public void ReloadSence()
    {
        SceneManager.LoadScene("_gameplay");
    }

    
}
