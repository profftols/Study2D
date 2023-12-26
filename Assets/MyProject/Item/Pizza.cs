using UnityEngine;

public class Pizza : MonoBehaviour
{
    private float _heal = 30f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.ToHeal(_heal);
            Destroy(gameObject);
        }
    }
}
