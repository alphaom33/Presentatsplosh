using Seb.Fluid2D.Rendering;
using Seb.Fluid2D.Simulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationClicker : MonoBehaviour
{
    public Texture2D[] textures;
    int textureIndex;
    ParticleDisplay2D particleDisplay2D;
    FluidSim2D fluidSim2D;
    Spawner2D spawner2D;
    public float randomVel;

    // Start is called before the first frame update
    void Start()
    {
        particleDisplay2D = GetComponent<ParticleDisplay2D>();    
        fluidSim2D = GetComponent<FluidSim2D>();
        spawner2D = GetComponent<Spawner2D>();
        spawner2D.initialVelocity = new Vector2(Random.Range(-randomVel, randomVel), Random.Range(-randomVel, randomVel));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && textureIndex < textures.Length - 1)
        {
            particleDisplay2D.gradientTexture = textures[++textureIndex];
            particleDisplay2D.needsUpdate = true;

            spawner2D.initialVelocity = new Vector2(Random.Range(-randomVel, randomVel), Random.Range(-randomVel, randomVel));

            fluidSim2D.OnDestroy();
            fluidSim2D.Init();
        }
    }
}
