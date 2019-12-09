using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITable : MonoBehaviour
{
    public Button[] numberButtons;
    public GameController gameController;
    public string[] buttonContent;

    // Start is called before the first frame update
    void Start()
    {
        buttonContent = new string[46];
        PopulateButtonContent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceBet()
    {
        int numberChosen = Int32.Parse(EventSystem.current.currentSelectedGameObject.name);

        if (gameController.balance < gameController.selectedChipValue)
        {
            return;
        }

        bool betExists = false;
        int betIndex = 0;
        for (int i = 0; i < gameController.currentBet.Count; i++)
        {
            if (numberChosen == gameController.currentBet[i].bet.id)
            {
                betIndex = i;
                betExists = true;
            }
        }

        if (betExists)
        {
            gameController.UpdateBet(gameController.currentBet[betIndex], gameController.selectedChipValue);
        }
        else
        {
            Bet betToAdd = new Bet(gameController.selectedChipValue, gameController.betOptions[numberChosen]);
            gameController.AddBet(betToAdd);
        }


        UpdateButtons();
    }

    void PopulateButtonContent()
    {
        for(int i = 0;i < 37; i++)
        {
            buttonContent[i] = i.ToString();
        }

        buttonContent[37] = "Black";
        buttonContent[38] = "Red";
        buttonContent[39] = "Odd";
        buttonContent[40] = "Even";
        buttonContent[41] = "1-18";
        buttonContent[42] = "19-36";
        buttonContent[43] = "1st 12";
        buttonContent[44] = "2nd 12";
        buttonContent[45] = "3rd 12";
    }

    public void UpdateButtons()
    {
        RemoveBetTextInButton();

        for(int i = 0; i< gameController.currentBet.Count; i++)
        {
             for(int j = 0; j < gameController.betOptions.Length;j++)
           {
               if ( gameController.currentBet[i].bet.id == gameController.betOptions[j].id)
               {
                    numberButtons[j].GetComponentInChildren<Text>().text = buttonContent[j] + "(" + gameController.currentBet[i].stake + ")";

               }

           }
        }

    }

    public void RemoveBetTextInButton()
    {
        for(int i = 0; i < numberButtons.Length;i++)
        {
            numberButtons[i].GetComponentInChildren<Text>().text = buttonContent[i];
        }
    }
}
