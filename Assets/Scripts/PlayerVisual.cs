using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Этот скрипт отвечает за внешний вид игрока:
// включает/выключает анимацию бега и поворачивает спрайт в сторону мыши
public class PlayerVisual : MonoBehaviour
{
    private Animator animator;              // Компонент, который управляет анимацией
    private SpriteRenderer spriteRenderer;  // Отвечает за то, как выглядит спрайт игрока

    private const string IS_RUNNING = "IsRunning"; // Название параметра в Animator'е

    // Когда объект запускается (до Start), сохраняем ссылки на компоненты
    private void Awake()
    {
        animator = GetComponent<Animator>();             // Ищем Animator на этом объекте
        spriteRenderer = GetComponent<SpriteRenderer>(); // Ищем SpriteRenderer на этом объекте
    }

    // Каждый кадр (каждую секунду игры) проверяем, нужно ли менять анимацию или поворот
    private void Update()
    {
        // Проверяем, бежит ли игрок. Если да — запускаем анимацию бега.
        // Если нет — анимация бега выключается.
        animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());

        // Поворачиваем игрока в сторону, куда смотрит мышка
        AdjustPlayerFacingDirection();
    }

    // Этот метод разворачивает игрока влево или вправо, в зависимости от положения мышки
    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();              // Получаем, где мышка на экране
        Vector3 playerPosition = Player.Instance.GetPlayerScreenPosition();    // Получаем, где находится игрок на экране

        // Если мышка левее игрока — поворачиваем спрайт влево
        if (mousePos.x < playerPosition.x)
        {
            spriteRenderer.flipX = true; // Поворачиваем спрайт по горизонтали
        }
        else
        {
            spriteRenderer.flipX = false; // Иначе поворот отключаем (смотрим вправо)
        }
    }
}
