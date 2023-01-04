using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float velocity = 3;
    public float jump = 5;
    bool jumpGround = true;
    Rigidbody2D player;
    Transform player_tf;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player_tf = GetComponent<Transform>();
    }

    void Update()
    {

        if(Input.GetKey(KeyCode.D))
        {
            player.velocity = new Vector2(velocity,player.velocity.y);
            player_tf.rotation = new Quaternion(0,0,0,0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.velocity = new Vector2(-velocity,player.velocity.y);
            player_tf.rotation = new Quaternion(0,180f,0,0);
        }

        if (Input.GetKey(KeyCode.W) && jumpGround)
        {
            player.velocity = new Vector2(player.velocity.x,jump);
            jumpGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collesion)
    {
        if (collesion.gameObject.tag == "Tiles")
        {
            jumpGround = true;
        }        
    }
}
