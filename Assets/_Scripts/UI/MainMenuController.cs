using MonjasProject.Scenes;
using UnityEngine;

namespace MonjasProject.UI
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
