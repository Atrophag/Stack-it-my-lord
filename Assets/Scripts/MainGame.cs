using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public uint roundCount = 3;
    // duration du round
    public uint roundTimer = 10;
    // duration du calcul en fin de round
    public uint endRoundTimer = 2;

    private TimeSpan _timeSpan;
    private TextCountdown _textCountdown;
    private Spawner _spawner;

    private uint _round = 1;
    private uint _step = 0;

    void Start()
    {
        _spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        _textCountdown = GameObject.Find("Alert Text").GetComponent<TextCountdown>();

        // start
        NextStep();
    }

    void Update()
    {
        if (_round <= roundCount && _textCountdown.IsFinished())
        {
            NextStep();
        }
    }

    private void NextStep()
    {
        switch (_step % 3)
        {
            case 0:
                PrepareRound();
                break;
            case 1:
                StartRound();
                break;
            case 2:
                EndRound();
                break;
        }
    }

    private void PrepareRound()
    {
        // TODO: add validation zone
        _textCountdown.Set("Début du round " + _round.ToString() + "\n", 3);
        _step += 1;
    }

    private void StartRound()
    {
        _spawner.Activate();
        _textCountdown.Set("", roundTimer);
        _step += 1;
    }

    private void EndRound()
    {
        _spawner.Deactivate();
        _textCountdown.Set("Envoi vers l'armoire magique de la mort qui tue", endRoundTimer, false);
        RemoveBoxes();
        _round += 1;
        _step += 1;
    }

    private void RemoveBoxes()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Draggable"))
        {
            DraggableItem box = Utils.CastDraggableItem(item);
            box.Deactivate();
        }
    }
}
