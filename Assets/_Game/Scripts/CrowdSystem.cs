using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform runnersParent;
    [SerializeField] private GameObject runnerPrefab;

    [Header(" Setting ")]
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceRunners();
    }

    private void PlaceRunners()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPosition = GetRunnerLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;
        }
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        //Doc them ve Fermat's spiral de hieu ro hon (TOAN)
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }

    public float GetCrowdRadius()
    {
        return radius * Mathf.Sqrt(runnersParent.childCount);
    }

    public void ApplyBonus(BonusType bounsType, int bounsAmount)
    {
        switch (bounsType)
        {
            case BonusType.Addition:
                AddRunners(bounsAmount);
                break;
            case BonusType.Product:
                int runnerToAdd = (runnersParent.childCount * bounsAmount) - runnersParent.childCount;
                AddRunners(runnerToAdd);
                break;
            case BonusType.Difference:
                RemoveRunner(bounsAmount);
                break;
            case BonusType.Division:
                int runnerToRemove = runnersParent.childCount - (runnersParent.childCount / bounsAmount);
                RemoveRunner(runnerToRemove);
                break;
        }
    }

    private void AddRunners(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(runnerPrefab, runnersParent);
        }
    }

    private void RemoveRunner(int amount)
    {
        if (amount > runnersParent.childCount)
        {
            amount = runnersParent.childCount;
        }

        int runnersAmount = runnersParent.childCount;

        for (int i = runnersAmount - 1; i >= runnersAmount - amount; i--)
        {
            Transform runnerToDestroy = runnersParent.GetChild(i);
            runnerToDestroy.SetParent(null);
            Destroy(runnerToDestroy.gameObject);
        }
    }
}
