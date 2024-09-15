using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var killable = other.gameObject.GetComponent<IKillable>();
        killable?.Kill();
    }
}