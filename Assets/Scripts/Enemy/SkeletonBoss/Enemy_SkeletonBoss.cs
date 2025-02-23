using System.Collections;
using UnityEngine;

public class Enemy_SkeletonBoss : Enemy_Skeleton
{
    [Header("End Game Settings")]
    [Tooltip("Объект стены, который блокирует путь. При смерти босса отключается.")]
    public GameObject bossWall;
    
    [Tooltip("Объект сундука, который появляется после смерти босса.")]
    public GameObject chest;
    
    [Tooltip("Объект UI с титрами (если используется). Если не указан, будет загружена отдельная сцена.")]
    public GameObject creditsUI;
    
    [Tooltip("Задержка перед переходом к титрам (если creditsUI не указан).")]
    public float creditsDelay = 5f;

    protected override void Awake()
    {
        // Вызываем базовый Awake, где создаются все состояния скелета
        base.Awake();
        // При необходимости можно изменить параметры босса (moveSpeed, attackDistance, и т.д.)
    }

    protected override void Start()
    {
        base.Start();
        // Босс начнёт работу в idleState, как обычный скелет
    }

    public override void Die()
    {
        // Вызываем стандартную логику смерти (анимация, отключение коллайдера и т.п.)
        base.Die();

        // После смерти запускаем цепочку окончания игры
        OnBossDefeated();
    }

    private void OnBossDefeated()
    {
        // Отключаем стену (она больше не должна блокировать путь)
        if (bossWall != null)
            bossWall.SetActive(false);

        // Активируем сундук, чтобы он появился в сцене и открылся (OnEnable в ChestController сработает)
        if (chest != null)
            chest.SetActive(true);

        // Если вы используете creditsUI вместо перехода через сундук,
        // можно здесь запустить логику отображения титров.
        // Но если сундук отвечает за переход, оставьте это пустым.
    }
}
