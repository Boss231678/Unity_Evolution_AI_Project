using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player : MonoBehaviour
{
    
    // Start is called before the first frame update
    float newX;
    float newZ;
    float time;
    float playerX, playerZ;
    float speed = 25.0f;
    Vector3 targetVector = new Vector3(0.0f, 1.0f, 0.0f);
    Vector3 angles;
    void Start()
    {
        playerX = 0f;
        playerZ = 0f;
        transform.position = new Vector3(playerX, 1.0f, playerZ);
        Debug.Log("X: " + newX);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        angles = transform.eulerAngles;
        transform.eulerAngles = new Vector3(angles.x, 90.0f, angles.z);
        transform.position = Vector3.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Stopped");
            speed = 0;
        }
        if(targetVector == transform.position)
        {
            newX = Random.Range(-19.5f, 19.5f);
            newZ = Random.Range(-19.5f, 19.5f);
            targetVector = new Vector3(newX, 1.0f, newZ);
        }
    }
    
    void movePlayer()
    {
        newX = Random.Range(-19.5f, 19.5f);
        newZ = Random.Range(-19.5f, 19.5f);
        int i = 0;
        while(i < 100)
        {
            if(newX < playerX)
            {
                playerX -= 0.1f;
            }
            else if(newX > playerX)
            {
                playerX += 0.1f;
            }
            if(newZ < playerZ)
            {
                playerZ -= 0.1f;
            }
            else if(newZ > playerZ)
            {
                playerZ += 0.1f;
            }
            targetVector = new Vector3(playerX, 1.0f, playerZ);
            //transform.position = targetVector;
            transform.position = Vector3.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);
            Thread.Sleep((int)(Time.deltaTime));
            i += 1;
            if(targetVector == transform.position)
            {
                Debug.Log("Reached");
            }
        }
        //transform.position = new Vector3(newX, 1.0f, newZ);
    }

    IEnumerator delay()
    {
        /*
        time = time + Time.deltaTime;
        int timer = 0;
        while(timer < 100)
        {
            Debug.Log(timer);
            if(time > 5f)
            {
                Debug.Log("BROKEN");
                time = 0.0f;
                break;
            }
            timer += 1;
        }
        */
        yield return new WaitForSeconds(10);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Wall")
        {
            newX = Random.Range(-19.5f, 19.5f);
            newZ = Random.Range(-19.5f, 19.5f);
            targetVector = new Vector3(newX, 1.0f, newZ);
        }
    }
}
