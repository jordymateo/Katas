using _2019_06_16;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class ArgsSchemaTest
    {
        /*
         Interfaz IFlags
            -> GetFlags(string)
        Class argschema
            -> Properties

        -l bool 
        -p string
        -g string list
        -d int list

            Iflags pass null throw exception
            iflags return dictionary flags in string
        */
        [Fact]
        public void Text_IsNull_IFlags_Throw_ArgumentNullException()
        {
            //arrage
            var flags = new Mock<IFlags>();
            flags.Setup(x => x.GetFlags(null)).Throws<ArgumentNullException>();

            ArgsSchema argsSchema = new ArgsSchema(flags.Object);

            //act
            Action actual = () => argsSchema.GetArgs(null);

            //assert 
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void IFlags_Has_Loggin_Property_IsTrue()
        {
            //arrage
            var values = new Dictionary<string, string>
            {
                { "l", "" }
            };
            var flags = new Mock<IFlags>();
            flags.Setup(x => x.GetFlags(It.IsAny<string>())).Returns(values);

            ArgsSchema argsSchema = new ArgsSchema(flags.Object);
            argsSchema.GetArgs("-l");

            //act
            bool actual = argsSchema.Loggin;

            //assert 
            Assert.True(actual);
        }

        [Fact]
        public void IFlags_Has_IntList_Property_HasValue()
        {
            //arrage
            var values = new Dictionary<string, string>
            {
                { "d", "1, 2, -3, 9" }
            };
            var flags = new Mock<IFlags>();
            flags.Setup(x => x.GetFlags(It.IsAny<string>())).Returns(values);

            ArgsSchema argsSchema = new ArgsSchema(flags.Object);
            argsSchema.GetArgs("-d");

            //act
            List<int> actual = argsSchema.IntList;

            //assert 
            Assert.Equal(new[] { 1, 2, -3, 9 }, actual);
        }
    }
}
