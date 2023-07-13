using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
  public Collider bola;
  public float multiplier;
  public Color color1;
  public Color color2;
  public Color color3;

  private MeshRenderer meshRenderer;
  //private Renderer renderer;
  private Animator animator;
  
  
  private enum objectColor {Color1, Color2, Color3};
  private objectColor currentColor;

  private void Start()
  {
    meshRenderer = GetComponent<MeshRenderer>();
    animator = GetComponent<Animator>();
    
    currentColor = objectColor.Color1;
    MaterialSwitch();
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider == bola)
    {
      MaterialSwitch();

      Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
      bolaRig.velocity *= multiplier;

      animator.SetTrigger("hit");
    }
  }

  private void MaterialSwitch()
  {
    switch(currentColor)
    {
      case objectColor.Color1:
      currentColor = objectColor.Color2;
      meshRenderer.GetComponent<Renderer>().material.color = color1;
      break;
      case objectColor.Color2:
      currentColor = objectColor.Color3;
      meshRenderer.GetComponent<Renderer>().material.color = color2;
      break;
      case objectColor.Color3:
      currentColor = objectColor.Color1;
      meshRenderer.GetComponent<Renderer>().material.color = color3;
      break;
      default:
      Debug.Log("Warna Tidak Diketahui");
      break;
    }
  }

}