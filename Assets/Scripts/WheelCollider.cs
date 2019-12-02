using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollider : MonoBehaviour
{
    GameController gameController;
    BallController ballController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        ballController = GameObject.Find("Sphere").GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        int number = int.Parse(this.gameObject.name);
        ballController.hasBallEnteredCollider = true;
        ballController.numberFallen = number;
        gameController.lastNumbers = number;

        //print(ballController.numberFallen);
    }

    private void OnTriggerExit(Collider other)
    {
        ballController.hasBallEnteredCollider = false;
        print("outside collider");
    }
}
