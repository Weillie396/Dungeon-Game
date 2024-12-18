
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGameLoad()
    {
        SceneManager.LoadScene("MainLobby");
    }

}
