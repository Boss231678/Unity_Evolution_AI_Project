using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithim : MonoBehaviour
{
    GameObject agent;
    public Player player;
    public FieldOfView fov;
    // Start is called before the first frame update
    void Start()
    {
        //player = agent.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        reward();
    }
    
    float reward()
    {   
        float x = player.playerX;
        float z = player.playerZ;
        Debug.Log(x + " " + z);
        return 0.0f;
    }
}
