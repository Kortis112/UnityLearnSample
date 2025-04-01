using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class ObstacleItem : MonoBehaviour
{
    [Range(0f, 1f)]
    public float currentValue = 1f;
    public UnityEvent onDestroyObstacle;

    private Renderer rend;
    private Color healthyColor = Color.white;
    private Color damagedColor = Color.red;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateColor();
    }

    private void Update()
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        rend.material.color = Color.Lerp(damagedColor, healthyColor, currentValue);
    }

    public void GetDamage(float value)
    {
        currentValue -= value;
        currentValue = Mathf.Clamp01(currentValue);

        Debug.Log("Current Value: " + currentValue);

        if (currentValue <= 0)
        {
            Debug.Log("Obstacle is destroyed! Triggering event...");
            onDestroyObstacle?.Invoke();
            Destroy(gameObject); 
        }
    }

}
