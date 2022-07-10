using UnityEngine;

namespace MyInput
{
    public class MyInputs : MonoBehaviour
    {
        public InputMap input;

        private void Awake()
        {
            input = new InputMap();
            input.Player.Enable();
        }

        private void OnEnable()
        {
            input.Player.Enable();
        }

        private void OnDisable()
        {
            input.Player.Disable();
        }

        public void EnableHUDControl()
        {
            input.Player.Disable();
            input.HUD.Enable();
        }

        public void EnablePlayerControl()
        {
            input.HUD.Disable();
            input.Player.Enable();
        }
    }
}