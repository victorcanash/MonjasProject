using MonjasProject.UI;
using UnityEngine;

namespace MonjasProject.Player
{
    public class PlayerController : MonoBehaviour
    {
        public LevelUI LevelUI = null;

        [SerializeField]
        private CharacterMovement m_characterMovement = null;

        private void Awake()
        {
            m_characterMovement.PlayerController = this;
        }
    }
}
