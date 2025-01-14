using UnityEngine;

public class InputActions : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;

    public Vector2 MoveDir;
    public bool Jump;
    public bool Shoot;


    private void Update()
    {
        MoveDir = _inputSystem.Player.Move.ReadValue<Vector2>();
        Jump = _inputSystem.Player.Jump.WasPressedThisFrame();
        Shoot = _inputSystem.Player.Attack.WasPressedThisFrame();
    }

    private void Awake() { _inputSystem = new InputSystem_Actions(); }

    private void OnEnable() { _inputSystem.Enable(); }

    private void OnDisable() { _inputSystem.Disable(); }
}