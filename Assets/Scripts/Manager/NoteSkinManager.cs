using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteStyleManager : Singleton<NoteStyleManager>
{
    private readonly Dictionary<NoteColor, Sprite> _tapSprite = new Dictionary<NoteColor, Sprite>();
    private readonly Dictionary<NoteColor, Sprite> _holdSprite = new Dictionary<NoteColor, Sprite>();
    private readonly Dictionary<NoteColor, Sprite> _touchSprite = new Dictionary<NoteColor, Sprite>();

    // readonly
    public Dictionary<NoteColor, Sprite> TapSprite => _tapSprite;
    public Dictionary<NoteColor, Sprite> HoldSprite => _holdSprite;
    public Dictionary<NoteColor, Sprite> TouchSprite => _touchSprite;

    public NoteStyleManager()
    {
        LoadSprites();
    }

    private void LoadSprites()
    {
        _tapSprite.Add(NoteColor.Red, Resources.Load<Sprite>("tap-red"));
        _tapSprite.Add(NoteColor.Yellow, Resources.Load<Sprite>("tap-yellow"));
        _tapSprite.Add(NoteColor.Green, Resources.Load<Sprite>("tap-green"));
        _tapSprite.Add(NoteColor.Blue, Resources.Load<Sprite>("tap-blue"));

        _holdSprite.Add(NoteColor.Red, Resources.Load<Sprite>("hold-red"));
        _holdSprite.Add(NoteColor.Yellow, Resources.Load<Sprite>("hold-yellow"));
        _holdSprite.Add(NoteColor.Green, Resources.Load<Sprite>("hold-green"));
        _holdSprite.Add(NoteColor.Blue, Resources.Load<Sprite>("hold-blue"));

        _touchSprite.Add(NoteColor.Red, Resources.Load<Sprite>("touch-red"));
        _touchSprite.Add(NoteColor.Yellow, Resources.Load<Sprite>("touch-yellow"));
        _touchSprite.Add(NoteColor.Green, Resources.Load<Sprite>("touch-green"));
        _touchSprite.Add(NoteColor.Blue, Resources.Load<Sprite>("touch-blue"));
    }
}
