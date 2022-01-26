using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager> {
    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();

    public void Init() {
        if (enemies.Count == 0) {
            var temp = FindObjectsOfType<Enemy>();

            foreach (Enemy enemy in temp) {
                enemies.Add(enemy);
            }
        }

        for (int i = 0; i < enemies.Count; i++) {
            enemies[i].Init();
        }
    }

}
