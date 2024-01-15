using UnityEngine;

public class Pizza : MonoBehaviour
{
    private float _heal = 30f;
    private int a => 2+a;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Heal(_heal);
            Destroy(gameObject);
        }
    }

    private int IntChager(int a) => a + 1;
}
