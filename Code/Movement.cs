using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    [SerializeField] Timer timer;
    [SerializeField] ActiveInterface ai;
    [SerializeField] AnswerValidate av;
    [SerializeField] Clock clock;
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
    public Text UserName;
    public GameObject btnStart;
    
    private SoundManager sm;

    void Start()
    {
     player = GetComponent<Rigidbody2D>();
     pyr_runing = GetComponent<Animator>();
     AddUserName();
     sm = FindObjectOfType<SoundManager>();
     sm.ActivateSound(9, 0.40f);
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
            sm.ActivateSound(7, 0.20f);
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
            sm.ActivateSound(5, 0.30f);
        }else
        {
            ai.ActivateBR(false);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "coins"){
            coin++;
            sm.ActivateSound(8, 0.30f);
            if(coin == 15 || coin == 30 || coin == 45)
            {
                btnStart.SetActive(true);
                sm.ActivateSound(0, 0.40f);
            }
            
            text_counter.text = coin.ToString();
            text_counter2.text = coin.ToString();
            Destroy(coll.gameObject);
        }
    }

    public void LoadCalleges()
    {
        ai.ActivateChallenges(true);
        clock.Update();
        btnStart.SetActive(false);
    }


    public void pressRight(){
        moveRight = true;
        av.BacktoNormal();
    }
    public void NopressRight(){
        moveRight = false;
    }
    public void pressLeft(){
        moveLeft = true;
        av.BacktoNormal();
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

    public void AddUserName()
    {
        if(PlayerPrefs.HasKey("KeyUserName"))
        {
            UserName.text = PlayerPrefs.GetString("KeyUserName");
        }
        else
        {
            UserName.text = "Usuario";
            PlayerPrefs.SetString("KeyUserName", "Usuario");
        }

        if(UserName.text == "")
        {
            UserName.text = "Usuario";
        }
    }

}
