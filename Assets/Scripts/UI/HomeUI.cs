using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] menus;

    public Button cancelBtn;

    private void Awake()
    {
        cancelBtn.gameObject.SetActive(false);
        cancelBtn.onClick.AddListener(CancelFunc);

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => ActivateFunc(index));

            menus[i].SetActive(false);
        }
    }

    public void ActivateFunc(int index)
    {
        menus[index].SetActive(true);
        cancelBtn.gameObject.SetActive(true);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }

    public void CancelFunc()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            menus[i].SetActive(false);
            buttons[i].gameObject.SetActive(true);
        }
        cancelBtn.gameObject.SetActive(false);
    }
}
