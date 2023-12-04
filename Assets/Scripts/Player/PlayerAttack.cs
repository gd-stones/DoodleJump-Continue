using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Firepoint Player Attack")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firepoint;
    [SerializeField] private AudioClip attackSound;
    private bool attack;

    void Update()
    {
        attack = GetInput.isSpacePressed;

        if (attack)
            ShootBullets();
    }

    void ShootBullets()
    {
        SoundManager.Instance.PlaySound(attackSound);

        // Shoot bullet
        SimplePool.Spawn(bullet, firepoint.position, Quaternion.identity); // thieu phan di chuyen cua dan, deactive?
    }
}
