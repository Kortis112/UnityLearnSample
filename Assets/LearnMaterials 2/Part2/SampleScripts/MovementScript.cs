using UnityEngine;

public class MovementScript : SampleScript
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 targetPosition;
    private bool isMoving = false;

    [ContextMenu("Run")]
    public override void Use()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToTarget());
        }
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }
}