using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab;
    private InteractiveBox selectedBox;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleLeftClick();
        }

        if (Input.GetMouseButtonDown(1))
        {
            HandleRightClick();
        }
    }

    void HandleLeftClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 0.1f);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject clickedObj = hit.collider.gameObject;

            if (clickedObj.CompareTag("InteractivePlane"))
            {
                Vector3 spawnPos = hit.point + hit.normal * 0.5f;
                Instantiate(prefab, spawnPos, Quaternion.identity);
            }
            else if (clickedObj.TryGetComponent<InteractiveBox>(out var box))
            {
                if (selectedBox == null)
                {
                    selectedBox = box;
                }
                else
                {
                    selectedBox.AddNext(box);
                    selectedBox = null;
                }
            }
        }
    }

    void HandleRightClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue, 0.1f);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<InteractiveBox>(out var box))
            {
                Destroy(box.gameObject);
            }
        }
    }
}
