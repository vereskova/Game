using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // Вызываем базовый Awake, где создаются все состояния.
        base.Awake();
        
        // При необходимости можно менять параметры босса:
        // moveSpeed = 2.5f;
        // attackDistance = 2f;
    }

    protected override void Start()
    {
        base.Start();
        // Босс начнёт работу в idleState (так же, как обычный скелет)
    }

    public override void Die()
    {
        // Вызываем стандартную логику смерти (например, проигрывается анимация, отключается коллайдер и т.п.)
        base.Die();
        // Запускаем нашу логику окончания игры после смерти босса.
        OnBossDefeated();
    }

    private void OnBossDefeated()
    {
        // Открываем стену: отключаем объект стены
        if (bossWall != null)
            bossWall.SetActive(false);

        // Показываем сундук: включаем объект сундука
        if (chest != null)
            chest.SetActive(true);

        // Если у вас есть UI с титрами, показываем его
        if (creditsUI != null)
        {
            creditsUI.SetActive(true);
        }
        else
        {
            // Если UI нет, через некоторое время загружаем сцену с титрами
            StartCoroutine(LoadCreditsAfterDelay(creditsDelay));
        }
    }

    private IEnumerator LoadCreditsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainTheEnd");
    }
}
