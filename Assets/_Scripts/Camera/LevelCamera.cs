using UnityEngine;

namespace MonjasProject.Camera
{
    public class LevelCamera : MonoBehaviour
    {
        [SerializeField]
        private Transform m_target = null;

        [SerializeField]
        private float m_smoothSpeed = 0.125f;

        [SerializeField]
        private Vector3 m_offset = Vector3.zero;

        private bool m_freezed = false;
        public void Freeze()
        {
            m_freezed = true;
        }
        public void Unfreeze()
        {
            m_freezed = false;
        }

        private void Awake()
        {
            if (m_target == null)
            {
                Debug.LogError("Target transform is not assigned in the " + gameObject.name);
            }
        }

        private void FixedUpdate()
        {
            if (m_freezed)
            {
                return;
            }

            Vector3 desiredPosition = m_target.position + m_offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
