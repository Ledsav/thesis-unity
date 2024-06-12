using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class KoachLine : KoachGenerator
{
    LineRenderer _lineRenderer;
    [Range(0,1)]
    public float _lerpAmount;
    Vector3[] _lerpPosition;
    public float _generateMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = true;
        _lineRenderer.useWorldSpace = false;
        _lineRenderer.loop = true;
        _lineRenderer.positionCount = _position.Length;
        _lineRenderer.SetPositions(_position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_generationCounts != 0) 
        {
            for (int i = 0; i< _position.Length; i++) 
            {
                _lerpPosition[i] = Vector3.Lerp(_position[i], _targetposition[i], _lerpAmount);
            }

            _lineRenderer.SetPositions(_lerpPosition);
        }


        //using keys to control outword or inwords
        if (Keyboard.current[Key.O].wasPressedThisFrame)
       {
            Debug.Log('y');
        KoachGenerate(_targetposition, true, _generateMultiplier);
            _lerpPosition = new Vector3[_position.Length];
            _lineRenderer.positionCount = _position.Length;
            _lineRenderer.SetPositions(_position);
            _lerpAmount = 0;
        }
        if (Keyboard.current[Key.I].wasPressedThisFrame)
        {
            KoachGenerate(_targetposition, false, _generateMultiplier);
            _lerpPosition = new Vector3[_position.Length];
            _lineRenderer.positionCount = _position.Length;
            _lineRenderer.SetPositions(_position);
            _lerpAmount = 0;
        }
    }
}
