using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    [SerializeField] Timer timer;
    [SerializeField] ActiveInterface ai;
    public float speedMovement = 4;
    private int coin = 0;
    public Text text_counter;
    public Text text_counter2;
    private bool moveRight;
    private bool moveLeft;
    private bool moveJump;
    private bool jumpGround = false;
    public float jump = 8;
    Rigidbody2D player;
    Animator pyr_runing;


    void Start()
    {
     player = GetComponent<Rigidbody2D>();
     pyr_runing = GetComponent<Animator>();
       
    }

    void Update()
    {
        if (moveRight)
        {
            pyr_runing.SetBool("runing",true);
            transform.Translate(Vector3.right * speedMovement * Time.deltaTime);
            transform.rotation = new Quaternion(0,0,0,0);

        }else if(moveLeft)
        {
            pyr_runing.SetBool("runing",true);
            transform.Translate(Vector3.left * -speedMovement * Time.deltaTime);
            transform.rotation = new Quaternion(0,180f,0,0);
        }else{
            pyr_runing.SetBool("runing",false);
        }
        
        if(moveJump && !jumpGround){
            pyr_runing.SetBool("jumping",true);
            player.velocity = new Vector2(player.velocity.x,jump);
            jumpGround = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Tales")){
            pyr_runing.SetBool("jumping",false);
            jumpGround = false;
            player.velocity = new Vector2(player.velocity.x, 0);
        }

        if(other.gameObject.CompareTag("Obstacles"))
        {
            timer.SubtractTime();
            ai.ActivateBR(true);
        }else
        {
            ai.ActivateBR(false);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "coins"){
            coin++;
            text_counter.text = coin.ToString();
            text_counter2.text = coin.ToString();
            Destroy(coll.gameObject);
        }

        if(coll.gameObject.tag == "Starts")
        {
            ai.ActivateChallenges(true);
        }else
        {
            ai.ActivateChallenges(false);
        }
    }


    public void pressRight(){
        moveRight = true;
    }
    public void NopressRight(){
        moveRight = false;
    }
    public void pressLeft(){
        moveLeft = true;
    }
    public void NopressLeft(){
        moveLeft = false;
    }
    public void pressJump(){
        moveJump = true;
    }
    public void NopressJump(){
        moveJump = false;
    }

}
