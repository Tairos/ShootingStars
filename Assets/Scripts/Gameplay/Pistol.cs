using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : MonoBehaviour
{
    [SerializeField] ActionBasedController _actionBaseController;
    [SerializeField] GameplayController _gameplayController;
    [SerializeField] GameConfig _gameConfig;
    [SerializeField] Transform _transform;

    float _nextBulletSpawnTime;

    void Awake()
    {
        _actionBaseController.activateAction.action.performed += Trigger;
    }

    private void Trigger(InputAction.CallbackContext obj)
    {
        if (!_gameplayController.IsPlaying || _nextBulletSpawnTime > Time.time)
        {
            return;
        }
        
        var bullet = Instantiate(_gameConfig.BulletPrefab, _transform.position + (_transform.forward * _gameConfig.BulletSpawnDistance), _transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = (_transform.forward * _gameConfig.BulletVelocity);
        _nextBulletSpawnTime = Time.time + _gameConfig.BulletSpawnDelay;
    }

    void OnDestroy()
    {
        _actionBaseController.activateAction.action.performed += Trigger;
    }
}
