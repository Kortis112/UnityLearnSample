using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    private InteractiveBox next;

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    private void Update()
    {
        if (next != null)
        {
            Vector3 start = transform.position;
            Vector3 end = next.transform.position;

            Debug.DrawLine(start, end, Color.green, 0.1f);

            Ray ray = new Ray(start, (end - start).normalized);
            if (Physics.Raycast(ray, out RaycastHit hit, Vector3.Distance(start, end)))
            {
                ObstacleItem obstacle = hit.collider.GetComponent<ObstacleItem>();
                if (obstacle != null)
                {
                    obstacle.GetDamage(Time.deltaTime);
                }
            }
        }
    }
}
