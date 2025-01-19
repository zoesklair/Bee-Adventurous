using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;
    GameOverScreen gameOverScreen;

    private void Awake()
    {
        gameOverScreen = gameOverPanel.GetComponent<GameOverScreen>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGameOver()
    {
        Debug.Log("game over");
        gameOverScreen.MakeGameOverPanelActive();
    }
}
