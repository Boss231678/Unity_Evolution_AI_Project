using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player : MonoBehaviour
{
    public GameObject player; 
    public Character character;
    public FieldOfView fov;
    // Start is called before the first frame update
    float newX, newZ;
    float randX, randZ;
    List<Vector3> futureStates = new List<Vector3>();
    List<int> foodsAtPoint;
    int iteratorA;
    float prevX, prevZ;
    float time;
    public float playerX, playerZ;
    public float speed = 5.0f;
    Vector3 targetVector = new Vector3(0.0f, 1.0f, 0.0f);
    Vector3 playerPos;
    public int foodsEaten = 0;
    Vector3 angles; //vector3 is like std::pair
    int count;
    bool collidedWithObstacle = false;
    bool getNewRand = true;
    void Start()
    {
        playerX = 0f;
        playerZ = 0f;
        prevX = 0f;
        prevZ = 0f;
        playerPos = new Vector3(playerX, 1.0f, playerZ);
        transform.position = playerPos; //setting position
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if(fov.visibleTargets.Count > 0)
        {
            Debug.Log(futureStates.Count);
            while(futureStates.Count < 10)
            {
                Debug.Log("B");
                if(collidedWithObstacle)
                {
                    collidedWithObstacle = false;
                    transform.position = new Vector3(prevX, 1.0f, prevZ);
                    iteratorA += 1;
                    getNewRand = true;
                }

                if(getNewRand == true)
                {
                    prevX = newX;
                    prevZ = newZ;
                    newX = Random.Range(-19.5f, 19.5f);
                    newZ = Random.Range(-19.5f, 19.5f);
                    targetVector = new Vector3(newX, 1.0f, newZ);
                    getNewRand = false;
                }
                playerX = transform.position.x;
                playerZ = transform.position.z;
                playerPos = new Vector3(playerX, 1.0f, playerZ);
                transform.position = Vector3.MoveTowards(playerPos, targetVector, speed * Time.deltaTime);
                //Debug.Log(transform.position.x);
                if(targetVector == playerPos)
                {
                    Debug.Log("C");
                    futureStates.Add(playerPos);
                    foodsAtPoint.Add(fov.visibleTargets.Count);

                    transform.position = new Vector3(0f, 1.0f, 0f);
                    
                    getNewRand = true;
                }

                if(collidedWithObstacle)
                {
                    collidedWithObstacle = false;
                    transform.position = new Vector3(prevX, 1.0f, prevZ);
                    iteratorA += 1;
                }
                reward(playerPos, futureStates[iteratorA]);
            }
        }
        else
        {
            //Debug.Log("This was mysteriously called...");
            //random_movement();
        }
    }
    
    private void OnCollisionEnter(Collision collision) //GameObject colliding with another GameObject
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            foodsEaten += 1;
        }
        if(collision.gameObject.name == "Wall")
        {
            Debug.Log("Collided");
            collidedWithObstacle = true;
            newX = prevX;
            newZ = prevZ;
            targetVector = new Vector3(newX, 1.0f, newZ);
        }
    }

    private void random_movement()
    {
        playerX = transform.position.x;
        playerZ = transform.position.z;
        playerPos = new Vector3(playerX, 1.0f, playerZ);
        transform.position = Vector3.MoveTowards(playerPos, targetVector, speed * Time.deltaTime); //moves forward at a certain speed
            
        if(targetVector == transform.position) //target reached
        {
            prevX = newX;
            prevZ = newZ;
            newX = Random.Range(-19.5f, 19.5f);
            newZ = Random.Range(-19.5f, 19.5f);
            targetVector = new Vector3(newX, 1.0f, newZ);
        }        
    }

    private float reward(Vector3 currentState, Vector3 futureState)
    {
        return 0.0f;
    }
    
}