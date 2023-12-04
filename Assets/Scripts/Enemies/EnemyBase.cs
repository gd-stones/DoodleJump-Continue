using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //private Camera mainCamera;
    //[SerializeField] private Renderer viewRenderer;

    //public void Start()
    //{
    //    mainCamera = Camera.main;
    //}

    //public void LateUpdate()
    //{
    //    if (IsVisibleByCamera() == false)
    //        SimplePool.Despawn(gameObject);
    //}

    //public bool IsVisibleByCamera()
    //{
    //    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
    //    Bounds objectBounds = viewRenderer.bounds;

    //    return objectBounds.max.y > -planes[2].distance;
    //}

    private void OnEnable()
    {
        EventManager.ActivateSword += CheckActiveSword;
    }

    private void OnDisable()
    {
        EventManager.ActivateSword -= CheckActiveSword;
    }

    private bool isActiveSword = false;
    private void CheckActiveSword() => isActiveSword = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check va cham voi bullet, player - neu isSheildActive, isSwordActive
        if (collision.CompareTag("Player"))
        {
            if (isActiveSword)
            {
                isActiveSword = false;
                EventManager.DisableSwordFeature(); // turn off the player's sword display
                SimplePool.Despawn(gameObject);
            }
            //GameManager.Instance.isGameOver = true;
        }
    }
}
