using System.Collections;
using System.Collections.Generic;
using CodeMonkey;
using CodeMonkey.Utils;
using UnityEngine;

public class GameHandler : MonoBehaviour {
    [SerializeField] private Snake snake;

    private LevelGrid levelGrid;
    
    private void Start () {
        Debug.Log ("GameHandler.Start");
        int number = 0;
        FunctionPeriodic.Create(() =>
        {
        CMDebug.TextPopupMouse("Don't work with this lady! She a ssssnake" );
        number++;
        }, .5f);
        
        levelGrid = new LevelGrid (20, 20);
        snake.SetUp(levelGrid);
        levelGrid.SetUp(snake);
    }
}