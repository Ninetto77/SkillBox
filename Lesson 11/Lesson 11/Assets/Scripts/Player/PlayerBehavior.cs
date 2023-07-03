using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using WildBall.Inputs;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private ParticleSystem bloodParticlesPrefab;
    private PlayerMovement player;
    private ParticleSystem bloodParticles;
    private bool canBeDead = false;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (canBeDead)
        {
            canBeDead = false;
            StartCoroutine(WaitSomeTime());
        }
    }
    public void DeadPlayer()
    {
        canBeDead = true;
        PlayerBlood();
    }

    private void PlayerBlood()
    {
        bloodParticles = Instantiate(bloodParticlesPrefab);
        bloodParticles.transform.SetParent(transform);
        bloodParticles.transform.localPosition  = new Vector3(0, 0.3f, 0);
        bloodParticles.Play();

        Destroy(bloodParticles.gameObject, 0.5f);
    }

    private IEnumerator WaitSomeTime()
    {
        player.StopMovePlayer();
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        UIManager.instance.LooseGameMenu();
    }

}

