﻿using System;

namespace Twitty.Entities
{
    [SerializableAttribute]
    class Size
    {
        public int Height { get; set; }
        public String Resize { get; set; }
        public int Width { get; set; }
    }
}
