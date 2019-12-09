using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIController : MonoBehaviour
{
    public Text textFallenNumber;
    public GameController gameController;
    public int currentChipValue;
    public Text BalanceText;
    public Button repeatButton;
    public Button betButton;

    public Button[] chipButtons;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBalanceUI();
        chipButtons[0].image.color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.ballController.isMoving && gameController.currentBet.Count > 0)
        {
            betButton.interactable = true;
        }
        else 
        {
            betButton.interactable = false;
        }
    }

    public void RepeatBet()
    {
        foreach (Bet bet in gameController.lastBet)
        {
            gameController.currentBet.Add(bet);
            gameController.balance -= bet.stake;
        }
        gameController.updateUI();
        repeatButton.interactable = false;
    }

    public void RemoveBet()
    {
        foreach(Bet bet in gameController.currentBet)
        {
            gameController.balance += bet.stake;
            PlayerPrefs.SetInt("Balance", gameController.balance);
        }
        gameController.currentBet.Clear();
        gameController.updateUI();
    }

    public void ChangeChipValue()
    {

        currentChipValue = Int32.Parse(EventSystem.current.currentSelectedGameObject.name);
        gameController.selectedChipValue = currentChipValue;

        for(int i = 0; i < chipButtons.Length;i++)
        {
            if (currentChipValue.ToString() == chipButtons[i].name)
            {
                chipButtons[i].image.color = Color.cyan;
            }
            else
            {
                chipButtons[i].image.color = Color.white;
            }
        }
    }

    public void ChangeLastNumberText()
    {
        textFallenNumber.text = gameController.lastNumbers.ToString();
    }

    public void UpdateBalanceUI()
    {
        BalanceText.text = gameController.balance.ToString();

    }
}
