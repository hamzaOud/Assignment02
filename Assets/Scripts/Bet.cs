using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bet : MonoBehaviour
{
    public int stake;
    public BetOption bet;

    public Bet(int mStake, BetOption mBetOption)
    {
        stake = mStake;
        bet = mBetOption;
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
