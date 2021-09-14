using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Text playerName;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SetName()
    {
        MainGameManager.Instance.playerName = playerName.text;
        Debug.Log("Name In");
    }
}
