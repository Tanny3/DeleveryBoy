using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ������: �������� �� �������� � ������� �� ������
public class Player : MonoBehaviour
{
    // Singleton � ������ � ������ �� ������ ��������
    public static Player Instance { get; private set; }

    // �������� ������������
    [SerializeField] private float movingSpeed = 10f;

    // ����������� �������� (�� �����)
    Vector2 inputVector;

    // ��������� ������ 2D
    private Rigidbody2D rb;

    // ����������� �������� ��� �����������, �������� �� �����
    private float minMovingSpeed = 0.1f;

    // ����: ����� ����� ��� �����
    private bool isRunning = false;

    // ��� �������: ��������� ������ �� ���� � �� Rigidbody
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // ������ ���� ��������� ���� �� ������
    private void Update()
    {
        inputVector = GameInput.Instance.GetMovementVector();
    }

    // ������ � ����������� ����� ������ ���������� �������
    private void FixedUpdate()
    {
        HandleMovement();
    }

    // ��������� ������������
    private void HandleMovement()
    {
        // ���������� ������ � ������ ������� � �����������
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        // ���������, ���� �� �������� (�� x ��� y)
        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    // ��������: �������� �� �����
    public bool IsRunning()
    {
        return isRunning;
    }

    // �������� �������� ������� ������ (��� UI � �.�.)
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
