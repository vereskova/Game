using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    [Tooltip("Если true, при нажатии Esc игра завершится, если false – загрузится главное меню.")]
    [SerializeField] private bool exitDirectly = false;
    
    [Tooltip("Имя сцены главного меню (если exitDirectly = false).")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Если UI существует и какое-либо подменю активно, то не выполнять выход
            if (UI.instance != null && UI.instance.IsSubMenuActive())
                return;

            // Здесь можно добавить сохранение, если нужно
            if (SaveManager.instance != null)
                SaveManager.instance.SaveGame();

            if (exitDirectly)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(mainMenuSceneName);
            }
        }
    }
}
