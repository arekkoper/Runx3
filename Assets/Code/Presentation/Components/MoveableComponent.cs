using System.Collections;
using UnityEngine;

namespace Code.Presentation.Components
{
    public class MoveableComponent : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private Transform model;

        [Header("Parameters")] 
        [SerializeField] private Vector3 moveOffset;
        [SerializeField] private float speed;
        [SerializeField] private float interval;
        
        private Vector3 openPosition;
        private Vector3 closePosition;

        private void Start()
        {
            openPosition = model.position + moveOffset;
            closePosition = model.position;
            
            StartCoroutine(Open());
        }

        private IEnumerator Open()
        {
            while (Vector3.Distance(model.position, openPosition) >= 0.1f)
            {
                model.position = Vector3.MoveTowards(model.position, openPosition, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(interval);

            StartCoroutine(Close());
        }

        private IEnumerator Close()
        {
            while (Vector3.Distance(model.position, closePosition) >= 0.1f)
            {
                model.position = Vector3.MoveTowards(model.position, closePosition, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(interval);

            StartCoroutine(Open());
        }
    }
}