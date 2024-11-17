using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SwapSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] private List<Selectable> selectables;

    public float delay = 2.0f;
    public Light _light;
    public float dimLight = 0.5f;

    public void OnDeselect(Transform selection)
    {
        StartCoroutine(SwapWithDelay(selection, false));
    }

    public void OnSelect(Transform selection)
    {
        StartCoroutine(SwapWithDelay(selection, true));
    }

    private IEnumerator SwapWithDelay(Transform selection, bool isSelect)
    {
        var _selectionPosition = selection.position;

        for (int i = 0; i < selectables.Count; i++)
        {
            var _nextPosition = selectables[i].transform.position;

            yield return new WaitForSeconds(delay);

            selection.position = _nextPosition;
            selectables[i].transform.position = _selectionPosition;
        }
    }
}
