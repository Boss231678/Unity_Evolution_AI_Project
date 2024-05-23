using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{   
    public float radius;
    public float angle;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public List<Transform> visibleTargets = new List<Transform>(); 
    public int numOfTargets;
    public bool isTargetFound = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 DirectionFromAngle(float angleInDeg, bool angleIsGlobal)
    {
        if(angleIsGlobal == false)
        {
            angleInDeg += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDeg * Mathf.Deg2Rad));
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, radius, targetMask);

        for(int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if(Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask) == false)
                {
                    visibleTargets.Add(target);
                }
            }
        }
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
            /*
            if(visibleTargets.Count > 0)
            {
                for(int i = 0; i < visibleTargets.Count; i++)
                {
                    //Debug.Log("The object in the field of view is: " + visibleTargets[i].ToString());
                    for(int j = 0; j < numOfTargets; j++)
                    {
                        if(visibleTargets[i].ToString() == "Sphere (" + j + ") (UnityEngine.Transform)")
                        {
                            //Debug.Log("Sphere (" + j + ") in sight!");
                            //Debug.Log(visibleTargets[i].position.x + " " + visibleTargets[i].position.y + " " + visibleTargets[i].position.z);
                            isTargetFound = true;
                        }
                    }
                }
            }
            */
        }
    }

    public void test() {
        Debug.Log("this is test function from FOV");
    }
}
