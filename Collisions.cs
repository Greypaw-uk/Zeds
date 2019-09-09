using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zeds
{
    public class GameObject
    {
        private Texture2D texture;
        public Vector2 Position;
        public Vector2 Velocity;

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    texture.Width,
                    texture.Height);
            }
        }

        /*public GameObject(Texture2D texture, Vector2 Position)
        {
            this.texture = texture;
            this.Position = Position;
        }

        public GameObject(Texture2D texture, Vector2 Position, Vector2 velocity)
        {
            this.texture = texture;
            this.Position = Position;
            this.Velocity = velocity;
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            SpriteBatch.Draw(texture, Position, Color.White);
        }
        */
    }

    class Collisions
    {
    }
}
