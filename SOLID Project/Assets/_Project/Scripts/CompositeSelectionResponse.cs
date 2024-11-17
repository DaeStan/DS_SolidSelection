using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable
{
    [SerializeField] private GameObject selectionResponseHolder;

    private List<ISelectionResponse> _selectionResponses;
    private int _currentIndex;

    private void Start()
    {
        _selectionResponses = selectionResponseHolder.GetComponents<ISelectionResponse>().ToList();
    }

    [ContextMenu(itemName: "Next")]
    public void Next()
    {
        _currentIndex = (_currentIndex + 1) % _selectionResponses.Count;
    }
    public void OnDeselect(Transform selection)
    {
        if (HasSelection())
        {
            _selectionResponses[_currentIndex].OnDeselect(selection);
        }
    }

    public void OnSelect(Transform selection)
    {
        if (HasSelection())
        {
            _selectionResponses[_currentIndex].OnSelect(selection);
        }
    }

    private bool HasSelection()
    {
        return _currentIndex > -1 && _currentIndex < _selectionResponses.Count;
    }
}
