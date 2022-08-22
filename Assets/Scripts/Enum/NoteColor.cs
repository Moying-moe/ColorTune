/*
  Copyright (c) Moying-moe All rights reserved. Licensed under the MIT license.
  See LICENSE in the project root for license information.
*/

public enum NoteColor
{
    Red = 1,
    Yellow = 2,
    Green = 3,
    Blue = 4,
    Invalid = -1
}

public static class NoteColorEnum
{
    public static bool IsValid(this NoteColor self)
    {
        return self != NoteColor.Invalid;
    }

    public static int ToTrackId(this NoteColor self)
    {
        return (int)self;
    }

    public static NoteColor FromTrackId(int trackId)
    {
        return (NoteColor)trackId;
    }
}