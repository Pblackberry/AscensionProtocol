using UnityEngine;

public class ArmAiming : MonoBehaviour
{
    public Transform rightArmBone; // bone_3
    public Transform leftArmBone;  // bone_4
    public Camera mainCamera;
    public Transform characterTransform; // << Agregamos la referencia al personaje que se voltea

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        if (mousePosition.x > characterTransform.position.x)
        {
            characterTransform.localScale = new Vector3(-1f, characterTransform.localScale.y, characterTransform.localScale.z);
        }
        else
        {
            characterTransform.localScale = new Vector3(1f, characterTransform.localScale.y, characterTransform.localScale.z);
        }

        AimArm(rightArmBone, mousePosition);
       // AimArm(leftArmBone, mousePosition);
    }

    private void AimArm(Transform armBone, Vector3 targetPosition)
    {
        if (armBone == null || characterTransform == null) return;

        Vector2 direction = (targetPosition - armBone.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Detectar si el personaje está volteado
        if (characterTransform.localScale.x < 0)
        {
            angle += 180f; // Invertimos el ángulo si el personaje está volteado
        }

        

        armBone.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}


