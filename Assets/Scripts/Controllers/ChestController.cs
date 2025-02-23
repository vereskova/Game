using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestController : MonoBehaviour
{
    [Header("Ссылки")]
    [Tooltip("Ссылка на компонент ItemDrop, который отвечает за выпадение предметов")]
    [SerializeField] private ItemDrop itemDrop; 
    [Header("Настройки перехода")]
    [Tooltip("Задержка перед переходом на сцену с титрами после открытия сундука")]
    [SerializeField] private float delayBeforeSceneChange = 5f;

    private Animator anim;

    private void Awake()
    {
        // Получаем Animator с этого объекта
        anim = GetComponent<Animator>();

        // Если itemDrop не назначен в инспекторе, попробуем найти его на том же объекте
        if(itemDrop == null)
            itemDrop = GetComponent<ItemDrop>();

        if(itemDrop == null)
            Debug.LogWarning("ItemDrop не найден на сундуке!");
    }

    private void OnEnable()
    {
        // Как только сундук становится активным, запускаем анимацию открытия
        anim.SetTrigger("Open");
    }

    // Этот метод вызывается через Animation Event в конце клипа "OpenChest"
    public void OnChestOpenComplete()
    {
        // Генерируем выпадения предметов
        if(itemDrop != null)
            itemDrop.GenerateDrop();
        else
            Debug.LogWarning("ItemDrop не назначен!");

        // После задержки переключаем сцену (или показываем титры UI)
        StartCoroutine(EndGameAfterDelay());
    }

    private IEnumerator EndGameAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeSceneChange);
        // Замените "MainTheEnd" на имя вашей сцены с титрами, и не забудьте добавить её в Build Settings
        SceneManager.LoadScene("MainTheEnd");
    }
}
