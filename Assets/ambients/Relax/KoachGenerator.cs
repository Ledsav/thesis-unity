using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoachGenerator : MonoBehaviour
{
    protected enum _axis
    { 
        XAxis,
        YAxis,
        ZAxis
    };

    [SerializeField]
    protected _axis axis = new _axis();

    protected enum _initiator {
    
        Triangle,
        Square,
        Pentagone,
        Hexagon,
        Heptagon,
        Octagon
    
    };

    public struct LineSegment
    {
        public Vector3 StartPosition { get; set; }
        public Vector3 EndPosition { get; set; }
        public Vector3 Direction { get; set; }
        public float Length { get; set; }
    }


    [SerializeField]
    protected _initiator initiator = new _initiator();
    [SerializeField]
    protected float _initiatorsize;
    [SerializeField]
    protected AnimationCurve _generator;

    protected Keyframe[] _keys;

    protected int _generationCounts;

    protected int _initiatorPointAmount;
    private Vector3[] _initiatorPoint;
    private Vector3 _rotVector;
    private Vector3 _rotAxis;
    private float _initialRotation;

    protected Vector3[] _position;
    protected Vector3[] _targetposition;
    private List<LineSegment> _lineSegment;



    private void Awake()
    {
        GetInPoint();
        //assign list & arrays
        _position = new Vector3[_initiatorPointAmount+1];
        _targetposition = new Vector3[_initiatorPointAmount + 1];
        _lineSegment = new List<LineSegment>();
        _keys = _generator.keys;

        _rotVector = Quaternion.AngleAxis(_initialRotation, _rotAxis) * _rotVector;

        for (int i = 0; i < _initiatorPointAmount; i++)
        {
            _position[i] = _rotVector * _initiatorsize;
            _rotVector = Quaternion.AngleAxis(360 / _initiatorPointAmount, _rotAxis) * _rotVector;
        }

        _position[_initiatorPointAmount] = _position[0];
        _targetposition = _position;
        
    }

    protected void KoachGenerate(Vector3[] positions, bool outwards, float generatorMultiplier) 
    {
        //creating line segments
        _lineSegment.Clear();
        for (int i = 0; i < positions.Length - 1; i++) 
        {
            LineSegment line = new LineSegment();
            line.StartPosition = positions[i];
            if (i == positions.Length -1)
            {
                line.EndPosition = positions[0];
            }
            else
            {
                line.EndPosition = positions[i + 1];
            }
            line.Direction = (line.EndPosition - line.StartPosition.normalized);
            line.Length = Vector3.Distance(line.EndPosition, line.StartPosition);
            _lineSegment.Add(line);
        }
        //add the line degments to point array
        List<Vector3> newPos = new List<Vector3>();
        List<Vector3> targetPos = new List<Vector3>();

        for (int i = 0; i < _lineSegment.Count; i++) 
        {
            newPos.Add(_lineSegment[i].StartPosition);
            targetPos.Add(_lineSegment[i].StartPosition);

            for (int j = 1; j< _keys.Length-1; j++)
            {
                float moveAmount = _lineSegment[i].Length * _keys[j].time;
                float heigthAmount = (_lineSegment[i].Length * _keys[j].value) * generatorMultiplier;
                Vector3 movePos = _lineSegment[i].StartPosition + (_lineSegment[i].Direction * moveAmount);
                Vector3 Dir;
                if (outwards)
                {
                    Dir = Quaternion.AngleAxis(-90, _rotAxis) * _lineSegment[i].Direction;
                }
                else
                {
                    Dir = Quaternion.AngleAxis(90, _rotAxis) * _lineSegment[i].Direction;
                }
                newPos.Add(movePos);
                targetPos.Add(movePos + (Dir * heigthAmount));
            }

        }
        newPos.Add(_lineSegment[0].StartPosition);
        targetPos.Add(_lineSegment[0].StartPosition);
        _position = new Vector3[newPos.Count];
        _targetposition = new Vector3[targetPos.Count];
        _position = newPos.ToArray();
        _targetposition = targetPos.ToArray();

        _generationCounts++;

    }
    private void OnDrawGizmos()
    {
        GetInPoint();
        _initiatorPoint = new Vector3[_initiatorPointAmount];

        _rotVector = Quaternion.AngleAxis(_initialRotation, _rotAxis) * _rotVector;

        for (int i =0; i<_initiatorPointAmount; i++)
        {
            _initiatorPoint[i] = _rotVector * _initiatorsize;
            _rotVector = Quaternion.AngleAxis(360 / _initiatorPointAmount, _rotAxis) * _rotVector;
        }

        for (int i = 0; i < _initiatorPointAmount; i++)
        {
            Gizmos.color = Color.white;
            Matrix4x4 rotationMtrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            Gizmos.matrix = rotationMtrix;
            if(i<_initiatorPointAmount-1)
            {
                Gizmos.DrawLine(_initiatorPoint[i], _initiatorPoint[i + 1]);
            }
            else
            {
                Gizmos.DrawLine(_initiatorPoint[i], _initiatorPoint[0]);
            }
        }
    }

    private void GetInPoint() 
    {
        switch (initiator)
        {
            case _initiator.Triangle:
                _initiatorPointAmount = 3;
                _initialRotation = 0;
              break;

            case _initiator.Square:
                _initiatorPointAmount = 4;
                _initialRotation = 45;
                break;

            case _initiator.Pentagone:
                _initiatorPointAmount = 5;
                _initialRotation = 36;
                break;

            case _initiator.Hexagon:
                _initiatorPointAmount = 6;
                _initialRotation = 30;
                break;

            case _initiator.Heptagon:
                _initiatorPointAmount = 7;
                _initialRotation = 25.71428f;
                break;

            case _initiator.Octagon:
                _initiatorPointAmount = 8;
                _initialRotation = 22.5f;
                break;
            default:
                _initiatorPointAmount = 3;
                _initialRotation = 0;
                break;
        };

        switch (axis)
        {
            case _axis.XAxis:
                _rotVector = new Vector3(1, 0, 1);
                _rotAxis = new Vector3(0, 0, 1);
                break;

            case _axis.YAxis:
                _rotVector = new Vector3(0, 1, 0);
                _rotAxis = new Vector3(1, 0, 0);
                break;

            case _axis.ZAxis:
                _rotVector = new Vector3(0, 0, 1);
                _rotAxis = new Vector3(0, 1, 0);
                break;

            default:
                _rotVector = new Vector3(0, 1, 0);
                _rotAxis = new Vector3(1, 0, 0);
                break;
        };

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
