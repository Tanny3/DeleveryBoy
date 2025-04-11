using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// ����� GameInput �������� �� ��������� ����� �� ������.
// �� ���������� ��� ��������, ����� � ���� ����� ���� ����� ���������� �� ������ ��������.
public class GameInput : MonoBehaviour
{
    // ����������� �������� ��� ������� � ���������� ������ (������� Singleton)
    public static GameInput Instance { get; private set; }

    // ���������� ��� �������� ���������� ������, ���������� � Input System (������������ �������������)
    private PlayerInputActions playerInputActions;

    // ����� Awake ���������� ��� �������� �������. ����� ���������������� ������� �����.
    private void Awake()
    {
        // ������������� ������� ��������� ��� Instance
        Instance = this;

        // ������ ����� ������ �������� �����
        playerInputActions = new PlayerInputActions();

        // �������� �������� �����, ����� ������ ��������� ���� �� ������
        playerInputActions.Enable();
    }

    // ����� ��� ��������� ������� �������� ������ (��������, � ���������� ��� ��������)
    public Vector2 GetMovementVector()
    {
        // ��������� ������� �������� ����� ��� �������� �� ����� ��������
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        // ���������� ������ �������� (��������, (1, 0) � �������� ������)
        return inputVector;
    }

    // �������� ������� ���� �� ������
    public Vector3 GetMousePosition()
    {
        // ������ ������� ������� ����
        Vector3 mousePos = Mouse.current.position.ReadValue();

        // ���������� ��� �������
        return mousePos;
    }
}
