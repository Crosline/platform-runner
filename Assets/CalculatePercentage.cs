using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatePercentage : MonoBehaviour {

    [SerializeField]
    private Text _percentageText;

    [SerializeField]
    private GameObject win;

    [SerializeField]
    private Texture2D _drawing;

    private int total;
    private int percentage;

    private void Awake() {
        percentage = _drawing.width * _drawing.height;
    }

    private void OnEnable() {
        FreeDraw.Drawable.OnDrawEvent += CalculatePaint;
    }

    private void OnDisable() {
        FreeDraw.Drawable.OnDrawEvent -= CalculatePaint;
    }


    private void CalculatePaint(Color color) {
        if (color != Color.red)
            return;

        total++;

        var perc = Mathf.Clamp((int)(total / (float)percentage * 100), 0, 100);
        _percentageText.text = $"{perc}%";

        if (perc == 100) {
            win.SetActive(true);
        }

    }
}
