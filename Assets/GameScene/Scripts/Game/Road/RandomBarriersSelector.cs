using UnityEngine;
using System.Collections.Generic;

public class RandomBarriersSelector : MonoBehaviour
{
    [SerializeField] private CharacterDetector _characterDetector;
    [SerializeField] private List<GameObject> _barriers;
    [SerializeField] private int _barriersToSpawnCount;

    private void Activate()
    {
        if (_barriers.Count < _barriersToSpawnCount)
            throw new System.IndexOutOfRangeException();

        for (int i = 0; i < _barriersToSpawnCount; i++)
            EnableRandomBarrier();
    }

    public void DiactivateAll()
    {
        DisableAllBarriers();
    }

    private void DisableAllBarriers()
    {
        foreach (GameObject barrier in _barriers)
            barrier.SetActive(false);
    }

    private void EnableRandomBarrier()
    {
        int randomIndex;

        do
        {
            randomIndex = Random.Range(0, _barriers.Count);
        }
        while (_barriers[randomIndex].activeSelf == true);

        _barriers[randomIndex].SetActive(true);
    }

    private void OnEnable()
    {
        _characterDetector.PlayerEnteredEvent += Activate;
    }

    private void OnDisable()
    {
        _characterDetector.PlayerEnteredEvent -= Activate;
    }
}
