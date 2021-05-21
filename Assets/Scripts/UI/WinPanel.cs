using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class WinPanel : MonoBehaviour
    {
        public void Restart()
        => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
