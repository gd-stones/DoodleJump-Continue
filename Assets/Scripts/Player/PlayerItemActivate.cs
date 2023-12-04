using UnityEngine;

public class PlayerItemActivate : MonoBehaviour
{
    [SerializeField] private GameObject viewSwordPlayer;
    [SerializeField] private GameObject viewShieldPlayer;
    //[SerializeField] private GameObject viewRocketPlayer;
    //[SerializeField] private GameObject viewSpringsPlayer;

    private void OnEnable()
    {
        EventManager.ActivateShield += ActivateViewShield;
        EventManager.DeactivateShield += DeactivateViewShield;

        EventManager.ActivateSword += ActivateViewSword;
        EventManager.DeactivateSword += DeactivateViewSword;
    }

    private void OnDisable()
    {
        EventManager.ActivateShield -= ActivateViewShield;
        EventManager.DeactivateShield -= DeactivateViewShield;

        EventManager.ActivateSword -= ActivateViewSword;
        EventManager.DeactivateSword -= DeactivateViewSword;
    }

    private void ActivateViewSword() => viewSwordPlayer.SetActive(true);
    private void DeactivateViewSword() => viewSwordPlayer.SetActive(false);

    private void ActivateViewShield() => viewShieldPlayer.SetActive(true);
    private void DeactivateViewShield() => viewShieldPlayer.SetActive(false);
}
