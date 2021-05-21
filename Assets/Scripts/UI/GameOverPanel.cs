using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        public void Restart()
        => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}