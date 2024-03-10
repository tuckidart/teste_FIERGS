using UnityEngine;

public class TurnInfoEvents : MonoBehaviour
{
    public void ChangeTurnOwner() => BattleMaestro.Instance.ChangeTurnOwner();
}
