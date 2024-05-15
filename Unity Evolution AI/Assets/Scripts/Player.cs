using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player : MonoBehaviour
{
    public GameObject player; 
    public Character character;
    private FieldOfView fov;
    // Start is called before the first frame update
    float newX;
    float newZ;
    float prevX, prevZ;
    float time;
    float playerX, playerZ;
    public float speed = 25.0f;
    Vector3 targetVector = new Vector3(0.0f, 1.0f, 0.0f);
    Vector3 angles;
    void Start()
    {
        playerX = 0f;
        playerZ = 0f;
        transform.position = new Vector3(playerX, 1.0f, playerZ);
        Debug.Log("X: " + newX);
        fov = player.GetComponent<FieldOfView>();
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
        
        if(targetVector == transform.position)
        {
            prevX = newX;
            prevZ = newZ;
            newX = Random.Range(-19.5f, 19.5f);
            newZ = Random.Range(-19.5f, 19.5f);
            targetVector = new Vector3(newX, 1.0f, newZ);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Wall")
        {
            newX = prevX;
            newZ = prevZ;
            targetVector = new Vector3(newX, 1.0f, newZ);
        }
    }
    
}