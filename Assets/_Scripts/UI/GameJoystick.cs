﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace MonjasProject.UI
{
    public class GameJoystick : Joystick
    {
        public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

        [SerializeField] private float moveThreshold = 1;
        [SerializeField] private JoystickType joystickType = JoystickType.Fixed;

        private Vector2 fixedPosition = Vector2.zero;

        public void SetMode(JoystickType joystickType)
        {
            this.joystickType = joystickType;
            if (joystickType == JoystickType.Fixed)
            {
                background.anchoredPosition = fixedPosition;
            }
        }

        protected override void Start()
        {
            base.Start();
            fixedPosition = background.anchoredPosition;
            SetMode(joystickType);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (joystickType != JoystickType.Fixed)
            {
                background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            }
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            background.anchoredPosition = fixedPosition;
        }

        protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, UnityEngine.Camera cam)
        {
            if (joystickType == JoystickType.Dynamic && magnitude > moveThreshold)
            {
                Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
                background.anchoredPosition += difference;
            }
            base.HandleInput(magnitude, normalised, radius, cam);
        }
    }
}
