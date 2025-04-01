using System.Collections;
using UnityEngine;

public class RotationScript : SampleScript
{
    [SerializeField] private Vector3 targetRotation = new Vector3(0, 90, 0);
    [SerializeField] private float rotationSpeed = 10f;
    private Quaternion startRotation;
    private bool isRotating;

    private void Start() => startRotation = transform.rotation;

    [ContextMenu("Запуск скрипта")]
    public override void Use()
    {
        if (!isRotating)
            StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        isRotating = true;
        Quaternion target = Quaternion.Euler(targetRotation);
        float angle = Quaternion.Angle(transform.rotation, target);
        float duration = angle / rotationSpeed;

        float elapsed = 0;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = target;
        isRotating = false;
    }
}