using System;
using System.Collections.Generic;
using System.Text;
using Tendo.Services.Interfaces;

namespace Tendo.Services
{
    public class ComplexSentimentAnalysis : ISentimentAnalysisService
    {
        private readonly HashSet<string> unhappyWords = new HashSet<string>(){
            "sad", "angry", "frustrated", "unhappy"
        };
        private readonly HashSet<string> happyWords = new HashSet<string>(){
            "happy","glad", "relieved", "excited"
        };
        public float AnalyzeText(string text)
        {
            float sentiment = .5F;
            var words = text.Split(" ");
            foreach (var word in words) {
                var lowercaseWord = word.ToLower();
                if (happyWords.Contains(lowercaseWord))
                    sentiment += .01F;
                else if (unhappyWords.Contains(lowercaseWord))
                    sentiment -= .01F;
            }

            // force max / min values
            if (sentiment < 0) sentiment = 0;
            if (sentiment > 1) sentiment = 1;
            return sentiment;
        }
    }
}
