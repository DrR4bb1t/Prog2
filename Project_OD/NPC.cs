using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project_OD;
using System;


public class NPC
{
    private Vector2 npcPosition;
    private Texture2D npcTexture;
    private Rectangle npcRectangle;

    public Rectangle NPCRectangle { get => npcRectangle; }

    public NPC(Vector2 pos, string texture)
    {
        this.npcPosition = pos;
        this.npcTexture = OD.content.Load<Texture2D>(texture);
        this.npcRectangle = new Rectangle((int)this.npcPosition.X, (int)this.npcPosition.Y, this.npcTexture.Width, this.npcTexture.Height);
    }

    public bool NPCintersection(NPC npc, Player player)
    {
        return player.GetRectangle.Intersects(this.npcRectangle);

    }
    public void Draw(SpriteBatch spritebatch)
    {
        spritebatch.Draw(this.npcTexture, this.npcRectangle, Color.White);
    }
}
