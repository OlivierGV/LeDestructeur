using UnityEngine;
using UnityEngine.InputSystem;

public class ControleurTRex : MonoBehaviour
{
    [SerializeField] //permet d'afficher dans l'inspecteur, les autres classes pourront pas la modifier.
    private float vitesse;
    private Vector2 deplacement;
    [SerializeField]
    private float vitesseRotation;
    private float rotation;

    public void OnDeplacement(InputValue valeur)
    {
        deplacement = valeur.Get<Vector2>();
    }

    public void OnRotation(InputValue valeur)
    {
        rotation = valeur.Get<float>();
    }

    private void FixedUpdate()
    {
        if (deplacement.sqrMagnitude > 0)
        {
            Vector3 deplacementEffectif = (deplacement.y * transform.forward + deplacement.x * transform.right).normalized;
            transform.position += deplacementEffectif * vitesse * Time.deltaTime;

            transform.Rotate(Vector3.up, rotation * vitesseRotation * Time.deltaTime);
        }
    }
}
