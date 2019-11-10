using System.Collections;
using System.Collections.Generic;
using CodeMonkey;
using CodeMonkey.Utils;
using UnityEngine;

public class LevelGrid : MonoBehaviour {
    private Vector2Int foodGridPosition;
    private int width;
    private int height;
    private GameObject foodGameObject;
    private Snake snake;

    public LevelGrid (int width, int height) {
        this.width = width;
        this.height = height;
        FunctionPeriodic.Create (SpawnFood, 1f);
    }

    public void SetUp(Snake snake){
        this.snake = snake;
        SpawnFood();

        FunctionPeriodic.Create(SpawnFood, 1f);
    }

    private void SpawnFood () {
      //do { 
          foodGridPosition = new Vector2Int (Random.Range (0, width), Random.Range (0, height)); 
        //  }
      // while ((snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition)) != -1);

        GameObject foodGameObject = new GameObject ("FoodApple", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer> ().sprite = GameAssets.i.foodSprite;
        foodGameObject.transform.position = new Vector3 (foodGridPosition.x, foodGridPosition.y);
    }

    public bool TrySnakeEatFood (Vector2Int snakeGridPosition) {
        if (snakeGridPosition == foodGridPosition) {
            Object.Destroy (foodGameObject);
            SpawnFood ();
            return true;
        }
        return false;
    }
}