using UnityEngine;

namespace MonjasProject.Scenes
{
    public class SplashScreenController : MonoBehaviour
    {
        private void Start()
        {
            Invoke("LoadScene", 2f); 
        }

        private void LoadScene()
        {
            ScenesManager.Instance.LoadScene("MainMenu");
        }
    }
}
