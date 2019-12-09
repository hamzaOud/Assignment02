using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button claimCoinsButton;
    public Text balanceText;

    // Start is called before the first frame update
    void Start()
    {
        updateBalance();

#if UNITY_ANDROID
        Screen.orientation = ScreenOrientation.Portrait;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        DateTime lastClaimedTime = Convert.ToDateTime(PlayerPrefs.GetString("LastClaimed"));
        long elapsedTicks = DateTime.Now.Ticks - lastClaimedTime.Ticks;
        TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

        if(elapsedSpan.TotalSeconds <= 86400)
        {
            claimCoinsButton.interactable = false;

            DateTime futureClaimTime = lastClaimedTime.AddDays(1);
            TimeSpan futureSpan = futureClaimTime - System.DateTime.Now;
            claimCoinsButton.GetComponentInChildren<Text>().text = futureSpan.Hours.ToString() 
            + ":" + futureSpan.Minutes.ToString()
            + ":" + futureSpan.Seconds.ToString();
        }
        else
        {
            claimCoinsButton.interactable = true;
        }


    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ClaimCoins()
    {
        int balance = PlayerPrefs.GetInt("Balance");
        balance = balance + 500;
        PlayerPrefs.SetInt("Balance", balance);
        updateBalance();
        PlayerPrefs.SetString("LastClaimed", System.DateTime.Now.ToString());

    }

    void updateBalance()
    {
        balanceText.text = PlayerPrefs.GetInt("Balance").ToString();
    }
}
