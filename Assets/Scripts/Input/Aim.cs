using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;

    private void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        Vector3 aimDirection = (GetMouseWorldPosition() - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPosition;
    }
}
