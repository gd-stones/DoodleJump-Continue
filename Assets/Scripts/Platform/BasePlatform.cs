using UnityEngine;
using DG.Tweening;

public class BasePlatform : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private Transform viewTransform;
    [SerializeField] private Renderer viewRenderer;

    public void OnEnable()
    {
        DescalePlatf();

        EventManager.ScalePlatfs += ScalePlatf;
        EventManager.DescalePlatfs += DescalePlatf;
    }
    
    public void OnDisable()
    {
        DescalePlatf();

        EventManager.ScalePlatfs -= ScalePlatf;
        EventManager.DescalePlatfs -= DescalePlatf;
    }

    public void Start()
    {
        mainCamera = Camera.main;
    }

    public void LateUpdate()
    {
        if (IsVisibleByCamera() == false)
            SimplePool.Despawn(gameObject);
    }

    public bool IsVisibleByCamera()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        Bounds objectBounds = viewRenderer.bounds;

        return objectBounds.min.y > -planes[2].distance;
    }

    public void ScalePlatf()
    {
        if (viewTransform.localScale == Vector3.one)
            viewTransform.DOScaleX(1.5f, 1f);
        if (box.size.x == 1f)
            box.size = new Vector2(box.size.x * 1.5f, box.size.y);
    }

    public void DescalePlatf()
    {
        if (viewTransform.localScale.x > 1f)
            viewTransform.DOScaleX(1f, 1f);
        if (box.size.x > 1f)
            box.size = new Vector2(1f, box.size.y);
    }
}