using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    public void PressForGameState(int state)
    {
        Debug.Log("Button clicked");
        switch (state)
        {
            case 0:
                GameManager.Instance.UpdateGameState(GameState.Tutorial);
                break;
            case 1:
                GameManager.Instance.UpdateGameState(GameState.Start1);
                break;
            case 2:
                GameManager.Instance.UpdateGameState(GameState.Start2);
                break;
            case 3:
                GameManager.Instance.UpdateGameState(GameState.Start3);
                break;
            case 4:
                GameManager.Instance.UpdateGameState(GameState.Playing);
                break;
            case 5:
                GameManager.Instance.UpdateGameState(GameState.Win);
                break;
            case 6:
                GameManager.Instance.UpdateGameState(GameState.Reflection);
                break;
            default:
                Debug.LogError("Gamestate out of range");
                break;
        }

    }
}
