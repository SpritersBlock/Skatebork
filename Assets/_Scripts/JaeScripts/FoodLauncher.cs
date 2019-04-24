using UnityEngine;
using System.Collections;

public class FoodLauncher : MonoBehaviour
{

    public Rigidbody origFood;
    public Vector3 target;
    public Rigidbody foodClone;

    public float h;
    public float gravity = -18;

    //public bool debugPath;

    void Start()
    {
        //ball.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            print(Vector3.Distance(target, transform.position));
        }

        //if (debugPath)
        //{
        //    DrawPath();
        //}
    }

    public void Launch()
    {
        GetTarget();
        foodClone = Instantiate(origFood);
        foodClone.transform.position = transform.position;
        foodClone.GetComponent<ItemController>().beingFired = true;
        Physics.gravity = Vector3.up * gravity;
        foodClone.useGravity = true;
        foodClone.velocity = Vector3.zero;
        foodClone.velocity = CalculateLaunchData().initialVelocity;
    }

    void GetTarget()
    {
        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Boss" || hit.collider.tag == "Trolley")
            {
                target = hit.collider.transform.position;
            }
            else
            {
                target = hit.point;
            }
            //print(hit.collider.name + target);
        }
    }

    LaunchData CalculateLaunchData()
    {
        float displacementY = target.y - foodClone.position.y;
        Vector3 displacementXZ = new Vector3(target.x - foodClone.position.x, 0, target.z - foodClone.position.z);
        float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / time;

        if (Vector3.Distance(target, transform.position) < 20)
        {
            h = 2;
        }
        else if (Vector3.Distance(target, transform.position) > 20 && Vector3.Distance(target, transform.position) < 50)
        {
            h = 3;
        }
        else if (Vector3.Distance(target, transform.position) < 50 && Vector3.Distance(target, transform.position) > 100)
        {
            h = 4;
        }
        else if (Vector3.Distance(target, transform.position) < 100 && Vector3.Distance(target, transform.position) > 200)
        {
            h = 10;
        }
        else if (Vector3.Distance(target, transform.position) < 200 && Vector3.Distance(target, transform.position) > 400)
        {
            h = 40;
        }
        else
        {
            h = 100;
        }

        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
    }

    //void DrawPath()
    //{
    //    LaunchData launchData = CalculateLaunchData();
    //    Vector3 previousDrawPoint = foodClone.position;

    //    int resolution = 30;
    //    for (int i = 1; i <= resolution; i++)
    //    {
    //        float simulationTime = i / (float)resolution * launchData.timeToTarget;
    //        Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
    //        Vector3 drawPoint = foodClone.position + displacement;
    //        Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
    //        previousDrawPoint = drawPoint;
    //    }
    //}

    struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData(Vector3 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }
    }
}
