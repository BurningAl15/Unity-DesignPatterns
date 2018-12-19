using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Responsible for performing actions (=Receiver)
/// </summary>
public class PlayerMotor : MonoBehaviour {

    #region Simple Example

    public void Jump()
    {
        m_anim.Play("Jump");
    }

    #endregion

    #region Advanced Example

    public void MoveUp()
    {
        transform.LookAt(Vector3.forward * 9999);
        Vector3 targetPos = transform.position + Vector3.forward;
        Tweener tweener = transform.DOMove(targetPos, m_moveDuration);
        tweener.onComplete = OnActionCompleted;
        m_anim.Play("Walk");
    }

    public void MoveDown()
    {
        transform.LookAt(Vector3.back * 9999);
        Vector3 targetPos = transform.position - Vector3.forward;
        Tweener tweener = transform.DOMove(targetPos, m_moveDuration);
        tweener.onComplete = OnActionCompleted;
        m_anim.Play("Walk");
    }

    public void MoveLeft()
    {
        transform.LookAt(Vector3.left * 9999);
        Vector3 targetPos = transform.position - Vector3.right;
        Tweener tweener = transform.DOMove(targetPos, m_moveDuration);
        tweener.onComplete = OnActionCompleted;
        m_anim.Play("Walk");
    }

    public void MoveRight()
    {
        transform.LookAt(Vector3.right * 9999);
        Vector3 targetPos = transform.position + Vector3.right;
        Tweener tweener = transform.DOMove(targetPos, m_moveDuration);
        tweener.OnComplete(OnActionCompleted);
        m_anim.Play("Walk");
    }

    public void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    public void UndoAttack()
    {
        OnActionCompleted();
    }

    #endregion

    #region not relevant
    public float m_moveDuration = 0.5f;
    public event System.Action actionCompleted;

    private Animation m_anim;

    private void Awake()
    {
        m_anim = GetComponent<Animation>();
    }
    public IEnumerator AttackCoroutine()
    {
        m_anim.Play("Attack");
        while (m_anim.IsPlaying("Attack"))
            yield return null;

        OnActionCompleted();
    }

    private void OnActionCompleted()
    {
        m_anim.CrossFade("idle",0.2f);
        if (actionCompleted != null)
            actionCompleted();
    }
    #endregion

}
