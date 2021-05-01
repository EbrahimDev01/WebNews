using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNews.Consts.Messages
{
    public static class ErrMsg
    {
        public const string MinLengthMsg = "{0}" + "باید بیشتر از " + "{1}" + "کارکتر باشد ";

        public const string MaxLengthMsg = "{0}" + "باید کمتر از " + "{1}" + "کارکتر باشد ";

        public const string RequiredMsg = "قالب " + "{0}" + "اشتباه است";

        public const string RegexMsg = "لطفا " + "{0}" + "را وارد کنید";
    }
}
