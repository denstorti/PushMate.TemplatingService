using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PushMate.TemplatingService
{
    public static class TemplateService
    {
        /// <summary>
        /// Replate fillings in the <paramref name="templateText"/> with parameters of <paramref name="parameters"/>
        /// </summary>
        /// <param name="templateText">String which may contain variables enclosed in dollar signs. Examples: Hello $name$. </param>
        /// <param name="parameters">Set of variable names and values. Example: "name, Denis", "balance, 1000" </name></param>
        /// <returns></returns>
        public static async Task<string> ApplyTextTemplateAsync(string templateText, Dictionary<string, string> parameters)
        {
            return await Task.Factory.StartNew(() =>
            {
                string result = templateText;
                var matches = new Regex(@"\$.+?\$").Matches(templateText);
                var uniqueMatches = matches
                    .OfType<Match>()
                    .Select(m => m.Value)
                    .Distinct().Count();

                if (parameters == null)
                {
                    throw new ArgumentException($"Variables cannot be null.");
                }

                if (uniqueMatches != parameters.Count)
                {
                    throw new ArgumentException($"Number of variables in the input and the template does not match. templateText: {uniqueMatches}, variables {parameters.Count}");
                }

                foreach (var variable in parameters)
                {
                    StringBuilder sb = new StringBuilder("$");
                    sb.Append(variable.Key);
                    sb.Append("$");
                    result = result.Replace(sb.ToString(), variable.Value);
                }

                return result;
            });
            
        }

        /// <summary>
        /// Replate fillings in the <paramref name="templateText"/> with parameters of <paramref name="parameters"/>
        /// </summary>
        /// <param name="templateText">String which may contain variables enclosed in dollar signs. Examples: Hello $name$. </param>
        /// <param name="parameters">Set of variable names and values. Example: "name, Denis", "balance, 1000" </name></param>
        /// <returns></returns>
        public static string ApplyTextTemplate(string templateText, Dictionary<string,string> parameters)
        {
            string result = templateText;
            var matches = new Regex(@"\$.+?\$").Matches(templateText);
            var uniqueMatches = matches
                .OfType<Match>()
                .Select(m => m.Value)
                .Distinct().Count();
            
            if (parameters == null)
            {
                throw new ArgumentException($"Variables cannot be null.");
            }

            if (uniqueMatches != parameters.Count)
            {
                throw new ArgumentException($"Number of variables in the input and the template does not match. templateText: {uniqueMatches}, variables {parameters.Count}");
            }

            foreach (var variable in parameters)
            {
                StringBuilder sb = new StringBuilder("$");
                sb.Append(variable.Key);
                sb.Append("$");
                result = result.Replace(sb.ToString(), variable.Value);
            } 
            
            
            return result;
        }
    }
}
