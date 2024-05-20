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
    List<int> foodsAtPoint = new List<int>();
    List<List<Transform>> foodPositions = new List<List<Transform>>();
    List<List<float>> distances = new List<List<float>>();
    int iteratorA;
    float prevX, prevZ;
    float time;
    public float playerX, playerZ;
    public float speed = 5.0f;
    Vector3 targetVector = new Vector3(0.0f, 1.0f, 0.0f);
    Vector3 playerPos;
    Vector3 startPosition;
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
        startPosition = playerPos;
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
            if(futureStates.Count != 10)
            {
                if(getNewRand == true)
                {
                    playerX = transform.position.x;
                    playerZ = transform.position.z;
                    playerPos = new Vector3(playerX, 1.0f, playerZ);
                    getNewRandoms();
                    getNewRand = false;
                }
                goToPointAndBack(playerPos, targetVector);
            }

            if(futureStates.Count == 10)
            {
                for(int i = 0; i < futureStates.Count; i++)
                {

                    Debug.Log(futureStates[i] + " " + foodsAtPoint[i]);
                    List<float> d = new List<float>();
                    for(int j = 0; j < foodPositions[i].Count; j++)
                    {
                        d.Add(Vector3.Distance(foodPositions[i][j].position, futureStates[i]));
                        //Debug.Log("X: " + foodPositions[i][j].position.x + " " + Vector3.Distance(foodPositions[i][j].position, futureStates[i]));
                    }
                    distances.Add(d);
                }
                Debug.Log("----");


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
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            foodsEaten += 1;
        }
        if(collision.gameObject.name == "Wall")
        {
            //Debug.Log("Collided");
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
            getNewRandoms();
        }        
    }

    void getNewRandoms()
    {
        prevX = newX;
        prevZ = newZ;
        newX = Random.Range(-19.5f, 19.5f);
        newZ = Random.Range(-19.5f, 19.5f);
        targetVector = new Vector3(newX, 1.0f, newZ);
    }

    void goToPointAndBack(Vector3 start, Vector3 end)
    {
        transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);
        if(end == transform.position)
        {
            getNewRand = true;
            futureStates.Add(end);
            foodsAtPoint.Add(fov.visibleTargets.Count);
            foodPositions.Add(fov.visibleTargets);
            Debug.Log(futureStates.Count);
            transform.position = startPosition;
        }
    }

    private float reward(Vector3 currentState, Vector3 futureState)
    {
        return 0.0f;
    }
}