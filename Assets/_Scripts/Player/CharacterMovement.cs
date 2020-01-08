using UnityEngine;

namespace MonjasProject.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : Character
    {
        [SerializeField]
        private CharacterController m_characterController = null;

        private VariableJoystick m_moveJoystick = null;

        [SerializeField]
        private float m_speed = 10;

        public bool LookAheadEnabled { get; set; }

        private void Awake()
        {
            LookAheadEnabled = true;
        }

        private void Start()
        {
            m_moveJoystick = PlayerController.LevelUI.HUD.MoveJoystick;
        }

        private void FixedUpdate()
        {
            Move();
            if (LookAheadEnabled)
            {
                LookAhead();
            }
        }

        private void Move()
        {
            Vector3 direction = new Vector3(m_moveJoystick.Direction.x, 0, m_moveJoystick.Direction.y);
            if (direction.magnitude < 0.1f)
            {
                return;
            }

            m_characterController.Move(direction.normalized * m_speed * Time.deltaTime);
        }

        private void LookAhead()
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(m_moveJoystick.Direction.x, 0, m_moveJoystick.Direction.y));
        }
    }
}
