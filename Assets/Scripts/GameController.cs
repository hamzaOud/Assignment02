using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;
using System.Diagnostics.Contracts;

public class GameController : MonoBehaviour
{
    //This is our data, it is static
    public RouletteNumber[] rouletteNumbers;
    public BetOption[] betOptions;

    //controllers
    public UIController uiController;
    public UITable uITable;
    public BallController ballController;

    public int lastNumbers = 0; // The number to have fallen in the wheel after we spinned it. 

    //These are our variables that are defined by the user input
    public List<Bet> currentBet;// This is all the bets that the player has on the table.
    public List<Bet> lastBet;//Previous bet, if the player wants to repeat the last bet
    public int balance; //The balance of the player
    public int selectedChipValue;

    private AudioSource audioSource;

    int random = 0;

    void Start()
    {
        #if UNITY_ANDROID
        Screen.orientation = ScreenOrientation.Landscape;
        #endif

        //populating data
        selectedChipValue = 5;
        rouletteNumbers = new RouletteNumber[37];
        PopulateNumbers();
        betOptions = new BetOption[46];
        PopulateBetOptions();
        balance = PlayerPrefs.GetInt("Balance");
        uiController.UpdateBalanceUI();
        uiController.repeatButton.interactable = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    int CalculateEarnings(Bet[] bet, int fallenNumber)
    {
        int earnings = 0;
        foreach (Bet aBet in bet) //Loop through each individual bet
        {
            int individualBetEarnings = 0;
            foreach(RouletteNumber rNumber in aBet.bet.numbersInBet)
            {
                if (fallenNumber == rNumber.number) //If the number to have fallen on the wheel is inside the array of numbers of the bet option (basically you won) 
                {
                    earnings = earnings + aBet.stake * aBet.bet.multiplier; //Add winnings stake*multiplier (earnings)
                    individualBetEarnings = individualBetEarnings + aBet.stake * aBet.bet.multiplier;
                    break;
                }
            }
        }

        return earnings;

    }

    void UpdateBalance(int earnings)
    {
        balance = balance + earnings;
        PlayerPrefs.SetInt("Balance", balance);
    }

    void PopulateNumbers()
    {
        //Cannot use a for loop because the colors are random
        RouletteNumber number0 = new RouletteNumber(0, "None");
        rouletteNumbers[0] = number0;
        RouletteNumber number1 = new RouletteNumber(1, "Red");
        rouletteNumbers[1] = number1;
        RouletteNumber number2 = new RouletteNumber(2, "Black");
        rouletteNumbers[2] = number2;
        RouletteNumber number3 = new RouletteNumber(3, "Red");
        rouletteNumbers[3] = number3;
        RouletteNumber number4 = new RouletteNumber(4, "Black");
        rouletteNumbers[4] = number4;
        RouletteNumber number5 = new RouletteNumber(5, "Red");
        rouletteNumbers[5] = number5;
        RouletteNumber number6 = new RouletteNumber(6, "Black");
        rouletteNumbers[6] = number6;
        RouletteNumber number7 = new RouletteNumber(7, "Red");
        rouletteNumbers[7] = number7;
        RouletteNumber number8 = new RouletteNumber(8, "Black");
        rouletteNumbers[8] = number8;
        RouletteNumber number9 = new RouletteNumber(9, "Red");
        rouletteNumbers[9] = number9;
        RouletteNumber number10 = new RouletteNumber(10, "Black");
        rouletteNumbers[10] = number10;
        RouletteNumber number11 = new RouletteNumber(11, "Black");
        rouletteNumbers[11] = number11;
        RouletteNumber number12 = new RouletteNumber(12, "Red");
        rouletteNumbers[12] = number12;
        RouletteNumber number13 = new RouletteNumber(13, "Black");
        rouletteNumbers[13] = number13;
        RouletteNumber number14 = new RouletteNumber(14, "Red");
        rouletteNumbers[14] = number14;
        RouletteNumber number15 = new RouletteNumber(15, "Black");
        rouletteNumbers[15] = number15;
        RouletteNumber number16 = new RouletteNumber(16, "Red");
        rouletteNumbers[16] = number16;
        RouletteNumber number17 = new RouletteNumber(17, "Black");
        rouletteNumbers[17] = number17;
        RouletteNumber number18 = new RouletteNumber(18, "Red");
        rouletteNumbers[18] = number18;
        RouletteNumber number19 = new RouletteNumber(19, "Red");
        rouletteNumbers[19] = number19;
        RouletteNumber number20 = new RouletteNumber(20, "Black");
        rouletteNumbers[20] = number20;
        RouletteNumber number21 = new RouletteNumber(21, "Red");
        rouletteNumbers[21] = number21;
        RouletteNumber number22 = new RouletteNumber(22, "Black");
        rouletteNumbers[22] = number22;
        RouletteNumber number23 = new RouletteNumber(23, "Red");
        rouletteNumbers[23] = number23;
        RouletteNumber number24 = new RouletteNumber(24, "Black");
        rouletteNumbers[24] = number24;
        RouletteNumber number25 = new RouletteNumber(25, "Red");
        rouletteNumbers[25] = number25;
        RouletteNumber number26 = new RouletteNumber(26, "Black");
        rouletteNumbers[26] = number26;
        RouletteNumber number27 = new RouletteNumber(27, "Red");
        rouletteNumbers[27] = number27;
        RouletteNumber number28 = new RouletteNumber(28, "Black");
        rouletteNumbers[28] = number28;
        RouletteNumber number29 = new RouletteNumber(29, "Black");
        rouletteNumbers[29] = number29;
        RouletteNumber number30 = new RouletteNumber(30, "Red");
        rouletteNumbers[30] = number30;
        RouletteNumber number31 = new RouletteNumber(31, "Black");
        rouletteNumbers[31] = number31;
        RouletteNumber number32 = new RouletteNumber(32, "Red");
        rouletteNumbers[32] = number32;
        RouletteNumber number33 = new RouletteNumber(33, "Black");
        rouletteNumbers[33] = number33;
        RouletteNumber number34 = new RouletteNumber(34, "Red");
        rouletteNumbers[34] = number34;
        RouletteNumber number35 = new RouletteNumber(35, "Black");
        rouletteNumbers[35] = number35;
        RouletteNumber number36 = new RouletteNumber(36, "Red");
        rouletteNumbers[36] = number36;
    }

    void PopulateBetOptions()
    {
        //Create the bet options for the individual numbers, with a mulitplier of 36
        for (int i = 0; i < 37; i++)
        {
            RouletteNumber[] individualNumber = new RouletteNumber[1];
            individualNumber[0] = rouletteNumbers[i];
            betOptions[i] = new BetOption(individualNumber, 36, i);
        }



        List<RouletteNumber> cBlack = new List<RouletteNumber>();
        List<RouletteNumber> cRed = new List<RouletteNumber>();
        List<RouletteNumber> lOdd = new List<RouletteNumber>();
        List<RouletteNumber> lEven = new List<RouletteNumber>();
        List<RouletteNumber> lFirstHalf = new List<RouletteNumber>();
        List<RouletteNumber> lSecondHalf = new List<RouletteNumber>();
        List<RouletteNumber> lFirst12 = new List<RouletteNumber>();
        List<RouletteNumber> lSecond12 = new List<RouletteNumber>();
        List<RouletteNumber> lThird12 = new List<RouletteNumber>();

        for (int i = 0; i < rouletteNumbers.Length;i++)
        {
            if (rouletteNumbers[i].color == "Black")
            {
                cBlack.Add(rouletteNumbers[i]);
            }
            if (rouletteNumbers[i].color == "Red")
            {
                cRed.Add(rouletteNumbers[i]);
            }
            if(rouletteNumbers[i].number % 2 == 1)
            {
                lOdd.Add(rouletteNumbers[i]);
            }
            if (rouletteNumbers[i].number % 2 == 0 && rouletteNumbers[i].number != 0)
            {
                lEven.Add(rouletteNumbers[i]);
            }
            if(rouletteNumbers[i].number > 0 && rouletteNumbers[i].number < 19)
            {
                lFirstHalf.Add(rouletteNumbers[i]);
            }
            if (rouletteNumbers[i].number > 18)
            {
                lSecondHalf.Add(rouletteNumbers[i]);
            }
            if (rouletteNumbers[i].number > 0 && rouletteNumbers[i].number < 13)
            {
                lFirst12.Add(rouletteNumbers[i]);
            }
            if (rouletteNumbers[i].number > 12 && rouletteNumbers[i].number < 25)
            {
                lSecond12.Add(rouletteNumbers[i]);
            }
            if (rouletteNumbers[i].number > 24)
            {
                lThird12.Add(rouletteNumbers[i]);
            }

        }

        RouletteNumber[] colorBlack = cBlack.ToArray();
        RouletteNumber[] colorRed = cRed.ToArray();
        RouletteNumber[] odd = lOdd.ToArray();
        RouletteNumber[] even = lEven.ToArray();
        RouletteNumber[] firstHalf = lFirstHalf.ToArray();
        RouletteNumber[] secondHalf = lSecondHalf.ToArray();
        RouletteNumber[] first12 = lFirst12.ToArray();
        RouletteNumber[] second12 = lSecond12.ToArray();
        RouletteNumber[] third12 = lThird12.ToArray();

        betOptions[37] = new BetOption(colorBlack, 2, 37);
        betOptions[38] = new BetOption(colorRed, 2, 38);
        betOptions[39] = new BetOption(odd, 2, 39);
        betOptions[40] = new BetOption(even, 2, 40);
        betOptions[41] = new BetOption(firstHalf, 2, 41);
        betOptions[42] = new BetOption(secondHalf, 2, 42);
        betOptions[43] = new BetOption(first12, 3, 43);
        betOptions[44] = new BetOption(second12, 3, 44);
        betOptions[45] = new BetOption(third12, 3, 45);

    }

    private IEnumerator BetSpinWheelCoroutine(GameController instance)
    {

        audioSource.Stop();
        audioSource.Play();

        ballController.SpinBall();

        yield return new WaitForSeconds(0.5f);
        //yield return new WaitUntil(() => !ballController.isMoving);
        yield return new WaitWhile(() => ballController.isMoving);

        if (!ballController.isMoving && ballController.hasBallEnteredCollider)
        {
            lastNumbers = ballController.numberFallen;
            print(lastNumbers);
        }

        int earnings = CalculateEarnings(currentBet.ToArray(), lastNumbers);
        UpdateBalance(earnings);

        lastBet.Clear();
        foreach (Bet bet in currentBet)
        {
            lastBet.Add(bet);
        }

        currentBet.Clear();
        updateUI();
        uiController.ChangeLastNumberText();
        uiController.repeatButton.interactable = true;
    }


    public void BetSpinWheel()
    {
        StartCoroutine(BetSpinWheelCoroutine(this));

    }

    public void AddBet(Bet betToAdd)
    {
        currentBet.Add(betToAdd);

        //Update Balance
        balance = balance - selectedChipValue;
        PlayerPrefs.SetInt("Balance", balance);
        updateUI();
    }

    public void UpdateBet(Bet betToUpdate, int amountToAdd)
    {
        betToUpdate.stake += amountToAdd;
        balance = balance - amountToAdd;
        PlayerPrefs.SetInt("Balance", balance);
        updateUI();
    }

    public void updateUI()
    {
        uITable.UpdateButtons();
        uiController.UpdateBalanceUI();
    }
}
