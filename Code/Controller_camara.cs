using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_camara : MonoBehaviour
{
    public GameObject player;
    private float player_posX;
    private float player_posY;
    private float posY;
    private float posX;
    public float rightMax;
    public float lefttMax;
    public float heightMax;
    public float heightMin;
    public float speed_camera;
    public bool on_camera;
    
    void Start()
    {
       posX = player_posX + rightMax;
       posY = player_posY + heightMin;
       transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), 1);
    }

    public void move_camera(){
        if(on_camera){
            if(player){
                player_posX = player.transform.position.x;
                player_posY = player.transform.position.y;

                if(player_posX > rightMax && player_posX < lefttMax){
                    posX = player_posX;
                }

                if(player_posY > heightMax && player_posY < heightMin){
                    posY = player_posY;
                }
            }
            
            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), speed_camera*Time.deltaTime);
        }
    }
    
    void Update()
    {
        move_camera();
    }
}
