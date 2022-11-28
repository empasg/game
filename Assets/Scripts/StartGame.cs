using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public void _StartGame()
    {

        SceneManager.LoadScene("Game", LoadSceneMode.Single);

    }

    public void _LeaveGame()
    {

        Application.Quit();

    }

}
