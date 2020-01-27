using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zeds.Graphics
{
    public static class RenderTargetHandler
    {
        public static void DrawSceneToTexture(RenderTarget2D renderTarget)
        {
            // Set the render target
            Engine.Engine.Device.SetRenderTarget(renderTarget);

            Engine.Engine.Device.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            // Draw the scene
            Engine.Engine.Device.Clear(Color.CornflowerBlue);
            //DrawModel(model, world, view, projection);

            // Drop the render target
            Engine.Engine.Device.SetRenderTarget(null);
        }
    }
}