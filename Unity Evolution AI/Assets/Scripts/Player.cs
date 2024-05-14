using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // Start is called before the first frame update
    float newX;
    float newY;
    float time;
    float playerX, playerY;
    float speed = 5.0f;
    Vector3 targetVector = new Vector3(0.0f, 1.0f, 0.0f);
    void Start()
    {
        playerX = 0f;
        playerY = 0f;
        transform.position = new Vector3(playerX, 1.0f, playerY);
        Debug.Log("X: " + newX);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        time = time + 1f * Time.deltaTime;
        if(time >= 5)
        {
            time = 0f;
            movePlayer();
        }
        */
        //movePlayer();
        
        transform.position = Vector3.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);
        if(targetVector == transform.position)
        {
            newX = Random.Range(-19.5f, 19.5f);
            newY = Random.Range(-19.5f, 19.5f);
            targetVector = new Vector3(newX, 1.0f, newY);
        }
    }
    /*
    void movePlayer()
    {
        
        while(newX != playerX && newY != playerY)
        {
            if(newX < playerX)
            {
                playerX -= 0.1f;
            }
            else if(newX > playerX)
            {
                playerX += 0.1f;
            }
            if(newY < playerY)
            {
                playerY -= 0.1f;
            }
            else if(newY > playerY)
            {
                playerY += 0.1f;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerX, 1.0f, playerY), speed * Time.deltaTime);
        }
        //transform.position = new Vector3(newX, 1.0f, newY);
    }
    */
}
