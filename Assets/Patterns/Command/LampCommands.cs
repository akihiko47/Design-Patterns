using UnityEngine;

public class PowerCommand : ICommand {

    Lamp _lamp;

    public PowerCommand(Lamp lamp) {
        _lamp = lamp;
    }

    public void execute() {
        _lamp.SetPower();
    }

}


public class ChangeColorCommand : ICommand {

    Lamp _lamp;

    public ChangeColorCommand(Lamp lamp) {
        _lamp = lamp;
    }

    public void execute() {
        _lamp.SetRandomColor();
    }

}