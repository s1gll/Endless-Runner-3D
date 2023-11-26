using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private  GameObject[] _sectors; 
    [SerializeField] private  Transform _player;
    [SerializeField] private  int _sectorsToKeep = 5; 
    [SerializeField] private  float _sectorLength = 61f; 
    private  List<GameObject> _activeSectors = new List<GameObject>();
    private float nextSectorZ;

    private void Start()
    {
       
        for (int i = 0; i < _sectorsToKeep; i++)
        {
            GenerateSector();
        }
    }

    private void Update()
    {
        
        transform.position = new Vector3(0f, 0f, _player.position.z);

        
        float playerZ = _player.position.z;
        float lastSectorZ = _activeSectors[_activeSectors.Count - 1].transform.position.z;

        if (playerZ > lastSectorZ - _sectorLength)
        {
            GenerateSector();
        }

       
        for (int i = 0; i < _activeSectors.Count; i++)
        {
            float sectorZ = _activeSectors[i].transform.position.z;
            if (playerZ > sectorZ + _sectorsToKeep * _sectorLength)
            {
                Destroy(_activeSectors[i]);
                _activeSectors.RemoveAt(i);
                i--;
            }
        }
    }

    private void GenerateSector()
    {
        int randomSectorIndex = Random.Range(0, _sectors.Length);
        GameObject newSector = Instantiate(_sectors[randomSectorIndex], new Vector3(0f, 0f, nextSectorZ), Quaternion.identity);
        _activeSectors.Add(newSector);
        nextSectorZ += _sectorLength;
    }
}

