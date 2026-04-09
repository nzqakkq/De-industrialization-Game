using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace WaterSystem.Rendering
{
    public class WaterSystemFeature : ScriptableRendererFeature
    {
        private WaterBuffers _waterBuffers;
        private WaterCaustics _waterCaustics;

        public override void Create()
        {
            _waterBuffers = new WaterBuffers();
            _waterCaustics = new WaterCaustics();
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(_waterBuffers);
            renderer.EnqueuePass(_waterCaustics);
        }

        protected override void Dispose(bool disposing)
        {
            _waterCaustics.Cleanup();
        }
    }
}