using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLight : MonoBehaviour
{
    private Vector2 mousePos;
    [SerializeField] private BoomerangThrowScript boomerangThrowScript;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float lineLength = 5f;
    private Vector2 throwDirection;
    [Header("LineParams")]
    [SerializeField] private int _segmentCount = 50;
    private Vector2[] _segments;
    private LineRenderer _lineRenderer;

    [SerializeField] private BoomerangLogicScript boomerangLogicScript;

    public void Start()
    {
        _segments = new Vector2[_segmentCount];
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _segmentCount;
        
    }
    public void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        throwDirection = (mousePos - (Vector2)BoomerangThrowScript.instance.transform.position).normalized;
        _segments[0] = spawnPoint.position;

        if (Input.GetMouseButton(0))
            DrawTrajectory(spawnPoint.position, throwDirection, boomerangLogicScript.throwForce, boomerangLogicScript.rb.gravityScale * Physics2D.gravity);
        if (Input.GetMouseButtonUp(0))
            DestroyTrajectory();
    }

    public void DrawTrajectory(Vector2 start, Vector2 dir, float force, Vector2 gravity)
    {
        _lineRenderer.positionCount = _segmentCount;
        _segments[0] = start;
        _lineRenderer.SetPosition(0, start);
        for (int i = 1; i < _segmentCount; i++)
        {
            _segments[i] = _segments[0] + dir * force * Time.fixedDeltaTime * lineLength;
            _lineRenderer.SetPosition(i, _segments[i]);

        }
    
    }
    private void DestroyTrajectory()
    {
        //destroy trajectory
        _lineRenderer.positionCount = 0;

    }
}
