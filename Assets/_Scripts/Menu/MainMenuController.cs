using MonjasProject.Scenes;
using UnityEngine;

namespace MonjasProject.Menu
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartBtn()
        {
            ScenesManager.Instance.LoadScene("LevelTest");
        }

        public void ExitBtn()
        {
            Application.Quit();
        }
    }
}
