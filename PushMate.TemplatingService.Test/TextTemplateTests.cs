using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PushMate.TemplatingService.Test
{
    public class TextTemplateTest
    {
        [Fact]
        public void ReplaceText_OneVariable()
        {
            string baseTemplate = "Hello $name$";
            var dictVariables = new Dictionary<string, string>
            {
                { "name", "Denis"}
            };
            string expected = "Hello Denis";

            string result = TemplateService.ApplyTextTemplateAsync(baseTemplate, dictVariables).Result;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceText_TwoVariables()
        {
            string baseTemplate = "Hello $name$. Your account balance is $$balance$. Thanks $name$!";
            var dictVariables = new Dictionary<string, string>
            {
                { "name", "Denis"},
                { "balance", "1000.00"}
            };
            string expected = "Hello Denis. Your account balance is $1000.00. Thanks Denis!";

            string result = TemplateService.ApplyTextTemplateAsync(baseTemplate, dictVariables).Result;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceText_NoVariables()
        {
            string baseTemplate = "Hello!";
            var dictVariables = new Dictionary<string, string>
            {
            };

            string expected = "Hello!";

            string result = TemplateService.ApplyTextTemplateAsync(baseTemplate, dictVariables).Result;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceText_InputNull()
        {
            string baseTemplate = "Hello!";
            
            Assert.ThrowsAsync<ArgumentException>(() =>
                TemplateService.ApplyTextTemplateAsync(baseTemplate, null)
            );
        }

        [Fact]
        public void ReplaceText_NumberOfVariablesDoesNotMatch_MoreVariables ()
        {
            string baseTemplate = "Hello $name$. Your account balance is $$balance$. Thanks $name$!";

            var dictVariables = new Dictionary<string, string>
            {
                { "name", "Denis"}
            };
            
            Assert.ThrowsAsync<ArgumentException>(() =>
                TemplateService.ApplyTextTemplateAsync(baseTemplate, dictVariables)
            );
        }

        [Fact]
        public void ReplaceText_NumberOfVariablesDoesNotMatch_MoreParameters()
        {
            string baseTemplate = "Hello $name$";

            var dictVariables = new Dictionary<string, string>
            {
                { "name", "Denis"},
                { "balance", "1000.00"}
            };

            Assert.ThrowsAsync<ArgumentException>(() =>
                TemplateService.ApplyTextTemplateAsync(baseTemplate, dictVariables)
            );
        }


    }

  
}
