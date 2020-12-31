using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileMaker :MonoBehaviour {
    #region var
    [SerializeField] tile baseTile;
    [SerializeField] tile[] easyTile;
    [SerializeField] tile[] midTile;
    [SerializeField] tile[] hardTile;
    [SerializeField] Transform player;
    [SerializeField] int maxActiveTiles;
    [SerializeField] int tileScore;

    List<tile> activeTiles = new List<tile>();
    float lastPlass;
    gameManager gm;

    #endregion
    private void Awake() {
        gm=FindObjectOfType<gameManager>();
    }
    void Start() {
        spownTile(defecalte._base, 0);
        for(int i = 0; i<maxActiveTiles; i++) 
            spownTile(defecalte.easy, Random.Range(0, easyTile.Length));
    }
    void Update() {
        if(player.position.z>lastPlass-(maxActiveTiles*50)) {
            spownTile(defecalte.easy, Random.Range(0, easyTile.Length-1));
            removeTile();
        }
    }
    void spownTile(defecalte level, int TileIndex) {
        tile go = Instantiate(setDefecalty(level, TileIndex), transform.forward*lastPlass, transform.rotation);
        lastPlass+=50;
        activeTiles.Add(go);
    }
    void removeTile() {
        tile temp = activeTiles[0];
        activeTiles.RemoveAt(0);
        Destroy(temp.gameObject);
        gm.addScore(tileScore);
    }
    tile setDefecalty(defecalte level, int tileIndex) {
        switch(level) {
            case defecalte.easy:
            return easyTile[tileIndex];
            case defecalte.hard:
            return hardTile[tileIndex];
            case defecalte.mid:
            return hardTile[tileIndex];
            case defecalte._base:
            return baseTile;
        }
        Debug.Log("no tile");
        return null;
    }

}
