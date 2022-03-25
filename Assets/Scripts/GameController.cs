using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Turn;
    public int Turncounter;
    public GameObject[] Icons;
    public Sprite[] PlayIcons;
    public Button[] Space;
    public int[] MarkedSpaces;
    public Text WinnerText;
    public GameObject[] Strikes;
    public GameObject WinnerPanel;
    public GameObject DrawImage;

    void Start()
    {
        GameSetup();

    }
   
    void GameSetup() 
    {
        Turn = 0;
        Turncounter = 0;
        Icons[0].SetActive(true);
        Icons[1].SetActive(false);

        for (int i = 0; i < Space.Length; i++)
        {
            Space[i].interactable = true;
            Space[i].GetComponent<Image>().sprite = null;

        }
        for (int i = 0; i < MarkedSpaces.Length; i++)
        {
            MarkedSpaces[i] = -100;
        }
    }
    

    public void TicButton(int WhichNumber)
    {
        Space[WhichNumber].image.sprite = PlayIcons[Turn];
        Space[WhichNumber].interactable = false;

        MarkedSpaces[WhichNumber] = Turn + 1;
        Turncounter++;

        if (Turncounter > 4)
        {
            bool isWinner = WinnerCheck();
            WinnerCheck();
            if (Turncounter == 9 && isWinner == false)
            {
                Draw();
            }
        }


        if (Turn == 0)
        {
            Turn = 1;
            Icons[0].SetActive(false);
            Icons[1].SetActive(true);
        }
        else
        {
            Turn = 0;
            Icons[0].SetActive(true);
            Icons[1].SetActive(false);
        }
    }

    bool WinnerCheck()
    {
        int Solution1= MarkedSpaces[0] + MarkedSpaces[1] + MarkedSpaces[2];
        int Solution2 = MarkedSpaces[3] + MarkedSpaces[4] + MarkedSpaces[5];
        int Solution3 = MarkedSpaces[6] + MarkedSpaces[7] + MarkedSpaces[8];
        int Solution4 = MarkedSpaces[0] + MarkedSpaces[3] + MarkedSpaces[6];
        int Solution5 = MarkedSpaces[1] + MarkedSpaces[4] + MarkedSpaces[7];
        int Solution6 = MarkedSpaces[2] + MarkedSpaces[5] + MarkedSpaces[8];
        int Solution7 = MarkedSpaces[0] + MarkedSpaces[4] + MarkedSpaces[8];
        int Solution8 = MarkedSpaces[2] + MarkedSpaces[4] + MarkedSpaces[6];
        var solutions = new int[] { Solution1, Solution2, Solution3, Solution4, Solution5, Solution6, Solution7, Solution8 };
        for (int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3 * (Turn + 1))
            {
                WinnerDisplay(i);
                return true;
            }
        }
        return false;
    }
    void WinnerDisplay(int indexIn)
    {
        WinnerPanel.gameObject.SetActive(true);
        if (Turn == 0)
        {
            WinnerText.text = "Player X Wins!!";
        }
        else if (Turn == 1)
        {
            WinnerText.text = "Player O Wins!!";
        }
        Strikes[indexIn].SetActive(true);
        


    }
    public void Restart()
    {
        GameSetup();
        for(int i =0; i < Strikes.Length; i ++)
        {
            Strikes[i].SetActive(false);
        }
        WinnerPanel.SetActive(false);
        DrawImage.SetActive(false);
    }
    void Draw()
    {
        WinnerPanel.SetActive(true);
        DrawImage.SetActive(true);
        WinnerText.text = "Draw";
    }
    public void Quit()
    {
        Application.Quit();
    }
}
