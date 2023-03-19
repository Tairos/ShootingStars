using UnityEngine;

public class GameplayTargetsController : MonoBehaviour
{
    [SerializeField] int _loadTime = 6;
    [SerializeField] Target _targetPrefab;
    [SerializeField] Transform _parent;
    [SerializeField] Transform _topRightFrontAnchor;
    [SerializeField] Transform _botLeftBackAnchor;
    [SerializeField] float _padding = 1;
    [SerializeField] float _playerDistancing = 2;
    [SerializeField] Transform _playerPosition;

    Vector3 _topRightFrontFromPlayer;
    Vector3 _botLeftBacktFromPlayer;

    Target[] _targets;
    ScalingData[] _scales;
    float _scaleTime;

    struct ScalingData {
        public float StartAt;
        public float EndAt;
        public float FinalScale;
    }

    void Awake()
    {
        var distancingVector = new Vector3(_playerDistancing, _playerDistancing, _playerDistancing);
        _topRightFrontFromPlayer = _playerPosition.position + distancingVector;
        _botLeftBacktFromPlayer = _playerPosition.position - distancingVector;
        _scaleTime = _loadTime;
    }

    public void Instantiate(GameConfig _gameConfig)
    {
        var amount = Random.Range(_gameConfig.CubesAmountMin, _gameConfig.CubesAmountMax);
        _targets = new Target[amount];
        _scales = new ScalingData[amount];
        for (var i = 0; i < amount; i++)
        {
            var newTarget = Instantiate(_targetPrefab, CreateRandomPosition(), GetRandomRotation(), _parent);
            var colorIndex = Random.Range(0, _gameConfig.Colors.Length);
            newTarget.SetColor(_gameConfig.Colors[colorIndex]);
            newTarget.transform.localScale = Vector3.zero;

            _targets[i] = newTarget;
            _scales[i] = CreateRandomScalingData(_gameConfig.TargetScaleMin, _gameConfig.TargetScaleMax);
        }
        _scaleTime = 0;
    }

    void Update()
    {
        if (_loadTime <= _scaleTime)
        {
            return;
        }

        _scaleTime += Time.deltaTime;
        var scalesDataLength = _scales.Length;
        for (var i = 0; i < scalesDataLength; i++)
        {
            var scaleData = _scales[i];
            if (_scaleTime < scaleData.StartAt || _scaleTime > scaleData.EndAt)
            {
                continue;
            }

            var duration = scaleData.EndAt - scaleData.StartAt;
            var completedFraction = (_scaleTime - scaleData.StartAt) / duration;
            completedFraction = Mathf.Min(completedFraction, 1);
            _targets[i].transform.localScale = Vector3.one * completedFraction * scaleData.FinalScale;
        }
    }

    public Vector3 CreateRandomPosition()
    {
        var x = Random.Range(_botLeftBackAnchor.position.x + _padding, _topRightFrontAnchor.position.x - _padding);
        var y = Random.Range(_botLeftBackAnchor.position.y + _padding, _topRightFrontAnchor.position.y - _padding);
        var z = Random.Range(_botLeftBackAnchor.position.z + _padding, _topRightFrontAnchor.position.z - _padding);

        return ApplyTooCloseToPlayerCorrection(new Vector3(x, y, z));
    }

    public Vector3 ApplyTooCloseToPlayerCorrection(Vector3 position)
    {
        var xBackLimit = position.x - _botLeftBacktFromPlayer.x;
        var xFrontLimit = _topRightFrontFromPlayer.x - position.x;
        var yBackLimit = position.y - _botLeftBacktFromPlayer.y;
        var yFrontLimit = _topRightFrontFromPlayer.y - position.y;
        var zBackLimit = position.z - _botLeftBacktFromPlayer.z;
        var zFrontLimit = _topRightFrontFromPlayer.z - position.z;

        if (xBackLimit < 0 || xFrontLimit < 0 || yBackLimit < 0 || yFrontLimit < 0 || zBackLimit < 0 || zFrontLimit < 0)
        {
            return position;
        }

        /*
         * enum 
         * 0 = MoveXToBack,
         * 1 = MoveXToFront,
         * 2 = MoveYToBack,
         * 3 = MoveYToFront,
         * 4 = MoveZToBack,
         * 5 = MoveZToFront,
         */
        var changeToApply = Random.Range(0, 6);
        switch (changeToApply)
        {
            case 0:
                position.x = Random.Range(_botLeftBackAnchor.position.x + _padding, _botLeftBacktFromPlayer.x);
                break;
            case 1:
                position.x = Random.Range(_topRightFrontFromPlayer.x, _topRightFrontAnchor.position.x - _padding);
                break;
            case 2:
                position.y = Random.Range(_botLeftBackAnchor.position.y + _padding, _botLeftBacktFromPlayer.y);
                break;
            case 3:
                position.y = Random.Range(_topRightFrontFromPlayer.y, _topRightFrontAnchor.position.y - _padding);
                break;
            case 4:
                position.z = Random.Range(_botLeftBackAnchor.position.z + _padding, _botLeftBacktFromPlayer.z);
                break;
            case 5:
                position.z = Random.Range(_topRightFrontFromPlayer.z, _topRightFrontAnchor.position.z - _padding);
                break;
        }

        return position;
    }

    ScalingData CreateRandomScalingData(float minScale, float maxScale)
    {
        var scale = Random.Range(minScale, maxScale);
        var endAt = Random.Range(1, _loadTime);
        return new ScalingData
        {
            StartAt = Random.Range(0, endAt),
            EndAt = endAt,
            FinalScale = scale,
        };
    }


    public Quaternion GetRandomRotation()
    {
        return Quaternion.AngleAxis(Random.Range(0, 361), Vector3.up);
    }
}
