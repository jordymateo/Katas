using _2019_06_15;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class ArgsSchemaTest
    {
        /*
            *-l -> bool
            *-p -> port (string)
            -d -> path (string)
            *-g -> string list 
            *-d -> int list

            If null -> throw ArgumentNullException
            -l -> 1. Exist, 2. No Exist
            -p -> PortFlag has value
            -g -> StringList has value
            -d -> IntList has value
        */

        [Fact]
        public void Text_IsNull_Throw_ArgumentNullException()
        {
            //arrage
            ArgsSchema argsSchema;

            //act
            Action actual = () => argsSchema = new ArgsSchema(null);

            //assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void L_Flag_NoExist_Loggin_IsFalse()
        {
            //arrage
            ArgsSchema argsSchema = new ArgsSchema("");

            //act
            bool actual = argsSchema.Loggin;

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void L_Flag_Exist_Loggin_IsTrue()
        {
            //arrage
            ArgsSchema argsSchema = new ArgsSchema("-l");

            //act
            bool actual = argsSchema.Loggin;

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void P_Flag_Exist_Port_HasValue()
        {
            //arrage
            ArgsSchema argsSchema = new ArgsSchema("-p 8080");

            //act
            string actual = argsSchema.Port;

            //assert
            Assert.Equal("8080", actual);
        }

        [Fact]
        public void G_Flag_Exist_StringList_HasValue()
        {
            //arrage
            ArgsSchema argsSchema = new ArgsSchema("-g this,is,a,list");

            //act
            List<string> actual = argsSchema.StringList;
            var result = new List<string> { "this", "is", "a", "list" };

            //assert
            Assert.Equal(result, actual);
        }

        [Fact]
        public void D_Flag_Exist_IntList_HasValue()
        {
            //arrage
            ArgsSchema argsSchema = new ArgsSchema("-d 1,2,-3,5");

            //act
            List<int> actual = argsSchema.IntList;
            var result = new List<int> { 1, 2, -3, 5 };

            //assert
            Assert.Equal(result, actual);
        }
    }
}
