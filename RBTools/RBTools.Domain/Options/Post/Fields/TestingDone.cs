﻿using System;

namespace RBTools.Domain.Options.Post.Fields
{
    public class TestingDone : RbtOption, IHasLongForm, IHasValue
    {
        public string LongForm { get; } = "testing-done";
        public string Value { get; }

        public TestingDone(string testingDone)
        {
            Value = testingDone ?? throw new ArgumentNullException(nameof(testingDone));
        }
    }
}