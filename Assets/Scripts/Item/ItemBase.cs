using UnityEngine;

public class ItemBase : MonoBehaviour
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
    //    {
    //        Destroy(gameObject);
    //        //SimplePool.Despawn(gameObject);
    //    }    
    //}

    //public bool IsVisibleByCamera()
    //{
    //    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
    //    Bounds objectBounds = viewRenderer.bounds;

    //    return objectBounds.max.y > -planes[2].distance;
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SimplePool.Despawn(gameObject);
        }
    }
}
