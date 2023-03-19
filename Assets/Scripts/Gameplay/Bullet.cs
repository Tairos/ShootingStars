using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] LayerMask _targetMask;
    [SerializeField] LayerMask _wallMask;
    [SerializeField] GameConfig _gameConfig;

    int bouncesCount;

    public void OnCollisionEnter(Collision other)
    {
        if ((_targetMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if ((_wallMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            bouncesCount++;
            if (bouncesCount > _gameConfig.MaxBounces)
            {
                Destroy(gameObject);
            }
        }
    }
}
