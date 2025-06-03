using UnityEngine;

public class BossZoneActivator : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossCanvas;

    private bool activado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activado) return;

        if (other.CompareTag("Player"))
        {
            ActivarBoss();
            activado = true;
        }
    }

    void ActivarBoss()
    {
        boss.SetActive(true);
        bossCanvas.SetActive(true);

        BossHealth bh = boss.GetComponent<BossHealth>();
        if (bh != null) bh.ActivateHealthBar();
    }
}