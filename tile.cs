using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class tile :MonoBehaviour {
    [SerializeField] defecalte defecalte;
    [SerializeField] Transform coin;
    [SerializeField] List<Transform> coinPlass;
    [SerializeField] Transform enemyPre;
    [SerializeField] List<Transform> enemyPos;

    private void Awake() {
        Instantiate(coin, coinPlass[Random.Range(0, coinPlass.Count-1)].position, Quaternion.identity, this.transform);
        Instantiate(enemyPre, enemyPos[Random.Range(0, enemyPos.Count-1)].position, Quaternion.identity, this.transform);
    }
}
enum defecalte {
    _base,
    easy,
    mid,
    hard,
}
