using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundNumber : MonoBehaviour
{
    public Text RoundText;
    public int roundNum;

    // Start is called before the first frame update
    void Start()
    {
        DisplayRound(roundNum);
    }

    // Update is called once per frame
    void Update()
    {
        roundNum = RoundControl.round;
        DisplayRound(roundNum);
    }

    public void DisplayRound(float roundNumber)
    { 
        int roundNumber2 = Mathf.FloorToInt(roundNumber);
        RoundText.text = string.Format("Round {0}", roundNumber2);
    }
}
