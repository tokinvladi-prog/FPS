using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _damage = 1;

    private void Update()
    {
        transform.Translate(0f, 0f, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacter>(out var player))
        {
            player.Hurt(_damage);
        }
        Destroy(gameObject);
    }
}
