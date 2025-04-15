using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skrypt : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftWall;

    [SerializeField]
    private GameObject _rightWall;

    [SerializeField]
    private GameObject _frontWall;

    [SerializeField]
    private GameObject _backWall;

    [SerializeField]
    private GameObject _unvisitedBlock;

    public bool IsVisited { get; private set; }

    private void Awake()
    {
        AddColliderIfMissing(_leftWall);
        AddColliderIfMissing(_rightWall);
        AddColliderIfMissing(_frontWall);
        AddColliderIfMissing(_backWall);
    }

    private void AddColliderIfMissing(GameObject wall)
    {
        if (wall != null && wall.GetComponent<Collider>() == null)
        {
            wall.AddComponent<BoxCollider>();
        }
    }

    public void Visit()
    {
        IsVisited = true;
        _unvisitedBlock.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightWall.SetActive(false);
    }

    public void ClearFrontWall()
    {
        _frontWall.SetActive(false);
    }

    public void ClearBackWall()
    {
        _backWall.SetActive(false);
    }
}
