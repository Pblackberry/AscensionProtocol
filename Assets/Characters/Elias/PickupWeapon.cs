using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PickupWeapon : MonoBehaviour
{
    public string jugadorTag = "Player";
    private bool jugadorCerca = false;
    private Transform puntoDisparo;
    public Transform characterTransform;
    public Light2D luz2D;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            EquiparArma();
        }
    }

    private void EquiparArma()
    {
        if (puntoDisparo != null)
        {
            transform.SetParent(puntoDisparo);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            if (characterTransform.localScale.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                transform.localRotation = Quaternion.identity;
            }

            if (GetComponent<Rigidbody2D>() != null)
                GetComponent<Rigidbody2D>().simulated = false;

            if (GetComponent<Collider2D>() != null)
                GetComponent<Collider2D>().enabled = false;
            
            if (characterTransform != null)
            {
                Disparo disparoScript = characterTransform.GetComponent<Disparo>();
                if (disparoScript != null)
                {
                    disparoScript.tieneArma = true;
                    disparoScript.armaEquipada = this.gameObject;
                    Debug.Log("✅ Arma equipada, disparo habilitado.");
                }
                else
                {
                    Debug.LogWarning("⚠️ No se encontró el script Disparo en el jugador.");
                }
            }
            luz2D.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(jugadorTag))
        {
            jugadorCerca = true;

            // 🔄 Esta línea es la clave corregida:
            puntoDisparo = collision.transform.GetComponentInChildren<Transform>(true).Find("bone_3/PuntoDisparo");

            if (puntoDisparo == null)
            {
                Debug.LogWarning("No se encontró el PuntoDisparo en el jugador.");
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(jugadorTag))
        {
            jugadorCerca = false;
            puntoDisparo = null;
        }
    }
}



