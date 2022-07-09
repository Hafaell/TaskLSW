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
    }
}