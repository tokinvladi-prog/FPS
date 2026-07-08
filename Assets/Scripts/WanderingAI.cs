using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _obstacleRange = 5f;

    private bool _isAlive = true;

    private void Update()
    {
        if (_isAlive)
            transform.Translate(0f, 0f, _speed * Time.deltaTime);

        var ray = new Ray(transform.position, transform.forward);
        if (Physics.SphereCast(ray, 0.75f, out var hit))
        {
            if (hit.distance < _obstacleRange)
            {
                var angle = Random.Range(-110f, 110f);
                transform.Rotate(0f, angle, 0f);
            }
        }
    }

    public void SetAlive(bool isAlive)
    {
        _isAlive = isAlive;
    }
}
