﻿using System;

namespace RBToolsContextMenu.Domain.Options
{
    public abstract class RbtOption : IRbtOption
    {
        public string Print()
        {
            return this switch
            {
                IHasShortForm form and IHasValue value => $"-{form.ShortForm} {value.Value}",
                IHasShortForm form => $"-{form.ShortForm}",
                IHasLongForm form and IHasValue value => $"--{form.LongForm} {value.Value}",
                IHasLongForm form => $"--{form.LongForm}",
                _ => throw new NotImplementedException("This option does not implement any members that could be used for printing."), // HACK: not really proud of this
            };
        }
    }
}