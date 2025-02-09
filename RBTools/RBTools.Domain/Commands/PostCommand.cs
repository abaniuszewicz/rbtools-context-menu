﻿using System.Collections.Generic;
using RBTools.Domain.Options;

namespace RBTools.Domain.Commands
{
    public class PostCommand : RbtCommand
    {
        public override string Command { get; } = "post";
        public override IEnumerable<IRbtOption> Options { get; }

        public PostCommand(IEnumerable<IRbtOption> options)
        {
            Options = options;
        }
    }
}