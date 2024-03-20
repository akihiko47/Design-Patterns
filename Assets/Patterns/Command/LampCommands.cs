using UnityEngine;

public class PowerCommand : ICommand {

    Lamp _lamp;

    public PowerCommand(Lamp lamp) {
        _lamp = lamp;
    }

    public void Execute() {
        _lamp.SetPower();
    }

    public void Redo() {
        _lamp.SetPower();
    }

}


public class ChangeColorCommand : ICommand {

    Lamp _lamp;
    Color prevColor;

    public ChangeColorCommand(Lamp lamp) {
        _lamp = lamp;
    }

    public void Execute() {
        prevColor = _lamp.GetColor();

        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        _lamp.SetColor(randomColor);
    }

    public void Redo() {
        _lamp.SetColor(prevColor);
    }

}