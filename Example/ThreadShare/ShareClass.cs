using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Example.ThreadShare
{
    public class ShareClass
    {
        public static int shareCount = 0;
        public static ArrayList shareArryList = new ArrayList(new byte[]{0});
    }
}
