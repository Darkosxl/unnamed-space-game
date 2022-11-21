using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemaster : MonoBehaviour
{
    // Start is called before the first frame update
    private int round;
    private int currentScene;

    void Start()
    {
        round = 0;
        currentScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playScene(int num)
    {
        SceneManager.LoadScene(sceneBuildIndex: num);
        currentScene = num;
        //1, menu, 2, game itself, 3, cinematic

    }
    public void startGame()
    {
        //IntroCinematicPlay();
        playScene(3);
        
        round++;
        playRound();
    }
    public void playRound()
    {
        //dashIntoSceneCinematic();
        //makeTextPop(); //ROUND 1, 5, 4, 3, 2, 1, START

    }
}
