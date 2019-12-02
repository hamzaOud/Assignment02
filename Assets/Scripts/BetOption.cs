using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetOption : MonoBehaviour
{
    public RouletteNumber[] numbersInBet;
    public int multiplier;
    public int id;

    public BetOption(RouletteNumber[] rouletteNumbers, int mMultiplier, int mId)
    {
        numbersInBet = rouletteNumbers;
        multiplier = mMultiplier;
        id = mId;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
