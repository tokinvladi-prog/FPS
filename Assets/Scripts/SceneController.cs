using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    private GameObject _enemy;

    private void Update()
    {
        if (_enemy == null)
        {
            var angle = Random.Range(0f, 360f);
            _enemy = Instantiate(_enemyPrefab, 
                transform.position, Quaternion.Euler(0f, angle, 0f));
        }
    }
}
