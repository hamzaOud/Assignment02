using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public bool hasBallEnteredCollider = false;
    public int numberFallen = 0;
    public float noMovementThreshold;
    private const int noMovementFrames = 3;
    Vector3[] previousLocations = new Vector3[noMovementFrames];
    public bool isMoving;
    public Vector3 forceToAdd;

    Vector3 ballStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;

        //For good measure, set the previous locations
        for (int i = 0; i < previousLocations.Length; i++)
        {
            previousLocations[i] = Vector3.zero;
        }

        ballStartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        print(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //Store the newest vector at the end of the list of vectors
        for (int i = 0; i < previousLocations.Length - 1; i++)
        {
            previousLocations[i] = previousLocations[i + 1];
        }
        previousLocations[previousLocations.Length - 1] = transform.localPosition;

        //Check the distances between the points in your previous locations
        //If for the past several updates, there are no movements smaller than the threshold,
        //you can most likely assume that the object is not moving
        for (int i = 0; i < previousLocations.Length - 1; i++)
        {
            if (Vector3.Distance(previousLocations[i], previousLocations[i + 1]) >= noMovementThreshold)
            {
                //The minimum movement has been detected between frames
                isMoving = true;
                break;
            }
            else
            {
                isMoving = false;
            }
        }
    }

    public void SpinBall()
    {
        rb.constraints = RigidbodyConstraints.None;
        transform.position = ballStartPosition;
        rb.velocity = Vector3.zero;

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        rb.AddForce(forceToAdd, ForceMode.Impulse);
        Invoke("Tester", 0.3f);

    }

    void Tester()
    {
        print(isMoving);
    }
}
