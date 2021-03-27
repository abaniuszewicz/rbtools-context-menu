﻿namespace RBToolsContextMenu.Domain.Options.Post.Posting
{
    public class Update : RbtOption, IHasLongForm, IHasShortForm
    {
        public string LongForm { get; } = "-update";
        public string ShortForm { get; } = "u";
    }
}