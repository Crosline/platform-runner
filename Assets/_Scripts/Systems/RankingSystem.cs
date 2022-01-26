using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingSystem : MonoBehaviour {
    [SerializeField]
    private List<Transform> _transforms;

    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Transform _finish;

    [SerializeField]
    private Text _rankText;

    private int _total;
    private int index = 0;
    private int offset = 0;

    private bool isFinished = false;

    void OnEnable() {
        Finish.OnFinishedEvent += FinishLine;
    }
    void OnDisable() {
        Finish.OnFinishedEvent -= FinishLine;
    }

    // Start is called before the first frame update
    void Awake() {
        _total = _transforms.Count;
    }

    // Update is called once per frame
    void Update() {
        if (isFinished)
            return;


        _transforms.Sort(delegate (Transform a, Transform b) {
            return (Vector3.Distance(a.position, _finish.position)).CompareTo(Vector3.Distance(b.position, _finish.position));
        });

        for (int i = 0; i < _transforms.Count; i++) {
            if (_transforms[i] == _player) {
                index = i;
                break;
            }
        }

        _rankText.text = $"{index + 1 + offset}/{_total}";
    }

    private void FinishLine(Transform t) {
        if (t == _player)
            isFinished = true;

        _transforms.Remove(t);
        offset++;

        if (_transforms.Count == 0)
            isFinished = true;

    }
}
