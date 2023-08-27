using UnityEngine;

namespace CodeBase.Bonus
{
    public class Bonus:MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.TryGetComponent<Player>(out Player player))
            {
                player.TakeHealth();
                Destroy();
            }
        
            if (collider2D.TryGetComponent(out DestroyGameObject _destroyGameObject)) 
                Destroy();
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}